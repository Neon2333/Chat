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

        public bool DoSignUp(PackageModel package)
        {
            UserInfoSignUp userSignUp = new UserInfoSignUp();
            Type dataType = Type.GetType("Server." + package.DataType);

            if (package.Data is UserInfoSignUp)
            {
                userSignUp = package.Data as UserInfoSignUp;
                DateTime sendTime = package.SendTime;

            }
            userSignUp.SignUpTime = DateTime.Now;

            UserInfoSignUpServiceMySQL userInfoSignUpServiceMySQL = new UserInfoSignUpServiceMySQL();
            int operCounts = userInfoSignUpServiceMySQL.InsUserInfoSignUp(userSignUp);

            if(operCounts != 1)
            {
                return false;
            }
            else
            {
                PackageModel packageRespSignUp = new PackageModel();
                packageRespSignUp.PackageType = PackageModel.PackageTypeDef.ResponseType_SignUp;
                packageRespSignUp.Success = true;

                return true;
            }
        }



    }
}
