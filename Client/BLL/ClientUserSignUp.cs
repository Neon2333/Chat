using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.UIL;
using ChatModel;
using Client.Communication;

namespace Client.BLL
{
    class ClientUserSignUp
    {
        public UserInfoSignIn defaultUserInfoSignIn;
        public UserInfoSignUp PackageUserInfoSignUp;
        public bool IsSuccessSignUpResponse;

        public ClientUserSignUp()
        {
            defaultUserInfoSignIn = new UserInfoSignIn();
            defaultUserInfoSignIn.UserID = -1;
            defaultUserInfoSignIn.UserName = "default";
            defaultUserInfoSignIn.UserPwd = null;
            defaultUserInfoSignIn.LoginTime = DateTime.Now;
            defaultUserInfoSignIn.ClientConnectSocket = ClientSocket.ConnectSvrSocket;
            defaultUserInfoSignIn.CancelSendToken = defaultUserInfoSignIn.CancelSendSource.Token;
            defaultUserInfoSignIn.recvEvent += _onSignUpRecv;
            defaultUserInfoSignIn.sendEvent += _onSignUpSend;
        }

        public bool DoSignUp(string usrName, string usrPwd, int timeoutMill)
        {
            List<Task> doSignUpTasks = new List<Task>();

            Task<bool> sendTask = Task.Run(() =>
            {
                //需要先Send再Recv
                return SignUpSend(usrName, usrPwd) && SignUpRecv(defaultUserInfoSignIn);
                
                //if (SignUpSend(usrName, usrPwd))
                //{
                //    if (SignUpRecv(defaultUserInfoSignIn))
                //    {

                //    }
                //}
                //else
                //{
                //}
                
            });

            //Wait在timeout内完成task返回Task。否则false，但线程还会继续执行
            return sendTask.Wait(timeoutMill, defaultUserInfoSignIn.CancelSendToken);
        }


        #region 发送注册数据包   
        private void _onSignUpSend(object sender, PackageModel package)
        {
        }

        private bool SignUpSend(string usrName, string usrPwd)
        {
            //创建实体类
            PackageUserInfoSignUp = new UserInfoSignUp();
            PackageUserInfoSignUp.UserName = usrName;
            PackageUserInfoSignUp.UserPwd = Encrypt.MD5Encrypt.EncryptMD5(usrPwd); //pwd加密

            //打包实体类
            PackageModel packageModelSignUp = new PackageModel();
            packageModelSignUp.PackageType = PackageModel.PackageTypeDef.RequestType_SignUp;
            packageModelSignUp.Msg = String.Empty;
            packageModelSignUp.Data = PackageUserInfoSignUp;
            packageModelSignUp.DataType = PackageUserInfoSignUp.GetType().FullName;
            packageModelSignUp.Success = true;
            packageModelSignUp.Code = String.Empty;
            packageModelSignUp.SendTime = DateTime.Now;

            return ClientUserSignIn.clientSocket.SendData(defaultUserInfoSignIn, packageModelSignUp);

        }
        #endregion

        #region 接收注册response
        private void _onSignUpRecv(object sender, PackageModel package)
        {
            IsSuccessSignUpResponse = false;

            if (package.PackageType == PackageModel.PackageTypeDef.ResponseType_SignUp && package.Success)
            {
                IsSuccessSignUpResponse = true;
            }
        }

        private bool SignUpRecv(UserInfoSignIn defaultUser)
        {
            ClientUserSignIn.clientSocket.RecvData(defaultUser);
            return true;
        }
        #endregion
    }
}
