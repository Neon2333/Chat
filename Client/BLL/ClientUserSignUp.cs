using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.UIL;
using System.Net.Sockets;
using ChatModel;
using Client.Communication;

namespace Client.BLL
{
    /// <summary>
    /// 客户端注册类
    /// </summary>
    class ClientUserSignUp
    {
        public UserInfoSignUp PackageUserSignUp;            //打包注册用户信息
        public static bool IsSuccessSignUpResponse;        //是否收到服务器注册成功response

        public ClientUserSignUp()
        {
            
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
                //List<Task> doSignUpTasks = new List<Task>();

                //需要先Send再Recv
                bool flagSendTaskCompleted = false;
                Task<bool> sendTask = Task.Run(() =>
                {
                    return SignUpSend(usrName, usrPwd);
                });

                flagSendTaskCompleted = sendTask.Wait(timeoutMill, ClientUserSignIn.defaultUserSignIn.CancelSendToken);  //Wait在timeout内完成task返回Task。否则false，但线程还会继续执行
                if (!flagSendTaskCompleted)
                {
                    return false;
                }

                Task recvTask = Task.Run(() => {
                    SignUpRecv(ClientUserSignIn.defaultUserSignIn);
                });

                //return recvTask.Wait(timeoutMill, ClientUserSignIn.defaultUserSignIn.CancelRecvToken) && IsSuccessSignUpResponse;
                if(recvTask.Wait(timeoutMill, ClientUserSignIn.defaultUserSignIn.CancelRecvToken))
                {
                    if (IsSuccessSignUpResponse)
                    {
                        return true;
                    }
                }
                return false;
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

            return ClientUserSignIn.clientSocket.SendData(ClientUserSignIn.defaultUserSignIn, packageModelSignUp);

        }

        //注册发送数据事件
        public static void _onSignUpSend(object sender, PackageModel package)
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
        public static void _onSignUpRecv(object sender, PackageModel package)
        {
            IsSuccessSignUpResponse = false;

            if (package.Success)
            {
                IsSuccessSignUpResponse = true;
            }

            //if (package.Success && package.PackageType == PackageModel.PackageTypeDef.ResponseType_SignUp)
            //{
            //    IsSuccessSignUpResponse = true;
            //}
        }

    }
}
