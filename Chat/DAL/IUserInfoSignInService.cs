using Server.UIL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DAL
{
    public interface IUserInfoSignInService
    {
        //C
        int InsUserInfoSignIn(UserInfoSignIn uisi);

        int InsUserInfosSignIn(List<UserInfoSignIn> uisis);

        //D
        int DeleUserInfoSignIn(int uisiID);

        int DeleUserInfosSignIn(List<int> uisiIDs);

        int DeleUserInfoSignIn(string uisiName);

        int DeleUserInfosSignIn(List<string> uisiNames);

        //U
        int UpdUserInfoUsrNameSignIn(int uisiID, string newUsrName);

        int UpdUserInfosUsrNameSignIn(List<int> uisiIDs, List<string> newUsrNames);

        int UpdUserInfoUsrPwdSignIn(int uisiID, string newUsrPwd);

        int UpdUserInfosUsrPwdSignIn(List<int> uisiIDs, List<string> newUsrPwds);

        //R
        DataTable ReadUserInfoSignIn(params string[] fields);

        DataTable ReadUserInfoSignIn(int limit, params string[] fields);

        object ReadUserInfoSignIn(string uisiID, params string[] fields);



    }
}
