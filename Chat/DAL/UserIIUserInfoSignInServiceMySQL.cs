using Server.UIL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.DAL.MySQLHelper;
using MySql.Data.MySqlClient;

namespace Server.DAL
{
    public class UserIIUserInfoSignInServiceMySQL: IUserConnectInfoService
    {
        string connStr = (new dbConStr()).GetDbConStr();
        //C
        public int InsUserConnectInfo(UserInfoSignIn ucinfo)
        {
            using (MySqlConnection conn = MySQLHelper.MySqlHelper.GetConnection(connStr))
            {
                string cmdText = $"INSERT INTO userinfosignin (usrID,usrName,clientIP,clientPort,connectTime,disConnectTime) " +
                $"Values (@_userId,@_userName,@_clientIP,@_clientPort,@_connectTime,@_disConncetTime)"

                MySqlParameter parameter1 = new MySqlParameter("@_userId", MySqlDbType.Int32, 10);
                MySqlParameter parameter2 = new MySqlParameter("@_userId", MySqlDbType.Int32, 10);
                MySqlParameter parameter3 = new MySqlParameter("@_userId", MySqlDbType.Int32, 10);
                MySqlParameter parameter4 = new MySqlParameter("@_userId", MySqlDbType.Int32, 10);
                MySqlParameter parameter5 = new MySqlParameter("@_userId", MySqlDbType.Int32, 10);
                MySqlParameter parameter6 = new MySqlParameter("@_userId", MySqlDbType.Int32, 10);
                parameter1.Value = ucinfo.UserID;
                parameter2.Value = ucinfo.UserName;
                parameter3.Value = ucinfo.ClientIP;
                parameter4.Value = ucinfo.ClientPort;
                parameter5.Value = ucinfo.ConnectTime;
                parameter6.Value = ucinfo.DisconnectTime;

                return MySQLHelper.MySqlHelper.ExecuteNonQuery(conn, CommandType.Text, cmdText,
                    parameter1, parameter2, parameter3, parameter4, parameter5, parameter6);
            }
        }

        public int InsUserConnectInfos(List<UserInfoSignIn> ucinfos)
        {
            int affectRows = 0;
            using (MySqlConnection conn = MySQLHelper.MySqlHelper.GetConnection(connStr))
            {
                string cmdText = $"INSERT INTO userinfosignin (usrID,usrName,clientIP,clientPort,connectTime,disConnectTime) " +
                $"Values (@_userId,@_userName,@_clientIP,@_clientPort,@_connectTime,@_disConncetTime)"

                MySqlParameter parameter1 = new MySqlParameter("@_userId", MySqlDbType.Int32, 10);
                MySqlParameter parameter2 = new MySqlParameter("@_userId", MySqlDbType.Int32, 10);
                MySqlParameter parameter3 = new MySqlParameter("@_userId", MySqlDbType.Int32, 10);
                MySqlParameter parameter4 = new MySqlParameter("@_userId", MySqlDbType.Int32, 10);
                MySqlParameter parameter5 = new MySqlParameter("@_userId", MySqlDbType.Int32, 10);
                MySqlParameter parameter6 = new MySqlParameter("@_userId", MySqlDbType.Int32, 10);
                
                foreach(var ucinfo in ucinfos)
                {
                    parameter1.Value = ucinfo.UserID;
                    parameter2.Value = ucinfo.UserName;
                    parameter3.Value = ucinfo.ClientIP;
                    parameter4.Value = ucinfo.ClientPort;
                    parameter5.Value = ucinfo.ConnectTime;
                    parameter6.Value = ucinfo.DisconnectTime;

                    affectRows += MySQLHelper.MySqlHelper.ExecuteNonQuery(conn, CommandType.Text, cmdText,
                        parameter1, parameter2, parameter3, parameter4, parameter5, parameter6);
                }
            }
            return affectRows;
        }

        //D
        public int DeleUserConnectInfo(int ucinfoID)
        {

        }

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
