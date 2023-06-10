using Server.UIL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DAL
{
    public interface IUserConnectInfoService
    {
        //C
        int InsUserConnectInfo(UserInfoSignIn ucinfo);

        int InsUserConnectInfos(List<UserInfoSignIn> ucinfos);

        //D
        int DeleUserConnectInfo(int ucinfoID);

        int DeleUserConnectInfo(string ucinfoName);

        int DeleUserConnectInfos(List<int> ucinfoIDs);

        int DeleUserConnectInfos(List<string> ucinfoNames);

        //U
        int UpdUserConnectInfoUsrName(int ucinfoID, string newUsrName);

        int UpdUserConnectInfosUsrName(List<int> ucinfoIDs, List<string> newUsrNames);

        int UpdUserConnectInfoUsrPwd(int ucinfoID, string newUsrPwd);

        int UpdUserConnectInfosUsrPwd(List<int> ucinfoIDs, List<string> newUsrPwds);

        //R
        DataTable ReadUserConnectInfo(params string[] fields);

        DataTable ReadUserConnectInfo(int limit, params string[] fields);

        DataTable ReadUserConnectInfo(string ucinfoID, params string[] fields);

        DataTable ReadUserConnectInfo(string ucinfoID, int limit, params string[] fields);

        DataTable ReadUserConnectInfo(string strCmd);



    }
}
