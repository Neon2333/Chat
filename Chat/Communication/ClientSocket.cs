﻿using System;
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
using Server.UIL;
using MySql.Data.MySqlClient.Authentication;
using System.Reflection;
using ChatModel;

namespace Server.Communication
{
    public class ClientSocket
    {
        private static Socket svrListenSocket; //客户端监听socket

        private IPAddress bindIP;   //绑定服务器的某个网卡的IP(IPAddress类)，规范写法要写成IPAddress.Any
        private int bindPort;       //服务器的监听端口
        private int listenRequests; //监听允许客户端连接数

        private List<UserInfoSignIn> connectedClients = new List<UserInfoSignIn>();     //储存连接上的客户端
        public List<UserInfoSignIn> ConnectedClients { get => connectedClients; set => connectedClients = value; }

        private Semaphore sme;  //控制服务器与客户端连接线程数


        public ClientSocket(IPAddress bindIP, int bindPort, int listenRequests)
        {
            this.bindIP = bindIP;
            this.bindPort = bindPort;
            this.listenRequests = listenRequests;

            if (svrListenSocket == null)
            {
                svrListenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                svrListenSocket.Bind(new IPEndPoint(this.bindIP, bindPort));   
            }
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
                svrListenSocket.Listen(listenRequests);    
                return true;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
        }

