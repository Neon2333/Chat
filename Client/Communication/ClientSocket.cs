using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Client.UIL.Model;

namespace Client.Communication
{
    public class ClientSocket
    {
        private static string svrIP = "127.0.0.1";    //服务器IP
        public static string SvrIP { get => svrIP; set => svrIP = value; }

        private static int svrPort = 8888;     //服务器端口
        public static int SvrPort { get => svrPort; set => svrPort = value; }

        private static Socket connectSvr;

        public bool ConnectSvr()
        {
            try
            {
                IPAddress ip = IPAddress.Parse(svrIP);
                IPEndPoint ipe = new IPEndPoint(ip, svrPort);//把ip和端口转化为IPEndpoint实例

                ///创建socket并连接到服务器
                connectSvr = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//创建Socket
                connectSvr.Connect(ipe);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public int SendMsg(string sendMsg)
        {
            byte[] bs = Encoding.ASCII.GetBytes(sendMsg);//把字符串编码为字节
            return connectSvr.Send(bs, bs.Length, 0);//发送信息
        }

        public string RecvMsg()
        {
            ///接受从服务器返回的信息
            string recvStr = "";
            byte[] recvBytes = new byte[1024];
            byte[] bytes = new byte[1024];
            int count = connectSvr.Receive(recvBytes, recvBytes.Length, 0);//从服务器端接受返回信息
            Unpackage.SetUnPackage(new List<byte>(recvBytes), 37, out bytes);
            UserMessage msg = SerializeHelper.DeserializeWithXml<UserMessage>(bytes);

            return msg.ChatMsg;
        }




    }
}
