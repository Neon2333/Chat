using Server.UIL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DAL
{
    public class UserSignUpInfoServiceMySQL: IUserSignUpInfoService
    {
        //C
        public int InsUserConnectInfo(UserConnectInfo ucinfo)
        {

        }

        public int InsUserConnectInfos(List<UserConnectInfo> ucinfos);

        //D
        public int DeleUserConnectInfo(int ucinfoID);

        public int DeleUserConnectInfo(string ucinfoName);

        public int DeleUserConnectInfos(List<int> ucinfoIDs);

        public int DeleUserConnectInfos(List<string> ucinfoNames);

        //U
        public int UpdUserConnectInfoUsrName(int ucinfoID, string newUsrName);

        public int UpdUserConnectInfosUsrName(List<int> ucinfoIDs, List<string> newUsrNames);

        public int UpdUserConnectInfoUsrPwd(int ucinfoID, string newUsrPwd);

        public int UpdUserConnectInfosUsrPwd(List<int> ucinfoIDs, List<string> newUsrPwds);

        //R
        public DataTable ReadUserConnectInfo(params string[] fields);

        public DataTable ReadUserConnectInfo(int limit, params string[] fields);

        public DataTable ReadUserConnectInfo(string ucinfoID, params string[] fields);

        public DataTable ReadUserConnectInfo(string ucinfoID, int limit, params string[] fields);

        public DataTable ReadUserConnectInfo(string strCmd);
    }
}
