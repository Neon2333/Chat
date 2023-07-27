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
using MySql.Data.MySqlClient.Authentication;
using System.Reflection;
using ChatModel;
using Server.BLL;

namespace Server.Communication
{
    public class ServerSocket
    {
        //客户端监听socket
        private static Socket svrListenSocket;

        //绑定服务器的某个网卡的IP(IPAddress类)，规范写法要写成IPAddress.Any
        private IPAddress bindIP;

        //服务器的监听端口
        private int bindPort;

        //监听允许客户端连接数
        private int listenRequests;

        //储存连接上的客户端
        private Dictionary<IPEndPoint, UserInfoSignIn> connectedClients = new Dictionary<IPEndPoint, UserInfoSignIn>();
        public Dictionary<IPEndPoint, UserInfoSignIn> ConnectedClients { get => connectedClients; set => connectedClients = value; }

        //private Dictionary<IPAddress, UserInfoSignIn> connectedClients = new Dictionary<IPAddress, UserInfoSignIn>();
        //public Dictionary<IPAddress, UserInfoSignIn> ConnectedClients { get => connectedClients; set => connectedClients = value; }

        //private List<UserInfoSignIn> connectedClients = new List<UserInfoSignIn>();     
        //public List<UserInfoSignIn> ConnectedClients { get => connectedClients; set => connectedClients = value; }

        //控制服务器与客户端连接线程数
        private Semaphore sme;  

