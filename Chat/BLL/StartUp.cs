using ChatModel;
using Server.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Server.BLL
{
    class StartUp
    {
        public static ServerSocket ss = new ServerSocket(IPAddress.Any, 8888, 10);
     
        public StartUp() { }

        public void Start()
        {
            ss.Listen();
            ss.AcceptClientConnect();
        }



    }
}
