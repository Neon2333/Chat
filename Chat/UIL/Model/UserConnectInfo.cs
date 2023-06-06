using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace Chat
{
    public class UserConnectInfo: EventArgs
    {
        #region 用户连接信息
        public EventHandler<UserConnectInfo> connectedEvent = null;  //连上服务器事件

        private int userID;      //用户ID
        public int UserID { get => userID; set => userID = value; }

        private string userName; //用户名
        public string UserName { get => userName; set => userName = value; }

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
        
        private int recvBufferSize = 10240; //服务器作为接收方
        public int RecvBufferSize { get => recvBufferSize; set => recvBufferSize = value; }
        
        private int sendBufferSize = 10240; //服务器作为发送方
        public int SendBufferSize { get => sendBufferSize; set => sendBufferSize = value; }

        #endregion

        #region 用户收发消息
        private UserConnectInfo relatedClient;
        public UserConnectInfo RelatedClient { get => relatedClient; set => relatedClient = value; }

        public EventHandler<Message> recvEvent = null;  //接收消息事件
        public EventHandler<Message> sendEvent = null;  //发送消息事件

        private CancellationTokenSource cancelRecvMsgSource;
        public CancellationTokenSource CancelRecvMsgSource { get => cancelRecvMsgSource; set => cancelRecvMsgSource = value; }

        private CancellationToken cancelRecvMsgToken;   //recvmsg取消
        public CancellationToken CancelRecvMsgToken { get => cancelRecvMsgToken; set => cancelRecvMsgToken = value; }
        #endregion
    }
}
