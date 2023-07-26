using ChatModel;
using Server.Communication;
using Server.DAL.MySQLService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public SvrUserSignUp(ref UserInfoSignIn user)
        {
            user.UserID = -1;
            user.UserName = "default";
            user.UserPwd = null;
            user.LoginTime = DateTime.Now;

            //user.connectedEvent += _onConnectSvrEvent;
            //user.recvEvent += _onSignUpRecvEvent;
            //user.sendEvent += _onSignUpSendEvent;
        }

        /// <summary>
        /// 根据收到的数据包进行SignUp操作
        /// </summary>
        /// <param name="packageRequestSignUp"></param>
        /// <returns></returns>
        public bool DoSignUp(ref UserInfoSignIn user, PackageModel packageRequestSignUp)
        {
            UserInfoSignUp userSignUp = new UserInfoSignUp();

            if (packageRequestSignUp.Data is UserInfoSignUp)
            {
                userSignUp = packageRequestSignUp.Data as UserInfoSignUp;
                DateTime sendTime = packageRequestSignUp.SendTime;
            }
            userSignUp.SignUpTime = DateTime.Now;

            //写入DB
            UserInfoSignUpServiceMySQL userInfoSignUpServiceMySQL = new UserInfoSignUpServiceMySQL();
            //Task<int> taskInsertMysqlSignUp = Task<int>.Run(()=> userInfoSignUpServiceMySQL.InsUserInfoSignUp(userSignUp));
            //int operCounts = taskInsertMysqlSignUp.Result;
            int operCounts = userInfoSignUpServiceMySQL.InsUserInfoSignUp(userSignUp);

            if (operCounts != 1)
            {
                return false;
            }
            else
            {
                //若成功写入数据库，将数据echo回客户端
                PackageModel packageResponseSignUp = new PackageModel();
                packageResponseSignUp.PackageType = PackageModel.PackageTypeDef.ResponseType_SignUp;
                packageResponseSignUp.Success = true;

                return StartUp.ss.SendDataClient(user, packageResponseSignUp);
            }
        }

        //注册：服务器接收数据事件处理
        private void _onSignUpRecvEvent(object sender, PackageModel package)
        {
        }

        //注册：服务器发送数据事件处理
        private void _onSignUpSendEvent(object sender, PackageModel packageModel)
        {
        }

    }
}
