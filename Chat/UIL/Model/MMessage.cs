using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.UIL.Model
{
    public abstract class MMessage:EventArgs
    {
        private string chatMsg;     //消息内容
        public string ChatMsg { get => chatMsg; set => chatMsg = value; }

        private DateTime sendTime;  //发送时间
        public DateTime SendTime { get => sendTime; set => sendTime = value; }

        public MMessage(string chatMsg, DateTime sendTime)
        {
            this.chatMsg = chatMsg;
            this.SendTime = sendTime;
        }

    }
}
