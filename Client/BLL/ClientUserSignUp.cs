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
            UserInfoSignUp = new UserInfoSignUp();
            UserInfoSignUp.UserName = usrName;
            UserInfoSignUp.UserPwd = usrPwd;

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
            return ClientUserSignIn.clientSocket.SendData(packageModelSignUp);
        }

    }
}
