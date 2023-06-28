using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Collections;
using System.Xml.Serialization;

namespace Server.UIL.Model
{
    public class UserInfoSignIn:UserInfo
    {
        #region 用户连接信息
        [XmlIgnore]
        public EventHandler<UserInfoSignIn> connectedEvent = null;  //连上服务器事件

        private DateTime loginTime;         //登录时间
        public DateTime LoginTime { get => loginTime; set => loginTime = value; }

        [XmlIgnore]
        private Socket clientConnectSocket; //连接socket
        public Socket ClientConnectSocket { get => clientConnectSocket; set => clientConnectSocket = value; }

        private IPAddress clientIP;         //客户端IP
        public IPAddress ClientIP { get => clientIP; set => clientIP = value; }

        private int clientPort;             //客户端port
        public int ClientPort { get => clientPort; set => clientPort = value; }

        private DateTime connectTime;       //连接建立时间
        public DateTime ConnectTime { get => connectTime; set => connectTime = value; }
        
        private DateTime disconnectTime;    //断开连接时间
        public DateTime DisconnectTime { get => disconnectTime; set => disconnectTime = value; }
        #endregion

        [XmlIgnore]
        #region 缓冲区
        public List<byte> recvBuffer = new List<byte>();  //动态接收缓冲区
        [XmlIgnore]
        public List<byte> sendBuffer = new List<byte>();  //动态发送缓冲区
        #endregion

        [XmlIgnore]
        #region 收发事件
        public EventHandler<PackageModel> recvEvent = null;  //接收数据事件
        [XmlIgnore]
        public EventHandler<PackageModel> sendEvent = null;  //发送数据事件
        #endregion


        #region 用户收发消息线程中断控制
        private CancellationTokenSource cancelRecvSource = new CancellationTokenSource();
        [XmlIgnore]
        public CancellationTokenSource CancelRecvSource { get => cancelRecvSource; set => cancelRecvSource = value; }

        private CancellationToken cancelRecvToken;   //接收取消
        [XmlIgnore]
        public CancellationToken CancelRecvToken { get => cancelRecvToken; set => cancelRecvToken = value; }

        private CancellationTokenSource cancelSendSource = new CancellationTokenSource();
        [XmlIgnore]
        public CancellationTokenSource CancelSendSource { get => cancelSendSource; set => cancelSendSource = value; }

        private CancellationToken cancelSendToken;   //发送取消
        [XmlIgnore]
        public CancellationToken CancelSendToken { get => cancelSendToken; set => cancelSendToken = value; }
        #endregion


        public UserInfoSignIn() { }

        public UserInfoSignIn(int userId, string userName, string userPwd, DateTime signUpTime) : base(userId, userName, userPwd)
        { }
    }
}