        /// <summary>
        /// 绑定监听参数
        /// </summary>
        /// <param name="bindIP">服务器网卡</param>
        /// <param name="bindPort">服务器监听端口</param>
        /// <param name="listenRequests">允许连接的客户端数</param>
        public ServerSocket(IPAddress bindIP, int bindPort, int listenRequests)
        {
            this.bindIP = bindIP;
            this.bindPort = bindPort;
            this.listenRequests = listenRequests;

            if (svrListenSocket == null)
            {
                svrListenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                svrListenSocket.Bind(new IPEndPoint(this.bindIP, bindPort));   
            }
            sme = new Semaphore(this.listenRequests, this.listenRequests);  //初始化信号量

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
            catch(SocketException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        #region modified_1
        /// <summary>
        /// 客户端和服务器建立连接
        /// </summary>
        /// <returns></returns>
        //public async Task<bool> AcceptClientConnect(UserInfoSignIn user)
        //{
        //    try
        //    {
        //        //这里的问题是若收不到client的连接，会阻塞在这里。应该使用Listen，有client来连的时候自动调用
        //        await Task<bool>.Run(() =>
        //        {
        //            sme.WaitOne();  //计数器-1

        //            user.ClientConnectSocket = svrListenSocket.Accept();    //Accept()建立连接
        //            user.ClientIP = (user.ClientConnectSocket.RemoteEndPoint as IPEndPoint).Address; 
        //            user.ClientPort = (user.ClientConnectSocket.RemoteEndPoint as IPEndPoint).Port;
        //            user.ConnectTime = DateTime.Now;
        //            user.CancelRecvToken = user.CancelRecvSource.Token;
        //            user.CancelSendToken = user.CancelSendSource.Token;
        //            //default用户不加入用户列表
        //            if (!"Server".Equals(user.UserName))
        //            {
        //                ConnectedClients.Add(user);
        //            }

        //            if (user.connectedEvent != null)
        //            {
        //                user.connectedEvent(this, user);
        //            }
        //        });
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        sme.Release();  //计数器+1
        //        return false;
        //    }
        //}
        #endregion

        /// <summary>
        /// 异步Accept
        /// </summary>
        public void AcceptClientConnect()
        {
            try
            {
                //Accept()建立连接
                svrListenSocket.BeginAccept(new AsyncCallback(AcceptCallback), svrListenSocket);    //不会卡死线程函数直接返回，当有连接时调用回调AcceptCallback
            }
            catch (NullReferenceException)
            {

            }
            catch (ArgumentNullException)
            {

            }
            catch (SocketException)
            {

            }
            catch(Exception ex)
            {

            }
        }

        //Accept回调
        public void AcceptCallback(IAsyncResult iar)
        {
            try
            {
                //获取监听svrListenSocket
                Socket svrListen = (Socket)iar.AsyncState;  

                //定义default用户完成初始连接
                //后面通过根据业务，给参数赋值将default用户转成具体的用户
                UserInfoSignIn defaultUser = new UserInfoSignIn();
                defaultUser.ClientConnectSocket = svrListen.EndAccept(iar); //获取连接socket
                IPEndPoint clientIPAndPort = defaultUser.ClientConnectSocket.RemoteEndPoint as IPEndPoint;
                defaultUser.ClientIP = clientIPAndPort.Address;
                defaultUser.ClientPort = clientIPAndPort.Port;
                defaultUser.ConnectTime = DateTime.Now;
                defaultUser.CancelRecvToken = defaultUser.CancelRecvSource.Token;
                defaultUser.CancelSendToken = defaultUser.CancelSendSource.Token;
                defaultUser.UserID = -1;
                defaultUser.UserName = "default";
                defaultUser.UserPwd = null;
                defaultUser.LoginTime = DateTime.Now;

                ConnectedClients.Add(clientIPAndPort, defaultUser);    //加入用户序列

                //触发客户端连接事件
                if (defaultUser.connectedEvent != null)
                {
                    defaultUser.connectedEvent(this, defaultUser);
                }
                
                Console.WriteLine($"connected: {defaultUser.ClientIP}:{defaultUser.ClientPort}");


                //子线程接收当前该连接数据
                //ConnectedClients.TryGetValue(clientIPandPort, out defaultUser);
                Task.Run(() => RecvData(defaultUser.ClientConnectSocket), defaultUser.CancelRecvToken);   

                //预备接收下一个客户端连接
                svrListenSocket.BeginAccept(new AsyncCallback(AcceptCallback), svrListen);    //Accept()建立连接时调用回调
            }
            catch (NullReferenceException)
            {

            }
            catch (ArgumentNullException)
            {

            }
            catch (SocketException)
            {

            }
            catch (Exception ex)
            {

            }
            
        }

        #region modified_1
        /// <summary>
        /// 拆包，收数据
        /// </summary>
        /// <param name="userSendMsg"></param>
        //public void RecvData(UserInfoSignIn userSendData)
        //{
        //    #region dele
        //    //Task.Run(() =>
        //    //{
        //    //    try
        //    //    {
        //    //        /*将receive的data放到buffer中
        //    //         receive的data>0继续接收 
        //    //         data<54继续接收
        //    //         data>=54,解析header，看数据长度
        //    //        若data-54<header.length则继续接收


        //    //         */
        //    //        byte[] recvBuffer = new byte[userSendMsg.RecvBufferSize];
        //    //        int totalBytesRecv = 0;

        //    //        byte[] recvBufferTemp = new byte[userSendMsg.RecvBufferSize];
        //    //        int bytesRecv = 0;

        //    //        while ((bytesRecv = userSendMsg.ClientConnectSocket.Receive(recvBufferTemp, 0)) > 0)
        //    //        {
        //    //            Array.Copy(recvBuffer, totalBytesRecv, recvBufferTemp, 0, bytesRecv);
        //    //            totalBytesRecv += bytesRecv;
        //    //        }

        //    //        UserMessage msg = DAL.UserMessageService.UserMessageDeserilize(recvBuffer);

        //    //        if (userSendMsg.recvEvent != null)
        //    //        {
        //    //            userSendMsg.recvEvent(this, msg);
        //    //        }

        //    //        #region msg写入db
        //    //            //signIN时创建记录sendMsg的表、recvMsg的表
        //    //            #endregion
        //    //    }
        //    //    catch (Exception ex)
        //    //    {
        //    //    }
        //    //}, userSendMsg.CancelRecvMsgToken);
        //    #endregion

        //    try
        //    {
        //        //全部接收到缓冲区后，再异步处理

        //        byte[] recvBufferTemp = new byte[65535];    //系统buffer.size=65535
        //        int bytesRecv = 0;

        //        //接收缓冲区中数据全部放到RecvBuffer中
        //        while ((bytesRecv = userSendData.ClientConnectSocket.Receive(recvBufferTemp)) > 0)
        //        {
        //            userSendData.recvBuffer.AddRange(recvBufferTemp.Take<byte>(bytesRecv).ToList<byte>());

        //            //拆包
        //            NetPacket packet = new NetPacket();
        //            PackageModel onePacket;
        //            while (packet.UnPackageBinary(ref userSendData.recvBuffer, out onePacket))
        //            {
        //                //UserMessage msg = Communication.SerializeHelper.DeserializeObjWithXmlBytes<UserMessage>(onePacket.ToArray());
        //                if (userSendData.recvEvent != null)
        //                {
        //                    userSendData.recvEvent(this, onePacket);
        //                }
        //            }
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}
        #endregion

        #region modified_2
        ////非阻塞Receive
        //byte[] recvBufferTemp = new byte[65535];    //系统buffer.size=65535
        //public void RecvData(ref UserInfoSignIn userRecvData)
        //{
        //        try
        //        {
        //            //接收缓冲区中数据全部放到RecvBuffer中
        //            userRecvData.ClientConnectSocket.BeginReceive(recvBufferTemp, 0, recvBufferTemp.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), userRecvData);
        //        }
        //        catch (Exception ex)
        //        {
        //        }
        //}

        //public void ReceiveCallback(IAsyncResult iar)
        //{
        //    try
        //    {
        //        UserInfoSignIn userRecvData = (UserInfoSignIn)iar.AsyncState;   //获取BeginReceive最后一个参数
        //        IPAddress clientIP = userRecvData.ClientIP; //取client的IP

        //        int bytesRecv = connectedClients[clientIP].ClientConnectSocket.EndReceive(iar);   //接收字节数
        //        Console.WriteLine($"received: {bytesRecv} bytes");
        //        connectedClients[clientIP].recvBuffer.AddRange(recvBufferTemp.Take<byte>(bytesRecv).ToList<byte>());

        //        //拆包
        //        NetPacket packet = new NetPacket();
        //        PackageModel onePacket;
        //        while (packet.UnPackageBinary(ref connectedClients[clientIP].recvBuffer, out onePacket))
        //        {
        //            //if (userRecvData.recvEvent != null)
        //            //{
        //            //    userRecvData.recvEvent(this, onePacket);
        //            //}
        //            connectedClients.TryGetValue(clientIP, out userRecvData);
        //            _onRecvData(ref userRecvData, onePacket);
        //            //_onRecvData(ref connectedClients[clientIP], onePacket);
        //        }

        //        //清空buffer重新接收
        //        recvBufferTemp = new byte[65535];
        //        userRecvData.ClientConnectSocket.BeginReceive(recvBufferTemp, 0, recvBufferTemp.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), userRecvData);
        //    }
        //    catch (NullReferenceException)
        //    {

        //    }
        //    catch (ArgumentNullException)
        //    {

        //    }
        //    catch (SocketException)
        //    {

        //    }
        //    catch (Exception ex)
        //    {

        //    }


        //}

        ////服务器接收数据事件处理
        //private void _onRecvData(ref UserInfoSignIn userRecvData, PackageModel onePacket)
        //{
        //    try
        //    {
        //        if (onePacket.PackageType == PackageModel.PackageTypeDef.RequestType_SignUp)
        //        {
        //            SvrUserSignUp svrUserSignUp = new SvrUserSignUp(ref userRecvData);
        //            //开个线程执行DoSignUp
        //            UserInfoSignIn tempUser = new UserInfoSignIn();
        //            Task.Run(() => svrUserSignUp.DoSignUp(ref userRecvData, onePacket));


        //        }
        //        else if (onePacket.PackageType == PackageModel.PackageTypeDef.RequestType_SignIn)
        //        {

        //        }
        //    }
        //    catch (NullReferenceException)
        //    {

        //    }
        //    catch (ArgumentNullException)
        //    {

        //    }
        //    catch (SocketException)
        //    {

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}
        #endregion

