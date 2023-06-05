using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketDemo
{
    public class Message : EventArgs
    {
        private string chatMsg;
        public string ChatMsg { get => chatMsg; set => chatMsg = value; }
        
        private DateTime sendTime;
        public DateTime SendTime { get => sendTime; set => sendTime = value; }

        public Message(DateTime sendTime, string msg) {
            this.sendTime = sendTime; 
            this.chatMsg = msg;
        }

    }
}
