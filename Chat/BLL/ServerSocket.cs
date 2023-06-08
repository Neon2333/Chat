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
using System.Security.Cryptography;
using Server.UIL.Model;

namespace Server.BLL
{
    public class ServerSocket
    {
        private static Socket svrSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); //客户端监听socket

        private IPAddress bindIP;   //绑定服务器的某个网卡的IP(IPAddress类)，规范写法要写成IPAddress.Any
        private int bindPort;       //服务器的监听端口
        private int listenRequests; //监听允许客户端连接数

        private List<UserConnectInfo> connectedClients = new List<UserConnectInfo>();     //储存连接上的客户端
        public List<UserConnectInfo> ConnectedClients { get => connectedClients; set => connectedClients = value; }

        private Semaphore sme;  //控制服务器与客户端连接线程数


        public ServerSocket(IPAddress bindIP, int bindPort, int listenRequests)
        {
            this.bindIP = bindIP;
            this.bindPort = bindPort;
            this.listenRequests = listenRequests;

            if (svrSocket == null)
            {
                svrSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            }
            svrSocket.Bind(new IPEndPoint(this.bindIP, bindPort));   
            sme = new Semaphore(this.listenRequests, this.listenRequests);

        }

        /// <summary>
        /// 启动监听
        /// </summary>
        /// <param name="status">状态信息</param>
        /// <returns></returns>
        public bool Listen()
        {
            try
            {
                svrSocket.Listen(listenRequests);    
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 客户端和服务器建立连接
        /// </summary>
        /// <returns></returns>
        public async Task<bool> AcceptClientConnect(UserConnectInfo user)
        {
            try
            {
                //这里的问题是若收不到client的连接，会阻塞在这里。应该使用Listen，有client来连的时候自动调用
                await Task<bool>.Run(() =>
                {
                    sme.WaitOne();  //计数器-1

                    //注册的
                    user.ClientConnectSocket = svrSocket.Accept();    //Accept()建立连接
                    user.ConnectTime = DateTime.Now;
                    user.ClientIP = (user.ClientConnectSocket.RemoteEndPoint as IPEndPoint).Address; 
                    user.ClientPort = (user.ClientConnectSocket.RemoteEndPoint as IPEndPoint).Port;
                    user.ConnectTime = DateTime.Now;
                    user.CancelRecvMsgSource = new CancellationTokenSource();
                    user.CancelRecvMsgToken = user.CancelRecvMsgSource.Token;
                    ConnectedClients.Add(user);

                    if (user.connectedEvent != null)
                    {
                        user.connectedEvent(this, user);
                    }
                });
                return true;
            }
            catch (Exception ex)
            {
                sme.Release();
                return false;
            }
        }

        public void ReceiveMsg(UserConnectInfo userSendMsg)
        {

            Task.Run(() =>
            {
                try
                {
                    string chatMsg = String.Empty;
                    DateTime sendMsgTime = DateTime.Now;
                    byte[] recvBuffer = new byte[userSendMsg.RecvBufferSize];

                    int bytesLen = 0;
                    while ((bytesLen = userSendMsg.ClientConnectSocket.Receive(recvBuffer, userSendMsg.RecvBufferSize, 0)) > 0)
                    {
                        if (userSendMsg.CancelRecvMsgSource.IsCancellationRequested)
                        {
                            break;
                        }

                        UserMessage msg = DAL.UserMessageService.UserMessageDeserilize(recvBuffer);

                        if (userSendMsg.recvEvent != null)
                        {
                            userSendMsg.recvEvent(this, msg);
                        }

                        #region msg写入db
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
        /// 给客户端发消息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool SendClientMsg(UserConnectInfo userRecvMsg, UserMessage msg)
        {
            byte[] sendBuffer = new byte[userRecvMsg.SendBufferSize];

            try
            {
                int bytesLen = 0;
                //sendBuffer = DAL.UserMessageService.UserMessageSerialize(msg);
                sendBuffer = DAL.SerializeHelper.SerializeHelper.ConvertToByte(msg.ChatMsg, Encoding.Default);

                bytesLen = userRecvMsg.ClientConnectSocket.Send(sendBuffer);
                //sendEvent(bytes);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 服务器接收userSendMsg发送的消息，并将消息发送给userRecvMsg
        /// </summary>
        /// <param name="userSendMsg">发送方</param>
        /// <param name="userRecvMsg">接收方</param>
        public void ReceiveSendMsg(UserConnectInfo userSendMsg, UserConnectInfo userRecvMsg)
        {
            /*
             2.目前，先完成配队user不在线时无法发消息。在线时发消息。以后增加消息buffer缓存离线消息。
             */

            Task.Run(() =>
            {
                try
                {
                    string chatMsg = String.Empty;
                    DateTime sendMsgTime = DateTime.Now;
                    byte[] recvBuffer = new byte[userSendMsg.RecvBufferSize];

                    int bytesLen = 0;
                    while ((bytesLen = userSendMsg.ClientConnectSocket.Receive(recvBuffer, userSendMsg.RecvBufferSize, 0)) > 0)
                    {
                        if (userSendMsg.CancelRecvMsgSource.IsCancellationRequested)
                        {
                            break;
                        }


                        //UserMessage msg = DAL.UserMessageService.UserMessageDeserilize(recvBuffer);
                        UserMessage msg = new UserMessage(userSendMsg.UserID, userSendMsg.UserName, userSendMsg.UserID, userSendMsg.UserName,
                            DateTime.Now, DAL.SerializeHelper.SerializeHelper.ConvertToString(recvBuffer, 0, bytesLen, Encoding.Default));

                        if (userSendMsg.recvEvent != null)
                        {
                            userSendMsg.recvEvent(this, msg);
                        }


                        if(userRecvMsg.ClientConnectSocket != null)
                        {
                            //在线：发送
                            this.SendClientMsg(userRecvMsg, msg);
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

        

        public bool haltRecvMsg(UserConnectInfo user)
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

        public bool DisConnect(UserConnectInfo user)
        {
            try
            {
                haltRecvMsg(user);  //先终止接收消息线程，再断开连接
                user.ClientConnectSocket.Shutdown(SocketShutdown.Both);
                user.DisconnectTime = DateTime.Now;
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
        public bool Dispose(UserConnectInfo user)
        {
            try
            {
                user.CancelRecvMsgSource.Cancel();  //先终止线程，再断开连接
                user.ClientConnectSocket.Shutdown(SocketShutdown.Both);
                user.DisconnectTime = DateTime.Now;
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
                svrSocket.Close();
                sme.Release();
                return true;
            }
            catch { return false; }

        }
    }
}
