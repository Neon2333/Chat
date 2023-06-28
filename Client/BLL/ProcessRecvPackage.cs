using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Client.UIL;
using Client.UIL.Model;
using Client.Communication;
using System.Reflection;

namespace Client.BLL
{
    class ProcessRecvPackage
    {
        public EventHandler<UserMessage> recvUserMessageEvent;

        public ProcessRecvPackage()
        {
            ClientSocket clientSocket = new ClientSocket();
            clientSocket.ConnectSvr();
            UserInfoSignIn uifs = new UserInfoSignIn();
            uifs.ClientConnectSocket = ClientSocket.ConnectSvrSocket;
            uifs.recvEvent += processPackage;
            Task.Run(() => clientSocket.RecvData(uifs));
        }

        //可改成工厂模式
        public void processPackage(object sender, PackageModel packageModel)
        {
            string msg = packageModel.Msg;
            string code = packageModel.Code;
            bool success = packageModel.Success;
            DateTime sendTime = packageModel.SendTime;
            //Type dataType = Assembly.Load("Client").GetType("Client." + packageModel.DataType);

            if(packageModel.DataType == "UserMessage")
            {
                UserMessage data = packageModel.Data as UserMessage;
                recvUserMessageEvent(this, data);
            }
        }

        


    }
}
