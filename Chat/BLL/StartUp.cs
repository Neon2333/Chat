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
     
        public UserInfoSignIn defaultUser;

        public StartUp() { }

        public async void Start()
        {
            defaultUser = new UserInfoSignIn();
            defaultUser.UserID = -1;
            defaultUser.UserName = "Server";
            defaultUser.UserPwd = null;
            defaultUser.LoginTime = DateTime.Now;
            defaultUser.CancelRecvToken = defaultUser.CancelRecvSource.Token;
            defaultUser.CancelSendToken = defaultUser.CancelSendSource.Token;

            defaultUser.connectedEvent += _onConnectSvrEvent;
            defaultUser.sendEvent += _onSendEvent;
            defaultUser.recvEvent += _onRecvEvent;
            
            ss.Listen();    
            await ss.AcceptClientConnect(defaultUser);
        }

        //客户端建立连接事件处理
        private void _onConnectSvrEvent(object sender, UserInfoSignIn user)
        {
            Task.Run(() => ss.RecvData(defaultUser), defaultUser.CancelRecvToken);
        }


        //接收数据事件处理
        private void _onRecvEvent(object sender, PackageModel package)
        {
            if (package.PackageType == PackageModel.PackageTypeDef.RequestType_SignUp)
            {
                SvrUserSignUp svrUserSignUp = new SvrUserSignUp();
                svrUserSignUp.DoSignUp(ss, defaultUser, package);
            }


        }

        //数据发送事件处理
        private void _onSendEvent(object sender, PackageModel packageModel)
        {
        }




    }
}
