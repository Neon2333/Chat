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

        private static Socket connectSvrSocket;
        public static Socket ConnectSvrSocket { get => connectSvrSocket; set => connectSvrSocket = value; }

        public bool ConnectSvr()
        {
            try
            {
                IPAddress ip = IPAddress.Parse(svrIP);
                IPEndPoint ipe = new IPEndPoint(ip, svrPort);//把ip和端口转化为IPEndpoint实例

                ///创建socket并连接到服务器
                ConnectSvrSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//创建Socket
                /*
                 *如果这三次发送非常紧密时间非常短，会被优化算法优化成一个数据包发送出去，
                 *这属于客户端粘包，可以关闭Nagle算法，那么调用几次send就会发送几次包
                 */
                //关闭Nagle算法，解决客户端沾包
                ConnectSvrSocket.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.NoDelay, true);
                ConnectSvrSocket.Connect(ipe);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public int SendData(UserInfoSignIn userRecvMsg, string sendMsg)
        {
            byte[] bs = Encoding.ASCII.GetBytes(sendMsg);//把字符串编码为字节
            return ConnectSvrSocket.Send(bs, bs.Length, 0);//发送信息
        }

        public void RecvData(UserInfoSignIn userRecvData)
        {
            try
            {
                //全部接收到缓冲区后，再异步处理

                byte[] recvBufferTemp = new byte[1024];
                int bytesRecv = 0;

                //接收缓冲区中数据全部放到RecvBuffer中
                while ((bytesRecv = userRecvData.ClientConnectSocket.Receive(recvBufferTemp, 0)) > 0)
                {
                    userRecvData.recvBuffer.AddRange(recvBufferTemp.ToList<byte>());
                }

                //拆包
                NetPacket netPacket = new NetPacket();
                List<byte> onePacket = new List<byte>();
                while (netPacket.UnPackage(ref userRecvData.recvBuffer, out onePacket))
                {
                    //UserMessage msg = Communication.SerializeHelper.DeserializeObjWithXmlBytes<UserMessage>(onePacket.ToArray());
                    if (userRecvData.recvEvent != null)
                    {
                        userRecvData.recvEvent(this, onePacket.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }




    }
}