        /// <summary>
        /// 异步Receive
        /// </summary>
        byte[] recvBufferTemp = new byte[65535];    //系统buffer.size=65535
        public void RecvData(Socket clientConnSocket)
        {
            try
            {
                clientConnSocket.BeginReceive(recvBufferTemp, 0, recvBufferTemp.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), clientConnSocket);
            }
            catch (Exception ex)
            {
            }
        }

        //Receive回调
        public void ReceiveCallback(IAsyncResult iar)
        {
            try
            {
                Socket clientConnSocket = (Socket)iar.AsyncState;   //获取BeginReceive最后一个参数
                IPEndPoint clientIPAndPort = clientConnSocket.RemoteEndPoint as IPEndPoint;

                int bytesRecv = connectedClients[clientIPAndPort].ClientConnectSocket.EndReceive(iar);   //接收字节数
                
                //接收0B时不处理
                if(bytesRecv > 0)
                {
                    Console.WriteLine($"received: {bytesRecv} bytes..");

                    connectedClients[clientIPAndPort].recvBuffer.AddRange(recvBufferTemp.Take<byte>(bytesRecv).ToList<byte>());

                    //拆包
                    NetPacket packet = new NetPacket();
                    PackageModel onePacket;
                    while (packet.UnPackageBinary(ref connectedClients[clientIPAndPort].recvBuffer, out onePacket))
                    {
                        ////触发接收数据事件
                        //if (userRecvData.recvEvent != null)
                        //{
                        //    userRecvData.recvEvent(this, onePacket);
                        //}

                        _onRecvData(clientConnSocket, onePacket);
                        //_onRecvData(ref connectedClients[clientIP], onePacket);
                    }

                    //清空buffer重新接收
                    recvBufferTemp = new byte[65535];
                    clientConnSocket.BeginReceive(recvBufferTemp, 0, recvBufferTemp.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), clientConnSocket);
                }
                else
                {
                    Console.WriteLine($"received: 0 bytes..");
                }

            }
            catch (NullReferenceException)
            {

            }
            catch (ArgumentNullException)
            {

            }
            catch (SocketException)
            {

            }
            catch (Exception ex)
            {

            }


        }

        //服务器接收数据事件处理
        private void _onRecvData(Socket clientConnSocket, PackageModel onePacket)
        {
            try
            {
                if (onePacket.PackageType == PackageModel.PackageTypeDef.RequestType_SignUp)
                {
                    //执行注册SignUp
                    SvrUserSignUp svrUserSignUp = new SvrUserSignUp();
                    Task.Run(() => svrUserSignUp.DoSignUp(clientConnSocket, onePacket));
                }
                else if (onePacket.PackageType == PackageModel.PackageTypeDef.RequestType_SignIn)
                {
                    //执行登录SignIn


                }
            }
            catch (NullReferenceException)
            {

            }
            catch (ArgumentNullException)
            {

            }
            catch (SocketException)
            {

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
        public bool SendDataClient(Socket clientConnSocket, PackageModel package)
        {
            try
            {
                NetPacket packet = new NetPacket();
                byte[] sendBytes = packet.PackageBinary(package);

                IPEndPoint clientIPAndPort = clientConnSocket.RemoteEndPoint as IPEndPoint;
                if (clientConnSocket.Send(sendBytes) == sendBytes.Length)
                {
                    if (connectedClients[clientIPAndPort].sendEvent != null)
                    {
                        connectedClients[clientIPAndPort].sendEvent(this, package);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
                //sendEvent(bytes);
            }
            catch(SocketException ex)
            {
                return false;
            }
            catch(NullReferenceException ex)
            {
                return false;
            }
            catch(ArgumentNullException ex)
            {
                return false;
            }
            catch(Exception ex)
            {
                return false;
            }

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


        #region dele
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
        #endregion


        #region 断开连接
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

        #endregion

        
        
        
    }
}
