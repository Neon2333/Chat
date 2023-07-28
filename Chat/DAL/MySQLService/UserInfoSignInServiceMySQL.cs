using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.DAL.MySQLHelper;
using MySql.Data.MySqlClient;
using ChatModel;


namespace Server.DAL.MySQLService
{
    public class UserInfoSignInServiceMySQL: IUserInfoSignInService
    {
        string connStr = (new dbConStr()).GetDbConStr();

        //C
        public int InsUserInfoSignIn(UserInfoSignIn uisi)
        {
            using (MySqlConnection conn = MySQLHelper.MySqlHelper.GetConnection(connStr))
            {
                string cmdText = $"INSERT INTO userinfosignin (usrName,usrPwd,clientIP,clientPort,connectTime,disConnectTime) " +
                $"Values (@_userName,@_userPwd,@_clientIP,@_clientPort,@_connectTime,@_disConncetTime);";

                MySqlParameter parameter1 = new MySqlParameter("@_userName", MySqlDbType.VarChar, 10);
                MySqlParameter parameter2 = new MySqlParameter("@_userPwd", MySqlDbType.VarChar, 10);
                MySqlParameter parameter3 = new MySqlParameter("@_clientIP", MySqlDbType.VarChar, 10);
                MySqlParameter parameter4 = new MySqlParameter("@_clientPort", MySqlDbType.Int32, 10);
                MySqlParameter parameter5 = new MySqlParameter("@_connectTime", MySqlDbType.DateTime, 10);
                MySqlParameter parameter6 = new MySqlParameter("@_disConncetTime", MySqlDbType.DateTime, 10);
                parameter1.Value = uisi.UserName;
                parameter2.Value = uisi.UserPwd;
                parameter3.Value = uisi.ClientIP;
                parameter4.Value = uisi.ClientPort;
                parameter5.Value = uisi.ConnectTime;
                parameter6.Value = uisi.DisconnectTime;

                return MySQLHelper.MySqlHelper.ExecuteNonQuery(conn, CommandType.Text, cmdText,
                    parameter1, parameter2, parameter3, parameter4, parameter5, parameter6);
            }
        }

        public int InsUserInfosSignIn(List<UserInfoSignIn> uisis)
        {
            int affectRows = 0;
            using (MySqlConnection conn = MySQLHelper.MySqlHelper.GetConnection(connStr))
            {
                string cmdText = $"INSERT INTO userinfosignin (usrID,usrName,clientIP,clientPort,connectTime,disConnectTime) " +
                $"Values (@_userId,@_userName,@_clientIP,@_clientPort,@_connectTime,@_disConncetTime);";

                MySqlParameter parameter1 = new MySqlParameter("@_userId", MySqlDbType.Int32, 10);
                MySqlParameter parameter2 = new MySqlParameter("@_userName", MySqlDbType.VarChar, 10);
                MySqlParameter parameter3 = new MySqlParameter("@_clientIP", MySqlDbType.VarChar, 10);
                MySqlParameter parameter4 = new MySqlParameter("@_clientPort", MySqlDbType.Int32, 10);
                MySqlParameter parameter5 = new MySqlParameter("@_connectTime", MySqlDbType.DateTime, 10);
                MySqlParameter parameter6 = new MySqlParameter("@_disConncetTime", MySqlDbType.DateTime, 10);

                foreach (var uisi in uisis)
                {
                    parameter1.Value = uisi.UserID;
                    parameter2.Value = uisi.UserName;
                    parameter3.Value = uisi.ClientIP;
                    parameter4.Value = uisi.ClientPort;
                    parameter5.Value = uisi.ConnectTime;
                    parameter6.Value = uisi.DisconnectTime;

                    affectRows += MySQLHelper.MySqlHelper.ExecuteNonQuery(conn, CommandType.Text, cmdText,
                        parameter1, parameter2, parameter3, parameter4, parameter5, parameter6);
                }
            }
            return affectRows;
        }