        /// <summary>
        /// 客户端和服务器建立连接
        /// </summary>
        /// <returns></returns>
        public async Task<bool> AcceptClientConnect(UserInfoSignIn user)
        {
            try
            {
                //这里的问题是若收不到client的连接，会阻塞在这里。应该使用Listen，有client来连的时候自动调用
                await Task<bool>.Run(() =>
                {
                    sme.WaitOne();  //计数器-1

                    user.ClientConnectSocket = svrListenSocket.Accept();    //Accept()建立连接
                    user.ClientIP = (user.ClientConnectSocket.RemoteEndPoint as IPEndPoint).Address; 
                    user.ClientPort = (user.ClientConnectSocket.RemoteEndPoint as IPEndPoint).Port;
                    user.ConnectTime = DateTime.Now;
                    user.CancelRecvToken = user.CancelRecvSource.Token;
                    user.CancelSendToken = user.CancelSendSource.Token;
                    //default用户不加入用户列表
                    if (!"Server".Equals(user.UserName))
                    {
                        ConnectedClients.Add(user);
                    }

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


        /// <summary>
        /// 拆包，收数据
        /// </summary>
        /// <param name="userSendMsg"></param>
        public void RecvData(UserInfoSignIn userSendData)
        {
            //Task.Run(() =>
            //{
            //    try
            //    {
            //        /*将receive的data放到buffer中
            //         receive的data>0继续接收 
            //         data<54继续接收
            //         data>=54,解析header，看数据长度
            //        若data-54<header.length则继续接收


            //         */
            //        byte[] recvBuffer = new byte[userSendMsg.RecvBufferSize];
            //        int totalBytesRecv = 0;

            //        byte[] recvBufferTemp = new byte[userSendMsg.RecvBufferSize];
            //        int bytesRecv = 0;

            //        while ((bytesRecv = userSendMsg.ClientConnectSocket.Receive(recvBufferTemp, 0)) > 0)
            //        {
            //            Array.Copy(recvBuffer, totalBytesRecv, recvBufferTemp, 0, bytesRecv);
            //            totalBytesRecv += bytesRecv;
            //        }

            //        UserMessage msg = DAL.UserMessageService.UserMessageDeserilize(recvBuffer);

            //        if (userSendMsg.recvEvent != null)
            //        {
            //            userSendMsg.recvEvent(this, msg);
            //        }

            //        #region msg写入db
            //            //signIN时创建记录sendMsg的表、recvMsg的表
            //            #endregion
            //    }
            //    catch (Exception ex)
            //    {
            //    }
            //}, userSendMsg.CancelRecvMsgToken);

            try
            {
                //全部接收到缓冲区后，再异步处理

                byte[] recvBufferTemp = new byte[65535];    //系统buffer.size=65535
                int bytesRecv = 0;

                //接收缓冲区中数据全部放到RecvBuffer中
                while ((bytesRecv = userSendData.ClientConnectSocket.Receive(recvBufferTemp)) > 0)
                {
                    userSendData.recvBuffer.AddRange(recvBufferTemp.Take<byte>(bytesRecv).ToList<byte>());

                    //拆包
                    NetPacket packet = new NetPacket();
                    PackageModel onePacket;
                    while (packet.UnPackageBinary(ref userSendData.recvBuffer, out onePacket))
                    {
                        //UserMessage msg = Communication.SerializeHelper.DeserializeObjWithXmlBytes<UserMessage>(onePacket.ToArray());
                        if (userSendData.recvEvent != null)
                        {
                            userSendData.recvEvent(this, onePacket);
                        }
                    }
                }

               
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 封包，给单个客户端发数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        //public bool SendMsgClient(UserInfoSignIn userRecvMsg, UserMessage msg)
        public bool SendDataClient(UserInfoSignIn userRecvData, PackageModel package)
        {
            NetPacket packet = new NetPacket();
            byte[] sendBytes = packet.PackageBinary(package);



            if (userRecvData.ClientConnectSocket.Send(sendBytes) == sendBytes.Length)
            {
                if (userRecvData.sendEvent != null)
                {
                    userRecvData.sendEvent(this, package);
                }
                return true;
            }
            else
            {
                return false;
            }
            //sendEvent(bytes);
        }

        /// <summary>
        /// 给多个客户端发数据
        /// </summary>
        /// <param name="userRecvMsg"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool SendMsgClients(List<UserInfoSignIn> userRecvMsg, byte[] data)
        {

            return true;
        }


        ///// <summary>
        ///// 服务器接收userSendMsg发送的消息，并将消息发送给userRecvMsg
        ///// </summary>
        ///// <param name="userSendMsg">发送方</param>
        ///// <param name="userRecvMsg">接收方</param>
        //public void ReceiveSendData(UserInfoSignIn userSendMsg, UserInfoSignIn userRecvMsg)
        //{
        //    /*
        //     2.目前，先完成配队user不在线时无法发消息。在线时发消息。以后增加消息buffer缓存离线消息。
        //     */

        //    Task.Run(() =>
        //    {
        //        try
        //        {
        //            string chatMsg = String.Empty;
        //            DateTime sendMsgTime = DateTime.Now;
        //            byte[] recvBuffer = new byte[1024];

        //            int bytesLen = 0;
        //            while ((bytesLen = userSendMsg.ClientConnectSocket.Receive(recvBuffer, userSendMsg.RecvBufferSize, 0)) > 0)
        //            {
        //                if (userSendMsg.CancelRecvMsgSource.IsCancellationRequested)
        //                {
        //                    break;
        //                }


        //                //UserMessage msg = DAL.UserMessageService.UserMessageDeserilize(recvBuffer);
        //                UserMessage msg = new UserMessage(userSendMsg.UserID, userSendMsg.UserName, userSendMsg.UserID, userSendMsg.UserName,
        //                    DateTime.Now, SerializeHelper.ConvertToString(recvBuffer, 0, bytesLen, Encoding.Default));



        //                if (userSendMsg.recvEvent != null)
        //                {
        //                    userSendMsg.recvEvent(this, msg);
        //                }


        //                if(userRecvMsg.ClientConnectSocket != null)
        //                {
        //                    //在线：发送
        //                    this.SendDataClient(userRecvMsg, msg);
        //                }

        //                # region msg写入db
        //                    //signIN时创建记录sendMsg的表、recvMsg的表
        //                #endregion

        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //        }
        //    }, userSendMsg.CancelRecvMsgToken);

        //}

        public bool haltRecvMsg(UserInfoSignIn user)
        {
            try
            {
                user.CancelRecvSource.Cancel();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DisConnect(UserInfoSignIn user)
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
        public bool Dispose(UserInfoSignIn user)
        {
            try
            {
                user.CancelRecvSource.Cancel();  //先终止线程，再断开连接
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
                svrListenSocket.Close();
                sme.Release();
                return true;
            }
            catch { return false; }

        }
    }
}