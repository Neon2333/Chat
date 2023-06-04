using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;

namespace SocketDemo
{
    public class ServerSocket
    {

        public EventHandler<Message> recvEvent = null;    //接收消息事件
        public Action<int> sendEvent = null;   //发送消息事件

        private IPAddress bindIP;   //绑定服务器的某个网卡的IP(IPAddress类)，规范写法要写成IPAddress.Any
        private int bindPort;       //服务器的监听端口
        private int listenRequests; //监听允许连接数
        private byte[] receiveBuff; //接收缓冲区
        private byte[] sendBuffer;  //发送缓冲区
        private static Socket serverSocket; //监听客户端的socket

        public struct ConnectClientInfo
        {
            public DateTime connectTime;
            public Socket clientConnectSocket;
            public IPAddress clientIP;
            public int clientPort;
            public CancellationTokenSource tokenSource; //控制线程终止
            public CancellationToken token;
        }
        private List<ConnectClientInfo> clientConnectSockets = new List<ConnectClientInfo>();     //储存客户端连接
        //private Socket clientConnectSocket; //连接客户端后用于收发消息的socket

        private Semaphore sme;  //控制服务器连接线程数


        public ServerSocket(IPAddress bindIP, int bindPort, int listenRequests, int recvBuffSize, int sendBuffSize)
        {
            this.bindIP = bindIP;
            this.bindPort = bindPort;
            this.listenRequests = listenRequests;
            this.receiveBuff = new byte[recvBuffSize];
            this.sendBuffer = new byte[sendBuffSize];

            if (serverSocket == null)
            {
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            }
            serverSocket.Bind(new IPEndPoint(this.bindIP, bindPort));   //IPEndPoint是IP:port
            sme = new Semaphore(this.listenRequests, this.listenRequests);

        }

        /// <summary>
        /// 启动监听
        /// </summary>
        /// <param name="status">状态信息</param>
        /// <returns></returns>
        public bool initListen(out string status)
        {
            try
            {
                serverSocket.Listen(listenRequests);
                status = $"启动监听 {serverSocket.LocalEndPoint.ToString()} 成功..";
                return true;
            }
            catch (Exception ex)
            {
                status = $"启动监听 {serverSocket.LocalEndPoint.ToString()} 失败..";
                return false;
            }
        }

        /// <summary>
        /// 连接客户端
        /// </summary>
        /// <returns></returns>
        public async Task<bool> ConnectClient()
        {
            try
            {
                await Task<bool>.Run(() =>
                {
                    sme.WaitOne();

                    ConnectClientInfo ccf;
                    Socket clientConnectSocket = serverSocket.Accept();    //Accept()建立连接
                    ccf.clientConnectSocket = clientConnectSocket;
                    ccf.connectTime = DateTime.Now;
                    ccf.clientIP = (clientConnectSocket.RemoteEndPoint as IPEndPoint).Address;
                    ccf.clientPort = (clientConnectSocket.RemoteEndPoint as IPEndPoint).Port;
                    ccf.tokenSource = new CancellationTokenSource();
                    ccf.token = ccf.tokenSource.Token;
                    clientConnectSockets.Add(ccf);
                });
                return true;
            }
            catch (Exception ex)
            {
                sme.Release();
                return false;
            }
        }

        //public void ReceiveMsg(TextBox tb_recv, TextBox tb_status)
        //{
        //    tokenSource = new CancellationTokenSource();
        //    token = tokenSource.Token;

        //    Task.Run(() =>
        //    {
        //        try
        //        {
        //            string recvMsg = String.Empty;
        //            int bytes = 0;
        //            while ((bytes = clientConnectSocket.Receive(receiveBuff, receiveBuff.Length, 0)) > 0)
        //            {
        //                if (tokenSource.IsCancellationRequested)
        //                {
        //                    //tb_status.Invoke(new Action(() => tb_status.Text = "recv thread cancel.."));
        //                    break;
        //                }

        //                recvMsg = Encoding.ASCII.GetString(receiveBuff, 0, bytes);

        //                if (tb_recv.InvokeRequired)
        //                {
        //                    //tb_recv.Invoke(new Action(() => tb_recv.Text += recvMsg));
        //                }
        //                this.SendClientMsg("Server has received message...");
        //            }
        //        }
        //        catch(Exception ex)
        //        {
        //            tb_status.Invoke(new Action(() => tb_status.Text = ex.ToString()));
        //        }
        //    }, token);

        //}

        public void ReceiveMsg(ConnectClientInfo clientConnectSocket1, ConnectClientInfo clientConnectSocket2)
        {
            Task.Run(() =>
            {
                try
                {
                    string recvMsg = String.Empty;
                    int bytes = 0;
                    while ((bytes = clientConnectSocket1.clientConnectSocket.Receive(receiveBuff, receiveBuff.Length, 0)) > 0)
                    {
                        if (clientConnectSocket1.tokenSource.IsCancellationRequested)
                        {
                            break;
                        }

                        recvMsg = Encoding.ASCII.GetString(receiveBuff, 0, bytes);

                        if (this.recvEvent != null)
                        {
                            this.recvEvent(this, new Message(recvMsg));
                        }

                        this.SendClientMsg(clientConnectSocket2.clientConnectSocket, "Server has received message...");
                    }
                }
                catch (Exception ex)
                {
                }
            }, clientConnectSocket1.token);

        }

        /// <summary>
        /// 给客户端发消息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool SendClientMsg(Socket clientConnectSocket, string msg)
        {
            try
            {
                int bytes = 0;
                this.sendBuffer = Encoding.ASCII.GetBytes(msg);
                bytes = clientConnectSocket.Send(sendBuffer);
                //sendEvent(bytes);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool haltRecvMsg()
        {
            try
            {
                this.tokenSource.Cancel();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DisConnect()
        {
            try
            {
                haltRecvMsg();  //先终止接收消息线程，再断开连接
                this.clientConnectSocket.Shutdown(SocketShutdown.Both);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        /// <summary>
        /// 断开连接，释放socket
        /// </summary>
        public bool Dispose()
        {

            try
            {
                this.tokenSource.Cancel();  //先终止线程，再断开连接
                clientConnectSocket.Shutdown(SocketShutdown.Both);
            }
            catch { return false; }

            try
            {
                clientConnectSocket.Close();
            }
            catch { return false; }

            //try
            //{
            //    serverSocket.Shutdown(SocketShutdown.Both);
            //}
            //catch { return false; }

            try
            {
                serverSocket.Close();
                sme.Release();
                return true;
            }
            catch { return false; }

        }
    }
}
