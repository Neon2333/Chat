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
        public static UserInfoSignUp UserInfoSignUp;

        public static bool SignUp(string usrName, string usrPwd)
        {
            #region 发送注册数据包
            //创建实体类
            UserInfoSignUp = new UserInfoSignUp();
            UserInfoSignUp.UserName = usrName;
            UserInfoSignUp.UserPwd = Encrypt.MD5Encrypt.EncryptMD5(usrPwd); //pwd加密

            //打包实体类
            PackageModel packageModelSignUp = new PackageModel();
            packageModelSignUp.PackageType = PackageModel.PackageTypeDef.RequestType_C;
            packageModelSignUp.Msg = String.Empty;
            packageModelSignUp.Data = UserInfoSignUp;
            packageModelSignUp.DataType = UserInfoSignUp.GetType().Name;
            packageModelSignUp.Success = true;
            packageModelSignUp.Code = String.Empty;
            packageModelSignUp.SendTime = DateTime.Now;
            
            //if (!ClientUserSignIn.clientSocket.ConnectSvr())
            //{
            //    return false;
            //}

            //Task<bool> sendTask = Task.Run(() => clientSocket.SendData(packageModelSignUp));
            //return sendTask.Result;

            bool flagSendSignUp = ClientUserSignIn.clientSocket.SendData(packageModelSignUp);
            #endregion
        }

    }
}
