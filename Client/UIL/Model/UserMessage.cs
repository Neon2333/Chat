using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.UIL.Model
{
    [Serializable]
    public class UserMessage:MMessage
    {
        //private string chatMsg;     //消息内容
        //public string ChatMsg { get => chatMsg; set => chatMsg = value; }
        
        //private DateTime sendTime;  //发送时间
        //public DateTime SendTime { get => sendTime; set => sendTime = value; }

        private int userIDSend;     //发送消息的user ID
        public int UserIDSend { get => userIDSend; set => userIDSend = value; }

        private string userNameSend;
        public string UserNameSend { get => userNameSend; set => userNameSend = value; }
        
        private int userIDRecv;     //接收消息的user ID
        public int UserIDRecv { get => userIDRecv; set => userIDRecv = value; }

        private string userNameRecv;
        public string UserNameRecv { get => userNameRecv; set => userNameRecv = value; }

        public UserMessage(int userIDSend, string userNameSend, int userIDRecv, string userNameRecv, DateTime sendTime, string msg):base(msg, sendTime)
        {
            this.userIDSend = userIDSend;
            this.userNameSend = userNameSend;
            this.userIDRecv = userIDRecv;
            this.UserNameRecv = userNameRecv;
        }

    }
}
