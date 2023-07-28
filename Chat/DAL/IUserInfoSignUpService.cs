using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatModel;


namespace Server.DAL
{
    public interface IUserInfoSignUpService
    {
        //C
        int InsUserInfoSignUp(UserInfoSignUp uisu);

        int InsUserInfosSignUp(List<UserInfoSignUp> uisus);

        //D
        int DeleUserInfoSignUp(int uisuID);

        int DeleUserInfosSignUp(List<int> uisuIDs);

        int DeleUserInfoSignUp(string uisuName);

        int DeleUserInfosSignUp(List<string> uisuNames);

        //U
        int UpdUserInfoUserNameSignUp(int uisuID, string newUserName);

        int UpdUserInfosUserNameSignUp(List<int> uisuIDs, List<string> newUsrNames);


        int UpdUserInfoUsrPwdSignUp(int uisuID, string newUsrPwd);

        int UpdUserInfosUsrPwdSignUp(List<int> uisuIDs, List<string> newUsrPwds);

        //R
        DataTable ReadUserInfoSignUp(params string[] fields);

        object ReadUserInfoSignUp(int uisuID, params string[] fields);

    }
}
