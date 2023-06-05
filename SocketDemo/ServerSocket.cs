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
        private static Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); //客户端监听socket

        private IPAddress bindIP;   //绑定服务器的某个网卡的IP(IPAddress类)，规范写法要写成IPAddress.Any
        private int bindPort;       //服务器的监听端口
        private int listenRequests; //监听允许客户端连接数
        private byte[] receiveBuff; //服务器接收缓冲区
        private byte[] sendBuffer;  //服务器发送缓冲区

        private List<UserInfo> connectedClients = new List<UserInfo>();     //储存连接上的客户端
        public List<UserInfo> ConnectedClients { get => connectedClients; set => connectedClients = value; }

        private Semaphore sme;  //控制服务器与客户端连接线程数


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
            serverSocket.Bind(new IPEndPoint(this.bindIP, bindPort));   
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
        /// 客户端和服务器建立连接
        /// </summary>
        /// <returns></returns>
        public async Task<bool> ConnectClient(UserInfo user)
        {
            try
            {
                await Task<bool>.Run(() =>
                {
                    sme.WaitOne();  //计数器-1

                    user.ClientConnectSocket = serverSocket.Accept();    //Accept()建立连接
                    user.ConnectTime = DateTime.Now;
                    user.ClientIP = (user.ClientConnectSocket.RemoteEndPoint as IPEndPoint).Address;
                    user.ClientPort = (user.ClientConnectSocket.RemoteEndPoint as IPEndPoint).Port;
                    user.CancelRecvMsgSource = new CancellationTokenSource();
                    user.CancelRecvMsgToken = user.CancelRecvMsgSource.Token;
                    ConnectedClients.Add(user);
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

        /// <summary>
        /// 服务器接收userSendMsg发送的消息，并将消息发送给userRecvMsg
        /// </summary>
        /// <param name="userSendMsg">发送方</param>
        /// <param name="userRecvMsg">接收方</param>
        public void ReceiveMsg(UserInfo userSendMsg, UserInfo userRecvMsg)
        {
            /*
             1.通过List，展示目前连上服务器的user列表；
             2.目前，先完成配队user不在线时无法发消息。在线时发消息。以后增加消息buffer缓存离线消息。
             3.将ClientInfo写成类。用户信息存储到DB中。
             
             */
            Task.Run(() =>
            {
                try
                {
                    string recvMsg = String.Empty;
                    int bytes = 0;
                    while ((bytes = userSendMsg.ClientConnectSocket.Receive(receiveBuff, receiveBuff.Length, 0)) > 0)
                    {
                        if (userSendMsg.CancelRecvMsgSource.IsCancellationRequested)
                        {
                            break;
                        }

                        recvMsg = Encoding.ASCII.GetString(receiveBuff, 0, bytes);
                        string chatMsg = String.Empty;
                        DateTime sendMsgTime = this.MsgGetTime(recvMsg, out chatMsg);

                        if (userSendMsg.recvEvent != null)
                        {
                            userSendMsg.recvEvent(this, new Message(sendMsgTime, chatMsg));
                        }


                        if(userRecvMsg.ClientConnectSocket != null)
                        {
                            //在线：发送
                            this.SendClientMsg(userRecvMsg, "Server has received message...");
                        }

                        # region msg写入db
                            //signIN时创建记录sendMsg的表、recvMsg的表
                        #endregion

                    }
                }
                catch (Exception ex)
                {
                }
            }, userSendMsg.CancelRecvMsgToken);

        }

        /// <summary>
        /// 从client发送的msg中分割出发送时间。
        /// </summary>
        /// <param name="msg">client发送的消息。格式【YYYY-MM-DD_HH:MM:SS_str】</param>
        /// <returns></returns>
        private DateTime MsgGetTime(string msg, out string chatMsg)
        {
            /*
             var date1 = new DateTime(2013, 6, 1, 12, 32, 30);
             DateTime.TryParse(dateString, out parsedDate)
             */
            try
            {
                chatMsg = "hello";
                return DateTime.Now;
            }
            catch(Exception ex)
            {
                chatMsg = ex.ToString();
                return DateTime.Now;
            }
        }

        /// <summary>
        /// 给客户端发消息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool SendClientMsg(UserInfo userRecvMsg, string msg)
        {
            try
            {
                int bytes = 0;
                this.sendBuffer = Encoding.ASCII.GetBytes(msg);
                bytes = userRecvMsg.ClientConnectSocket.Send(sendBuffer);
                //sendEvent(bytes);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool haltRecvMsg(UserInfo user)
        {
            try
            {
                user.CancelRecvMsgSource.Cancel();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DisConnect(UserInfo user)
        {
            try
            {
                haltRecvMsg(user);  //先终止接收消息线程，再断开连接
                user.ClientConnectSocket.Shutdown(SocketShutdown.Both);
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
        public bool Dispose(UserInfo user)
        {

            try
            {
                user.CancelRecvMsgSource.Cancel();  //先终止线程，再断开连接
                user.ClientConnectSocket.Shutdown(SocketShutdown.Both);
            }
            catch { return false; }

            try
            {
                user.ClientConnectSocket.Close();
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
