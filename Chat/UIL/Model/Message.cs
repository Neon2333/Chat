using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    public class Message : EventArgs
    {
        private string chatMsg;     //消息内容
        public string ChatMsg { get => chatMsg; set => chatMsg = value; }
        
        private DateTime sendTime;  //发送时间
        public DateTime SendTime { get => sendTime; set => sendTime = value; }

        private int userIDSend;     //发送消息的user ID
        public int UserIDSend { get => userIDSend; set => userIDSend = value; }
        
        private int userIDRecv;     //接收消息的user ID
        public int UserIDRecv { get => userIDRecv; set => userIDRecv = value; }


        public Message(int userIDSend, int userIDRecv, DateTime sendTime, string msg) {
            this.userIDSend = userIDSend;
            this.userIDRecv = userIDRecv;
            this.sendTime = sendTime; 
            this.chatMsg = msg;
        }

    }
}
