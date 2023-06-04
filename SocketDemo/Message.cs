using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketDemo
{
    public class Message : EventArgs
    {
        private string msg;
        public Message(string msg) {
            this.Msg = msg;
        }

        public string Msg { get => msg; set => msg = value; }
    }
}
