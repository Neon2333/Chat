using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace SocketDemo
{
    public class UserInfo
    {
        #region 用户连接信息
        private int userID;      //用户ID
        public int UserID { get => userID; set => userID = value; }

        private string userName; //用户名
        public string UserName { get => userName; set => userName = value; }

        private string userPwd;      //用户密码
        public string UserPwd { get => userPwd; set => userPwd = value; }
        
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
        
        private CancellationTokenSource cancelRecvMsgSource;    
        public CancellationTokenSource CancelRecvMsgSource { get => cancelRecvMsgSource; set => cancelRecvMsgSource = value; }
        
        private CancellationToken cancelRecvMsgToken;   //recvmsg取消
        public CancellationToken CancelRecvMsgToken { get => cancelRecvMsgToken; set => cancelRecvMsgToken = value; }
        
        private string recvMsg;     //接收的message
        public string RecvMsg { get => recvMsg; set => recvMsg = value; }



        #endregion

        #region 用户收发消息
        public EventHandler<Message> recvEvent = null;  //接收消息事件
        public Action<int> sendEvent = null;            //发送消息事件
        private CancellationTokenSource tokenSource;    //控制receiveMsg线程终止
        private CancellationToken token;

        #endregion
    }
}
