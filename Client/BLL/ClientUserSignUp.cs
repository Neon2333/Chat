using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.UIL;
using ChatModel;
using Client.Communication;
using System.Net.Sockets;

namespace Client.BLL
{
    class ClientUserSignUp
    {
        public UserInfoSignIn defaultUserSignIn;
        public UserInfoSignUp PackageUserSignUp;
        public bool IsSuccessSignUpResponse;

        public ClientUserSignUp()
        {
            defaultUserSignIn = new UserInfoSignIn();
            defaultUserSignIn.UserID = -1;
            defaultUserSignIn.UserName = "default";
            defaultUserSignIn.UserPwd = null;
            defaultUserSignIn.LoginTime = DateTime.Now;
            defaultUserSignIn.ClientConnectSocket = ClientSocket.ConnectSvrSocket;
            defaultUserSignIn.CancelSendToken = defaultUserSignIn.CancelSendSource.Token;
            defaultUserSignIn.recvEvent += _onSignUpRecv;
            defaultUserSignIn.sendEvent += _onSignUpSend;
        }

        /// <summary>
        /// 执行注册过程
        /// </summary>
        /// <param name="usrName"></param>
        /// <param name="usrPwd"></param>
        /// <param name="timeoutMill"></param>
        /// <returns></returns>
        public bool DoSignUp(string usrName, string usrPwd, int timeoutMill)
        {
            try
            {
                List<Task> doSignUpTasks = new List<Task>();
                //需要先Send再Recv

                bool flagSendTaskCompleted = false;
                Task<bool> sendTask = Task.Run(() =>
                {
                    return SignUpSend(usrName, usrPwd);
                });

                flagSendTaskCompleted = sendTask.Wait(timeoutMill, defaultUserSignIn.CancelSendToken);  //Wait在timeout内完成task返回Task。否则false，但线程还会继续执行
                if (!flagSendTaskCompleted)
                {
                    return false;
                }

                Task recvTask = Task.Run(() => {
                    SignUpRecv(defaultUserSignIn);
                });

                return recvTask.Wait(timeoutMill, defaultUserSignIn.CancelRecvToken);
            }
            catch(NullReferenceException ex)
            {
                return false;
            }
            catch(SocketException ex)
            {
                return false;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }



        /// <summary>
        /// 发送注册数据包
        /// </summary>
        /// <param name="usrName"></param>
        /// <param name="usrPwd"></param>
        /// <returns></returns>
        private bool SignUpSend(string usrName, string usrPwd)
        {
            //创建实体类
            PackageUserSignUp = new UserInfoSignUp();
            PackageUserSignUp.UserName = usrName;
            PackageUserSignUp.UserPwd = Encrypt.MD5Encrypt.EncryptMD5(usrPwd); //pwd加密

            //打包实体类
            PackageModel packageModelSignUp = new PackageModel();
            packageModelSignUp.PackageType = PackageModel.PackageTypeDef.RequestType_SignUp;
            packageModelSignUp.Msg = String.Empty;
            packageModelSignUp.Data = PackageUserSignUp;
            packageModelSignUp.DataType = PackageUserSignUp.GetType().FullName;
            packageModelSignUp.Success = true;
            packageModelSignUp.Code = String.Empty;
            packageModelSignUp.SendTime = DateTime.Now;

            return ClientUserSignIn.clientSocket.SendData(defaultUserSignIn, packageModelSignUp);

        }

        //注册发送数据事件
        private void _onSignUpSend(object sender, PackageModel package)
        {
        }



        /// <summary>
        /// 接收注册response
        /// </summary>
        /// <param name="defaultUser"></param>
        private void SignUpRecv(UserInfoSignIn defaultUser)
        {
            ClientUserSignIn.clientSocket.RecvData(defaultUser);
        }
        
        //注册接收数据事件
        private void _onSignUpRecv(object sender, PackageModel package)
        {
            IsSuccessSignUpResponse = false;

            if (package.PackageType == PackageModel.PackageTypeDef.ResponseType_SignUp && package.Success)
            {
                IsSuccessSignUpResponse = true;
            }
        }



     
    }
}