        //D
        public int DeleUserInfoSignIn(int uisiID)
        {
            using (MySqlConnection conn = MySQLHelper.MySqlHelper.GetConnection(connStr))
            {
                string cmdText = $"DELETE FROM userinfosignin WHERE usrID=@_userId;";
                MySqlParameter parameter1 = new MySqlParameter("@_userId", MySqlDbType.Int32, 10);
                parameter1.Value = uisiID;
                return MySQLHelper.MySqlHelper.ExecuteNonQuery(conn, CommandType.Text, cmdText,
                    parameter1);
            }
        }
        public int DeleUserInfosSignIn(List<int> uisiIDs)
        {
            int affectRows = 0;
            using (MySqlConnection conn = MySQLHelper.MySqlHelper.GetConnection(connStr))
            {
                string cmdText = $"DELETE FROM userinfosignin WHERE usrID=@_userId;";
                MySqlParameter parameter1 = new MySqlParameter("@_userId", MySqlDbType.Int32, 10);
                foreach(var uisiID in uisiIDs)
                {
                    parameter1.Value = uisiID;
                    affectRows += MySQLHelper.MySqlHelper.ExecuteNonQuery(conn, CommandType.Text, cmdText,
                   parameter1);
                }
                return affectRows;
            }
        }

        public int DeleUserInfoSignIn(string uisiName)
        {
            using (MySqlConnection conn = MySQLHelper.MySqlHelper.GetConnection(connStr))
            {
                string cmdText = $"DELETE FROM userinfosignin WHERE usrName=@_userName;";
                MySqlParameter parameter1 = new MySqlParameter("@_userName", MySqlDbType.VarChar, 10);
                parameter1.Value = uisiName;
                return MySQLHelper.MySqlHelper.ExecuteNonQuery(conn, CommandType.Text, cmdText,
                    parameter1);
            }
        }

        public int DeleUserInfosSignIn(List<string> uisiNames)
        {
            int affectRows = 0;
            using (MySqlConnection conn = MySQLHelper.MySqlHelper.GetConnection(connStr))
            {
                string cmdText = $"DELETE FROM userinfosignin WHERE usrName=@_userName;";
                MySqlParameter parameter1 = new MySqlParameter("@_userName", MySqlDbType.VarChar, 10);
                foreach (var uisiName in uisiNames)
                {
                    parameter1.Value = uisiName;
                    affectRows += MySQLHelper.MySqlHelper.ExecuteNonQuery(conn, CommandType.Text, cmdText,
                   parameter1);
                }
                return affectRows;
            }
        }

        //U
        public int UpdUserInfoUsrNameSignIn(int uisiID, string newUsrName)
        {
            using (MySqlConnection conn = MySQLHelper.MySqlHelper.GetConnection(connStr))
            {
                string cmdText = $"UPDATE userinfosignin SET usrName=@_userName WHERE usrID=@_userID;";
                MySqlParameter parameter1 = new MySqlParameter("@_userID", MySqlDbType.Int32, 10);
                MySqlParameter parameter2 = new MySqlParameter("@_userName", MySqlDbType.VarChar, 10);

                parameter1.Value = uisiID;
                parameter2.Value = newUsrName;

                return MySQLHelper.MySqlHelper.ExecuteNonQuery(conn, CommandType.Text, cmdText,
                    parameter1, parameter2);
            }
        }

        public int UpdUserInfosUsrNameSignIn(List<int> uisiIDs, List<string> newUsrNames)
        {
            int affectRows = 0;
            if(uisiIDs.Count == newUsrNames.Count)
            {
                using (MySqlConnection conn = MySQLHelper.MySqlHelper.GetConnection(connStr))
                {
                    string cmdText = $"UPDATE userinfosignin SET usrName=@_userName WHERE usrID=@_userID;";
                    MySqlParameter parameter1 = new MySqlParameter("@_userID", MySqlDbType.Int32, 10);
                    MySqlParameter parameter2 = new MySqlParameter("@_userName", MySqlDbType.VarChar, 10);

                    for(int i = 0; i < uisiIDs.Count; i++)
                    {
                        parameter1.Value = uisiIDs[i];
                        parameter2.Value = newUsrNames[i];
                        affectRows+= MySQLHelper.MySqlHelper.ExecuteNonQuery(conn, CommandType.Text, cmdText,
                        parameter1, parameter2);
                    }
                }
            }
            return affectRows;
        }

