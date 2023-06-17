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
    class ClientSocket
    {
        public static Socket ConnectSvr(string host="127.0.0.1", int port=8888)
        {
            IPAddress ip = IPAddress.Parse(host);
            IPEndPoint ipe = new IPEndPoint(ip, port);//把ip和端口转化为IPEndpoint实例

            ///创建socket并连接到服务器
            Socket ss = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//创建Socket
            ss.Connect(ipe);

            return ss;
        }

        public static int SendMsg(string sendMsg, Socket connectSocket)
        {
            byte[] bs = Encoding.ASCII.GetBytes(sendMsg);//把字符串编码为字节
            Console.WriteLine("Send Message");
            return connectSocket.Send(bs, bs.Length, 0);//发送信息
        }

        public static string RecvMsg(Socket connectSocket)
        {
            ///接受从服务器返回的信息
            string recvStr = "";
            byte[] recvBytes = new byte[1024];
            byte[] bytes = new byte[1024];
            int count = connectSocket.Receive(recvBytes, recvBytes.Length, 0);//从服务器端接受返回信息
            Unpackage.SetUnPackage(new List<byte>(recvBytes), out bytes);
            UserMessage msg = Communication.SerializeHelper.SerializeHelper.DeserializeWithBinary<UserMessage>(bytes);

            return msg.ChatMsg;
        }



    }
}
