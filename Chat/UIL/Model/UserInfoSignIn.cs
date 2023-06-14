using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using Server.UIL.Model;
using System.Collections;

namespace Server.UIL.Model
{
    public class UserInfoSignIn:UserInfo
    {
        #region 用户连接信息
        public EventHandler<UserInfoSignIn> connectedEvent = null;  //连上服务器事件

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

        #region 缓冲区
        //private byte[] recvBuffer = new byte[1024];
        //public byte[] RecvBuffer { get => RecvBuffer; set => RecvBuffer = value; }

        private List<byte> recvBuffer;  //动态接收缓冲区
        public List<byte> RecvBuffer { get => recvBuffer; set => recvBuffer = value; }
    

        private int recvBufferSize = 1024; //服务器作为接收方
        public int RecvBufferSize { get => recvBufferSize; set => recvBufferSize = value; }
        
        private int sendBufferSize = 1024; //服务器作为发送方
        public int SendBufferSize { get => sendBufferSize; set => sendBufferSize = value; }

        #endregion

        #region 用户收发消息线程中断控制
        public EventHandler<UserMessage> recvEvent = null;  //接收消息事件
        public EventHandler<UserMessage> sendEvent = null;  //发送消息事件

        private CancellationTokenSource cancelRecvMsgSource;
        public CancellationTokenSource CancelRecvMsgSource { get => cancelRecvMsgSource; set => cancelRecvMsgSource = value; }

        private CancellationToken cancelRecvMsgToken;   //recvmsg取消
        public CancellationToken CancelRecvMsgToken { get => cancelRecvMsgToken; set => cancelRecvMsgToken = value; }
        #endregion



    }
}