        public int UpdUserInfoUsrPwdSignIn(int uisiID, string newUsrPwd)
        {
            using (MySqlConnection conn = MySQLHelper.MySqlHelper.GetConnection(connStr))
            {
                string cmdText = $"UPDATE userinfosignin SET usrPwd=@_userPwd WHERE usrID=@_userID;";
                MySqlParameter parameter1 = new MySqlParameter("@_userID", MySqlDbType.Int32, 10);
                MySqlParameter parameter2 = new MySqlParameter("@_userPwd", MySqlDbType.VarChar, 10);

                parameter1.Value = uisiID;
                parameter2.Value = newUsrPwd;

                return MySQLHelper.MySqlHelper.ExecuteNonQuery(conn, CommandType.Text, cmdText,
                    parameter1, parameter2);
            }
        }

        public int UpdUserInfosUsrPwdSignIn(List<int> uisiIDs, List<string> newUsrPwds)
        {
            int affectRows = 0;
            using (MySqlConnection conn = MySQLHelper.MySqlHelper.GetConnection(connStr))
            {
                string cmdText = $"UPDATE userinfosignin SET usrPwd=@_userPwd WHERE usrID=@_userID;";
                MySqlParameter parameter1 = new MySqlParameter("@_userID", MySqlDbType.Int32, 10);
                MySqlParameter parameter2 = new MySqlParameter("@_userPwd", MySqlDbType.VarChar, 10);

                for(int i = 0; i < uisiIDs.Count; i++)
                {
                    parameter1.Value = uisiIDs[i];
                    parameter2.Value = newUsrPwds[i];
                    affectRows += MySQLHelper.MySqlHelper.ExecuteNonQuery(conn, CommandType.Text, cmdText,
                    parameter1, parameter2);
                }
                return affectRows;
            }
        }

        //R

        //DataSet有一个WriteXml方法可以直接将数据保存到xml文件：https://www.jb51.net/article/63396.htm

        public object ReadUserInfoSignIn(int uisiID)
        {
            string cmdText = string.Empty;
            cmdText += "SELECT * FROM userinfosignin" + $"WHERE usrID=@_userID;";
            MySqlParameter parameter1 = new MySqlParameter("@_userID", MySqlDbType.Int32, 10);
            parameter1.Value = uisiID;

            return MySQLHelper.MySqlHelper.ExecuteScalar(connStr, CommandType.Text, cmdText, parameter1);
        }

        public DataTable ReadUserInfoSignIn(params string[] fields)
        {
            if (fields.Length > 0)
            {
                string cmdText = string.Empty;
                foreach (var field in fields)
                {
                    cmdText = "SELECT " + field + " ";

                }
                cmdText += "FROM userinfosignin;";

                return MySQLHelper.MySqlHelper.GetDataTable(connStr, CommandType.Text, cmdText);
            }
            else
            {
                return null;
            }
        }

        public DataTable ReadUserInfoSignIn(int limit, params string[] fields)
        {
            if (fields.Length > 0)
            {
                string cmdText = string.Empty;
                foreach (var field in fields)
                {
                    cmdText = "SELECT " + field + " ";

                }
                cmdText += "FROM userinfosignin" + $"LIMIT 0,{limit}";

                return MySQLHelper.MySqlHelper.GetDataTable(connStr, CommandType.Text, cmdText);
            }
            else
            {
                return null;
            }
        }

        

    }
}
