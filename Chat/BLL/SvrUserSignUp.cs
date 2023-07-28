using Server.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using ChatModel;
using Server.DAL.MySQLService;

namespace Server.BLL
{
    internal class SvrUserSignUp
    {
        #region dele
        //private static Dictionary<int, byte[]> usersRecvBuffer = new Dictionary<int, byte[]>();    //(ID,buff)
        //public Dictionary<int, byte[]> UsersRecvBuffer { get => usersRecvBuffer; set => usersRecvBuffer = value; }

        //private static Dictionary<int, byte[]> usersSendBuffer = new Dictionary<int, byte[]>();
        //public Dictionary<int, byte[]> UsersSendBuffer { get => usersSendBuffer; set => usersSendBuffer = value; }


        ///// <summary>
        ///// 用户注册
        ///// </summary>
        ///// <param name="userSignUpInfo"></param>
        ///// <returns></returns>
        //public bool SignUpUser(UIL.Model.UserSignUpInfo userSignUpInfo)
        //{
        //    try
        //    {
        //        //操作DB

        //        if (!usersRecvBuffer.ContainsKey(userSignUpInfo.UserID))
        //        {
        //            usersRecvBuffer.Add(userSignUpInfo.UserID, new byte[recvBuffSize]);
        //        }
        //        else
        //        {

        //        }

        //        if (!usersSendBuffer.ContainsKey(userSignUpInfo.UserID))
        //        {
        //            usersSendBuffer.Add(userSignUpInfo.UserID, new byte[sendBuffSize]);
        //        }
        //        else
        //        {

        //        }
        //        return true;
        //    }
        //    catch(Exception ex)
        //    {
        //        return false;
        //    }

        //}

        ///// <summary>
        ///// 删除用户
        ///// </summary>
        ///// <param name="userSignUpInfo"></param>
        ///// <returns></returns>
        //public bool DelUser(UIL.Model.UserSignUpInfo userSignUpInfo)
        //{
        //    //操作DB

        //    if (!usersRecvBuffer.ContainsKey(userSignUpInfo.UserID))
        //    {
        //        usersRecvBuffer.Remove(userSignUpInfo.UserID);
        //    }
        //    else
        //    {

        //    }

        //    if (!usersSendBuffer.ContainsKey(userSignUpInfo.UserID))
        //    {
        //        usersSendBuffer.Remove(userSignUpInfo.UserID);
        //    }
        //    else
        //    {

        //    }

        //    return true;
        //}
        #endregion

        public SvrUserSignUp() { }

        public SvrUserSignUp(UserInfoSignIn user)
        {
            //user.connectedEvent += _onConnectSvrEvent;
            //user.recvEvent += _onSignUpRecvEvent;
            //user.sendEvent += _onSignUpSendEvent;
        }

        /// <summary>
        /// 根据收到的数据包进行SignUp操作
        /// </summary>
        /// <param name="packageRequestSignUp"></param>
        /// <returns></returns>
        public bool DoSignUp(Socket clientConnSocket, PackageModel packageRequestSignUp)
        {
            try
            {
                //打包实体类
                UserInfoSignUp packageUserSignUp = new UserInfoSignUp();
                if (packageRequestSignUp.Data is UserInfoSignUp)
                {
                    packageUserSignUp = packageRequestSignUp.Data as UserInfoSignUp;
                }
                packageUserSignUp.SignUpTime = DateTime.Now;   //注册时间

                //写入DB
                UserInfoSignUpServiceMySQL userInfoSignUpServiceMySQL = new UserInfoSignUpServiceMySQL();
                //Task<int> taskInsertMysqlSignUp = Task<int>.Run(()=> userInfoSignUpServiceMySQL.InsUserInfoSignUp(userSignUp));
                //int operCounts = taskInsertMysqlSignUp.Result;
                int operCounts = userInfoSignUpServiceMySQL.InsUserInfoSignUp(packageUserSignUp);

                if (operCounts != 1)
                {
                    //写入DB失败
                    return false;
                }
                else
                {
                    //成功写入数据库，将数据echo回客户端（这里只返回2个参数，可根据需要返回其他数据）
                    PackageModel packageResponseSignUp = new PackageModel();
                    packageResponseSignUp.PackageType = PackageModel.PackageTypeDef.ResponseType_SignUp;
                    packageResponseSignUp.Success = true;


                    Console.WriteLine($"{packageUserSignUp.UserName} SignUp succeed..");

                    return StartUp.ss.SendDataClient(clientConnSocket, packageResponseSignUp);
                }
            }
            catch (NullReferenceException ex)
            {
                return false;
            }
            catch (ArgumentNullException ex)
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

        //服务器接收注册数据事件处理
        private void _onSignUpRecvEvent(object sender, PackageModel package)
        {
        }

        //服务器发送注册数据事件处理
        private void _onSignUpSendEvent(object sender, PackageModel packageModel)
        {
        }

    }
}
