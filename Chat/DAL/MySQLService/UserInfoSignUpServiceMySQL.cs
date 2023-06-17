using MySql.Data.MySqlClient;
using Server.UIL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DAL.MySQLService
{
    public class UserInfoSignUpServiceMySQL: IUserInfoSignUpService
    {
        string connStr = (new dbConStr()).GetDbConStr();
        //C
        public int InsUserInfoSignUp(UserInfoSignUp uisu)
        {
            using (MySqlConnection conn = MySQLHelper.MySqlHelper.GetConnection(connStr))
            {
                string cmdText = $"INSERT INTO userinfosignup (usrID,usrName,usrPwd,signUpTime,clientIP,clientPort,connectTime,disConnectTime) " +
                $"Values (@_userId,@_userName,@_userPwd,@_signupTime);";

                MySqlParameter parameter1 = new MySqlParameter("@_userId", MySqlDbType.Int32, 10);
                MySqlParameter parameter2 = new MySqlParameter("@_userName", MySqlDbType.VarChar, 10);
                MySqlParameter parameter3 = new MySqlParameter("@_userPwd", MySqlDbType.VarChar, 10);
                MySqlParameter parameter4 = new MySqlParameter("@_signupTime", MySqlDbType.DateTime, 10);
                parameter1.Value = uisu.UserID;
                parameter2.Value = uisu.UserName;
                parameter3.Value = uisu.UserPwd;
                parameter4.Value = uisu.SignUpTime;

                return MySQLHelper.MySqlHelper.ExecuteNonQuery(conn, CommandType.Text, cmdText,
                    parameter1, parameter2, parameter3, parameter4);
            }
        }

        public int InsUserInfosSignUp(List<UserInfoSignUp> uisus)
        {
            int affectRows = 0;
            using (MySqlConnection conn = MySQLHelper.MySqlHelper.GetConnection(connStr))
            {
                string cmdText = $"INSERT INTO userinfosignup (usrID,usrName,usrPwd,signUpTime,clientIP,clientPort,connectTime,disConnectTime) " +
               $"Values (@_userId,@_userName,@_userPwd,@_signupTime);";

                MySqlParameter parameter1 = new MySqlParameter("@_userId", MySqlDbType.Int32, 10);
                MySqlParameter parameter2 = new MySqlParameter("@_userName", MySqlDbType.VarChar, 10);
                MySqlParameter parameter3 = new MySqlParameter("@_userPwd", MySqlDbType.VarChar, 10);
                MySqlParameter parameter4 = new MySqlParameter("@_signupTime", MySqlDbType.DateTime, 10);

                foreach (var uisu in uisus)
                {
                    parameter1.Value = uisu.UserID;
                    parameter2.Value = uisu.UserName;
                    parameter3.Value = uisu.UserPwd;
                    parameter4.Value = uisu.SignUpTime;

                    affectRows += MySQLHelper.MySqlHelper.ExecuteNonQuery(conn, CommandType.Text, cmdText,
                        parameter1, parameter2, parameter3, parameter4);
                }
            }
            return affectRows;
        }

        //D
        public int DeleUserInfoSignUp(int uisuID)
        {
            using (MySqlConnection conn = MySQLHelper.MySqlHelper.GetConnection(connStr))
            {
                string cmdText = $"DELETE FROM userinfosignup WHERE usrID=@_userId;";
                MySqlParameter parameter1 = new MySqlParameter("@_userId", MySqlDbType.Int32, 10);
                parameter1.Value = uisuID;
                return MySQLHelper.MySqlHelper.ExecuteNonQuery(conn, CommandType.Text, cmdText,
                    parameter1);
            }
        }

        public int DeleUserInfosSignUp(List<int> uisuIDs)
        {
            int affectRows = 0;
            using (MySqlConnection conn = MySQLHelper.MySqlHelper.GetConnection(connStr))
            {
                string cmdText = $"DELETE FROM userinfosignup WHERE usrID=@_userId;";
                MySqlParameter parameter1 = new MySqlParameter("@_userId", MySqlDbType.Int32, 10);
                foreach (var uisuID in uisuIDs)
                {
                    parameter1.Value = uisuID;
                    affectRows += MySQLHelper.MySqlHelper.ExecuteNonQuery(conn, CommandType.Text, cmdText,
                   parameter1);
                }
                return affectRows;
            }
        }

        public int DeleUserInfoSignUp(string uisuName)
        {
            using (MySqlConnection conn = MySQLHelper.MySqlHelper.GetConnection(connStr))
            {
                string cmdText = $"DELETE FROM userinfosignup WHERE usrName=@_userName;";
                MySqlParameter parameter1 = new MySqlParameter("@_userName", MySqlDbType.VarChar, 10);
                parameter1.Value = uisuName;
                return MySQLHelper.MySqlHelper.ExecuteNonQuery(conn, CommandType.Text, cmdText,
                    parameter1);
            }
        }

        public int DeleUserInfosSignUp(List<string> uisuNames)
        {
            int affectRows = 0;
            using (MySqlConnection conn = MySQLHelper.MySqlHelper.GetConnection(connStr))
            {
                string cmdText = $"DELETE FROM userinfosignup WHERE usrName=@_userName;";
                MySqlParameter parameter1 = new MySqlParameter("@_userName", MySqlDbType.VarChar, 10);
                foreach (var uisuName in uisuNames)
                {
                    parameter1.Value = uisuName;
                    affectRows += MySQLHelper.MySqlHelper.ExecuteNonQuery(conn, CommandType.Text, cmdText,
                   parameter1);
                }
                return affectRows;
            }
        }

        //U
        public int UpdUserInfoUserNameSignUp(int uisuID, string newUserName)
        {
            using (MySqlConnection conn = MySQLHelper.MySqlHelper.GetConnection(connStr))
            {
                string cmdText = $"UPDATE userinfosignup SET usrName=@_userName WHERE usrID=@_userID;";
                MySqlParameter parameter1 = new MySqlParameter("@_userID", MySqlDbType.Int32, 10);
                MySqlParameter parameter2 = new MySqlParameter("@_userName", MySqlDbType.VarChar, 10);

                parameter1.Value = uisuID;
                parameter2.Value = newUserName;

                return MySQLHelper.MySqlHelper.ExecuteNonQuery(conn, CommandType.Text, cmdText,
                    parameter1, parameter2);
            }
        }

        public int UpdUserInfosUserNameSignUp(List<int> uisuIDs, List<string> newUsrNames)
        {
            int affectRows = 0;
            if (uisuIDs.Count == newUsrNames.Count)
            {
                using (MySqlConnection conn = MySQLHelper.MySqlHelper.GetConnection(connStr))
                {
                    string cmdText = $"UPDATE userinfosignup SET usrName=@_userName WHERE usrID=@_userID;";
                    MySqlParameter parameter1 = new MySqlParameter("@_userID", MySqlDbType.Int32, 10);
                    MySqlParameter parameter2 = new MySqlParameter("@_userName", MySqlDbType.VarChar, 10);

                    for (int i = 0; i < uisuIDs.Count; i++)
                    {
                        parameter1.Value = uisuIDs[i];
                        parameter2.Value = newUsrNames[i];
                        affectRows += MySQLHelper.MySqlHelper.ExecuteNonQuery(conn, CommandType.Text, cmdText,
                        parameter1, parameter2);
                    }
                }
            }
            return affectRows;
        }


        public int UpdUserInfoUsrPwdSignUp(int uisuID, string newUsrPwd)
        {
            using (MySqlConnection conn = MySQLHelper.MySqlHelper.GetConnection(connStr))
            {
                string cmdText = $"UPDATE userinfosignup SET usrPwd=@_userPwd WHERE usrID=@_userID;";
                MySqlParameter parameter1 = new MySqlParameter("@_userID", MySqlDbType.Int32, 10);
                MySqlParameter parameter2 = new MySqlParameter("@_userPwd", MySqlDbType.VarChar, 10);

                parameter1.Value = uisuID;
                parameter2.Value = newUsrPwd;

                return MySQLHelper.MySqlHelper.ExecuteNonQuery(conn, CommandType.Text, cmdText,
                    parameter1, parameter2);
            }
        }

        public int UpdUserInfosUsrPwdSignUp(List<int> uisuIDs, List<string> newUsrPwds)
        {
            int affectRows = 0;
            using (MySqlConnection conn = MySQLHelper.MySqlHelper.GetConnection(connStr))
            {
                string cmdText = $"UPDATE userinfosignup SET usrPwd=@_userPwd WHERE usrID=@_userID;";
                MySqlParameter parameter1 = new MySqlParameter("@_userID", MySqlDbType.Int32, 10);
                MySqlParameter parameter2 = new MySqlParameter("@_userPwd", MySqlDbType.VarChar, 10);

                for (int i = 0; i < uisuIDs.Count; i++)
                {
                    parameter1.Value = uisuIDs[i];
                    parameter2.Value = newUsrPwds[i];
                    affectRows += MySQLHelper.MySqlHelper.ExecuteNonQuery(conn, CommandType.Text, cmdText,
                    parameter1, parameter2);
                }
                return affectRows;
            }
        }

        //R
        public DataTable ReadUserInfoSignUp(params string[] fields)
        {

            if (fields.Length > 0)
            {
                string cmdText = string.Empty;
                foreach (var field in fields)
                {
                    cmdText = "SELECT " + field + " ";

                }
                cmdText += "FROM userinfosignup;";

                return MySQLHelper.MySqlHelper.GetDataTable(connStr, CommandType.Text, cmdText);
            }
            else
            {
                return null;
            }
        }

        public object ReadUserInfoSignUp(string uisuID, params string[] fields)
        {
            if (fields.Length > 0)
            {
                string cmdText = string.Empty;
                foreach (var field in fields)
                {
                    cmdText = "SELECT " + field + " ";

                }
                cmdText += "FROM userinfosignup" + $"WHERE usrID=@_userID;";
                MySqlParameter parameter1 = new MySqlParameter("@_userID", MySqlDbType.Int32, 10);
                parameter1.Value = uisuID;

                return MySQLHelper.MySqlHelper.ExecuteScalar(connStr, CommandType.Text, cmdText, parameter1);
            }
            else
            {
                return null;
            }
        }
    }
}
