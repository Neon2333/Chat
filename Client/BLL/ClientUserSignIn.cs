using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using ChatModel;
using Client.Communication;
using System.Data;
using System.Drawing;

namespace Client.BLL
{
    /// <summary>
    /// 客户端登录类
    /// </summary>
    public class ClientUserSignIn
    {
        //通信类实例
        public static ClientSocket clientSocket = new ClientSocket();    
        //默认用户                                                                 
        public static UserInfoSignIn defaultUserSignIn;    

        //打包登录用户信息
        public UserInfoSignIn packageUserSignIn;

        //是否接收到服务器的登录成功response
        public bool IsSuccessSignInResponse;               
        
        //是否成功登录
        private bool isLogin = false;                        
        public bool IsLogin { get => isLogin; set => isLogin = value; }

        //在线用户列表
        private static DataTable userSignInList = new DataTable();   
        public static DataTable UserSignInList { get => userSignInList; set => userSignInList = value; }

        public ClientUserSignIn()
        {
            //初始化defaultUser
            ClientUserSignIn.defaultUserSignIn = new UserInfoSignIn();
            ClientUserSignIn.defaultUserSignIn.UserID = -1;
            ClientUserSignIn.defaultUserSignIn.UserName = "default";
            ClientUserSignIn.defaultUserSignIn.UserPwd = null;
            ClientUserSignIn.defaultUserSignIn.ClientConnectSocket = ClientSocket.ConnectSvrSocket;
            ClientUserSignIn.defaultUserSignIn.CancelSendToken = ClientUserSignIn.defaultUserSignIn.CancelSendSource.Token;
            ClientUserSignIn.defaultUserSignIn.recvEvent += _onRecvEvent;
            ClientUserSignIn.defaultUserSignIn.sendEvent += _onSendEvent;

            //初始化在线用户列表
            ClientUserSignIn.UserSignInList.Columns.Add("usrID", typeof(String));
            ClientUserSignIn.UserSignInList.Columns.Add("usrName", typeof(String));
            ClientUserSignIn.UserSignInList.Columns.Add("usrPortrait", typeof(Image));

        }

        /// <summary>
        /// 执行登录过程
        /// </summary>
        /// <param name="usrName"></param>
        /// <param name="usrPwd"></param>
        public bool DoSignIn(string usrName, string usrPwd, int timeoutMill)
        {
            try
            {
                bool flagSendTaskCompleted = false;
                Task<bool> sendTask = Task.Run(() =>
                {
                    return SignInSend(usrName, usrPwd);
                });

                flagSendTaskCompleted = sendTask.Wait(timeoutMill, ClientUserSignIn.defaultUserSignIn.CancelSendToken);  //Wait在timeout内完成task返回Task。否则false，但线程还会继续执行
                if (!flagSendTaskCompleted)
                {
                    return false;
                }

                Task recvTask = Task.Run(() => {
                    SignInRecv(ClientUserSignIn.defaultUserSignIn);
                });

                //return recvTask.Wait(timeoutMill, ClientUserSignIn.defaultUserSignIn.CancelRecvToken) && IsSuccessSignUpResponse;
                if (recvTask.Wait(timeoutMill, ClientUserSignIn.defaultUserSignIn.CancelRecvToken))
                {
                    if (IsSuccessSignInResponse)
                    {
                        defaultUserSignIn.UserName = usrName;
                        defaultUserSignIn.UserPwd = usrPwd;
                        defaultUserSignIn.LoginTime = DateTime.Now;     //登录上的时间

                        return true;
                    }
                }
                return false;
            }
            catch (NullReferenceException ex)
            {
                return false;
            }
            catch(ArgumentNullException ex)
            {
                return false;
            }
            catch (SocketException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }

        }



        /// <summary>
        /// 发送登录数据包
        /// </summary>
        /// <param name="usrName"></param>
        /// <param name="usrPwd"></param>
        /// <returns></returns>
        public bool SignInSend(string usrName, string usrPwd)
        {
            //创建实体类
            packageUserSignIn = new UserInfoSignIn();
            packageUserSignIn.UserName = usrName;
            packageUserSignIn.UserPwd = Encrypt.MD5Encrypt.EncryptMD5(usrPwd);

            //打包实体类
            PackageModel packageModelSignIn = new PackageModel();
            packageModelSignIn.PackageType = PackageModel.PackageTypeDef.RequestType_SignUp;
            packageModelSignIn.Msg = String.Empty;
            packageModelSignIn.Data = packageModelSignIn;
            packageModelSignIn.DataType = packageModelSignIn.GetType().FullName;
            packageModelSignIn.Success = true;
            packageModelSignIn.Code = String.Empty;
            packageModelSignIn.SendTime = DateTime.Now;

            return ClientUserSignIn.clientSocket.SendData(ClientUserSignIn.defaultUserSignIn, packageModelSignIn);
        }

        //登录发送数据事件
        private void _onSignInSend(object sender, PackageModel package)
        {
        }

        /// <summary>
        /// 接收登录response
        /// </summary>
        /// <param name="defaultUser"></param>
        private void SignInRecv(UserInfoSignIn defaultUserSignIn)
        {
            ClientUserSignIn.clientSocket.RecvData(defaultUserSignIn);
        }

        //登录接收数据事件
        private void _onSignInRecv(object sender, PackageModel package)
        {
            IsSuccessSignInResponse = false;

            if (package.Success)
            {
                //登录成功标志置为true
                IsSuccessSignInResponse = true;

                //解析返回包，提取在线用户信息

            }

        }

        /// <summary>
        /// 接收数据事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="package"></param>
        private void _onRecvEvent(object sender, PackageModel package)
        {
            if (package.PackageType == PackageModel.PackageTypeDef.ResponseType_SignUp)
            {
                //调用注册接收函数
                ClientUserSignUp. _onSignUpRecv(sender, package);   
            }
            else if(package.PackageType == PackageModel.PackageTypeDef.ResponseType_SignIn)
            {
                //调用登录接收函数
                _onSignInRecv(sender, package);
            }
            else if (package.PackageType == PackageModel.PackageTypeDef.ResponseType_UpdateClientList)
            {
                //接收服务器的在线用户列表更新
                DataTable dtClientList = package.Data as DataTable;

                //for(int i = 0; i < dtClientList.Rows.Count; i++)
                //{
                //    DataRow dr = userSignInList.NewRow();
                //    dr["usrID"] =
                //    dr["usrName"] =
                //    dr["usrPortrait"] =
                //    userSignInList.Rows.Add()
                //}
                userSignInList = dtClientList.Copy();
            }
            else if(package.PackageType == PackageModel.PackageTypeDef.ChatMessageType)
            {
            }
        }

        /// <summary>
        /// 发送数据事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="package"></param>
        private void _onSendEvent(object sender, PackageModel package)
        {
            if (package.PackageType == PackageModel.PackageTypeDef.RequestType_SignUp)
            {
                //调用注册发送函数
                ClientUserSignUp._onSignUpSend(sender, package);
            }
            else if(package.PackageType == PackageModel.PackageTypeDef.RequestType_SignIn)
            {
                //调用注册接收函数
                _onSignInSend(sender, package);
            }
            else if(package.PackageType == PackageModel.PackageTypeDef.RequestType_UpdateClientList)
            {
                //客户端向服务器请求更新在线用户列表
            }
            else if(package.PackageType == PackageModel.PackageTypeDef.ChatMessageType)
            {
            }
        }

    }
}
