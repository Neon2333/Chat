using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.UIL.Model
{
    public class UserMessage: MessageModel
    {
        private int messageID; 
        public int MessageID { get => messageID; set => messageID = value; }

        private string chatMsg;     //聊天消息
        public string ChatMsg { get => chatMsg; set => chatMsg = value; }

        private int userIDSend;     //发送消息的user ID
        public int UserIDSend { get => userIDSend; set => userIDSend = value; }

        private string userNameSend;
        public string UserNameSend { get => userNameSend; set => userNameSend = value; }
        
        private int userIDRecv;     //接收消息的user ID
        public int UserIDRecv { get => userIDRecv; set => userIDRecv = value; }

        private string userNameRecv;
        public string UserNameRecv { get => userNameRecv; set => userNameRecv = value; }

        private DateTime sendTime;  //消息发送时间
        public DateTime SendTime { get => sendTime; set => sendTime = value; }


        public UserMessage() { }

        public UserMessage(string chatMsg, int userIDSend, string userNameSend, int userIDRecv, string userNameRecv, DateTime sendTime)
        {
            this.chatMsg = chatMsg;
            this.userIDSend = userIDSend;
            this.userNameSend = userNameSend;
            this.userIDRecv = userIDRecv;
            this.UserNameRecv = userNameRecv;
            this.sendTime = sendTime;
        }

    }
}
