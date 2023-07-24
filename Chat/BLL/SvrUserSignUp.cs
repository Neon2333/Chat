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

        public SvrUserSignUp()
        {
        }

        public bool DoSignUp(ClientSocket ss, UserInfoSignIn defaultUser, PackageModel packageRequestSignUp)
        {
            UserInfoSignUp userSignUp = new UserInfoSignUp();

            if (packageRequestSignUp.Data is UserInfoSignUp)
            {
                userSignUp = packageRequestSignUp.Data as UserInfoSignUp;
                DateTime sendTime = packageRequestSignUp.SendTime;

            }
            userSignUp.SignUpTime = DateTime.Now;

            UserInfoSignUpServiceMySQL userInfoSignUpServiceMySQL = new UserInfoSignUpServiceMySQL();

            Task<int> taskInsertMysqlSignUp = Task<int>.Run(()=> userInfoSignUpServiceMySQL.InsUserInfoSignUp(userSignUp));
            int operCounts = taskInsertMysqlSignUp.Result;
            //int operCounts = userInfoSignUpServiceMySQL.InsUserInfoSignUp(userSignUp);

            if(operCounts != 1)
            {
                return false;
            }
            else
            {
                PackageModel packageResponseSignUp = new PackageModel();
                packageResponseSignUp.PackageType = PackageModel.PackageTypeDef.ResponseType_SignUp;
                packageResponseSignUp.Success = true;

                return ss.SendDataClient(defaultUser, packageResponseSignUp);


            }
        }



    }
}
