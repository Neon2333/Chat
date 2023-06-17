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
    class UserMessageServiceMySQL : IUserMessageService
    {
        string connStr = (new dbConStr()).GetDbConStr();

        //C
        public int InsUserMessage(UserMessage um)
        {
            using (MySqlConnection conn = MySQLHelper.MySqlHelper.GetConnection(connStr))
            {
                string cmdText = "INSERT INTO usermessage (messageID,chatMsg,sendTime,usrIDSend,usrNameSend,usrIDRecv,usrNameRecv) " +
                    "VALUES (@_messageID,@_chatMsg,@_sendTime,@_userIDSend,@_userNameSend,@_userIDRecv,@_userNameRecv);";

                MySqlParameter parameter1 = new MySqlParameter("@_messageID", MySqlDbType.Int32, 10);
                MySqlParameter parameter2 = new MySqlParameter("@_chatMsg", MySqlDbType.VarChar, 10);
                MySqlParameter parameter3 = new MySqlParameter("@_sendTime", MySqlDbType.DateTime, 10);
                MySqlParameter parameter4 = new MySqlParameter("@_userIDSend", MySqlDbType.Int32, 10);
                MySqlParameter parameter5 = new MySqlParameter("@_userNameSend", MySqlDbType.VarChar, 10);
                MySqlParameter parameter6 = new MySqlParameter("@_userIDRecv", MySqlDbType.Int32, 10);
                MySqlParameter parameter7 = new MySqlParameter("@_userNameRecv", MySqlDbType.DateTime, 10);
                parameter1.Value = um.MessageID;
                parameter2.Value = um.ChatMsg;
                parameter3.Value = um.SendTime;
                parameter4.Value = um.UserIDSend;
                parameter5.Value = um.UserNameSend;
                parameter6.Value = um.UserIDRecv;
                parameter7.Value = um.UserNameRecv;

                return MySQLHelper.MySqlHelper.ExecuteNonQuery(conn, CommandType.Text, cmdText,
                    parameter1, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7);
            }

        }

        public int InsUserMessages(List<UserMessage> ums)
        {
            int affectRows = 0;
            using (MySqlConnection conn = MySQLHelper.MySqlHelper.GetConnection(connStr))
            {
                string cmdText = "INSERT INTO usermessage (messageID,chatMsg,sendTime,usrIDSend,usrNameSend,usrIDRecv,usrNameRecv) " +
                    "VALUES (@_messageID,@_chatMsg,@_sendTime,@_userIDSend,@_userNameSend,@_userIDRecv,@_userNameRecv);";

                MySqlParameter parameter1 = new MySqlParameter("@_messageID", MySqlDbType.Int32, 10);
                MySqlParameter parameter2 = new MySqlParameter("@_chatMsg", MySqlDbType.VarChar, 10);
                MySqlParameter parameter3 = new MySqlParameter("@_sendTime", MySqlDbType.DateTime, 10);
                MySqlParameter parameter4 = new MySqlParameter("@_userIDSend", MySqlDbType.Int32, 10);
                MySqlParameter parameter5 = new MySqlParameter("@_userNameSend", MySqlDbType.VarChar, 10);
                MySqlParameter parameter6 = new MySqlParameter("@_userIDRecv", MySqlDbType.Int32, 10);
                MySqlParameter parameter7 = new MySqlParameter("@_userNameRecv", MySqlDbType.DateTime, 10);


                foreach (var um in ums)
                {
                    parameter1.Value = um.MessageID;
                    parameter2.Value = um.ChatMsg;
                    parameter3.Value = um.SendTime;
                    parameter4.Value = um.UserIDSend;
                    parameter5.Value = um.UserNameSend;
                    parameter6.Value = um.UserIDRecv;
                    parameter7.Value = um.UserNameRecv;

                    affectRows += MySQLHelper.MySqlHelper.ExecuteNonQuery(conn, CommandType.Text, cmdText,
                        parameter1, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7);
                }
            }
            return affectRows;
        }

        //D

        public int DeleUserMessageByMsgID(int messageID)
        {
            using (MySqlConnection conn = MySQLHelper.MySqlHelper.GetConnection(connStr))
            {
                string cmdText = $"DELETE FROM usermessage WHERE messageID=@_messageID;";
                MySqlParameter parameter1 = new MySqlParameter("@_userId", MySqlDbType.Int32, 10);
                parameter1.Value = messageID;
                return MySQLHelper.MySqlHelper.ExecuteNonQuery(conn, CommandType.Text, cmdText,
                    parameter1);
            }
        }

        public int DeleUserMessageByMsgIDDateTime(int messageID, DateTime startTime, DateTime endTime)
        {
            using (MySqlConnection conn = MySQLHelper.MySqlHelper.GetConnection(connStr))
            {
                string cmdText = $"DELETE FROM usermessage WHERE messageID=@_messageID" +
                    $" AND sendTime BETWEEN {startTime} AND {endTime};";
                MySqlParameter parameter1 = new MySqlParameter("@_userId", MySqlDbType.Int32, 10);
                parameter1.Value = messageID;
                return MySQLHelper.MySqlHelper.ExecuteNonQuery(conn, CommandType.Text, cmdText,
                    parameter1);
            }
        }

        public int DeleUserMessageByMsgIDs(List<int> messageIDs)
        {
            int affectRows = 0;
            using (MySqlConnection conn = MySQLHelper.MySqlHelper.GetConnection(connStr))
            {
                string cmdText = $"DELETE FROM usermessage WHERE messageID=@_messageID";
                MySqlParameter parameter1 = new MySqlParameter("@_userId", MySqlDbType.Int32, 10);

                foreach (var messageID in messageIDs)
                {
                    parameter1.Value = messageID;
                    affectRows += MySQLHelper.MySqlHelper.ExecuteNonQuery(conn, CommandType.Text, cmdText,
                        parameter1);
                }
            }
            return affectRows;
        }

        public int DeleUserMessageByUserIDSend(int userIDSend)
        {
            using (MySqlConnection conn = MySQLHelper.MySqlHelper.GetConnection(connStr))
            {
                string cmdText = $"DELETE FROM usermessage WHERE usrIDSend=@_usrIDSend;";
                MySqlParameter parameter1 = new MySqlParameter("@_usrIDSend", MySqlDbType.Int32, 10);
                parameter1.Value = userIDSend;
                return MySQLHelper.MySqlHelper.ExecuteNonQuery(conn, CommandType.Text, cmdText,
                    parameter1);
            }
        }

        public int DeleUserMessageByUserNameSend(string userNameSend)
        {
            using (MySqlConnection conn = MySQLHelper.MySqlHelper.GetConnection(connStr))
            {
                string cmdText = $"DELETE FROM usermessage WHERE usrNameSend=@_usrNameSend;";
                MySqlParameter parameter1 = new MySqlParameter("@_usrNameSend", MySqlDbType.Int32, 10);
                parameter1.Value = userNameSend;
                return MySQLHelper.MySqlHelper.ExecuteNonQuery(conn, CommandType.Text, cmdText,
                    parameter1);
            }
        }

        public int DeleUserMessageByUserIDRecv(int userIDRecv)
        {
            using (MySqlConnection conn = MySQLHelper.MySqlHelper.GetConnection(connStr))
            {
                string cmdText = $"DELETE FROM usermessage WHERE userIDRecv=@_usrIDRecv;";
                MySqlParameter parameter1 = new MySqlParameter("@_usrIDRecv", MySqlDbType.Int32, 10);
                parameter1.Value = userIDRecv;
                return MySQLHelper.MySqlHelper.ExecuteNonQuery(conn, CommandType.Text, cmdText,
                    parameter1);
            }
        }

        public int DeleUserMessageByUserNameRecv(string UserNameRecv)
        {
            using (MySqlConnection conn = MySQLHelper.MySqlHelper.GetConnection(connStr))
            {
                string cmdText = $"DELETE FROM usermessage WHERE usrNameRecv=@_usrNameRecv;";
                MySqlParameter parameter1 = new MySqlParameter("@_usrNameRecv", MySqlDbType.Int32, 10);
                parameter1.Value = UserNameRecv;
                return MySQLHelper.MySqlHelper.ExecuteNonQuery(conn, CommandType.Text, cmdText,
                    parameter1);
            }
        }


        //U

        public int UpdUserMessage(int messageID, string newChatMsg)
        {
            using (MySqlConnection conn = MySQLHelper.MySqlHelper.GetConnection(connStr))
            {
                string cmdText = $"UPDATE usermessage SET messageID=@_messageID WHERE chatMsg=@_chatMsg;";
                MySqlParameter parameter1 = new MySqlParameter("@_messageID", MySqlDbType.Int32, 10);
                MySqlParameter parameter2 = new MySqlParameter("@_chatMsg", MySqlDbType.VarChar, 10);

                parameter1.Value = messageID;
                parameter2.Value = newChatMsg;

                return MySQLHelper.MySqlHelper.ExecuteNonQuery(conn, CommandType.Text, cmdText,
                    parameter1, parameter2);
            }
        }

        public int UpdUserMessage(int messageID, DateTime sendTime)
        {
            using (MySqlConnection conn = MySQLHelper.MySqlHelper.GetConnection(connStr))
            {
                string cmdText = $"UPDATE usermessage SET messageID=@_messageID WHERE sendTime=@_sendTime;";
                MySqlParameter parameter1 = new MySqlParameter("@_messageID", MySqlDbType.Int32, 10);
                MySqlParameter parameter2 = new MySqlParameter("@_sendTime", MySqlDbType.VarChar, 10);

                parameter1.Value = messageID;
                parameter2.Value = sendTime;

                return MySQLHelper.MySqlHelper.ExecuteNonQuery(conn, CommandType.Text, cmdText,
                    parameter1, parameter2);
            }
        }

        public int UpdUserMessageUserIDSend(int messageID, int userIDSend)
        {
            using (MySqlConnection conn = MySQLHelper.MySqlHelper.GetConnection(connStr))
            {
                string cmdText = $"UPDATE usermessage SET messageID=@_messageID WHERE usrIDSend=@_userIDSend;";
                MySqlParameter parameter1 = new MySqlParameter("@_messageID", MySqlDbType.Int32, 10);
                MySqlParameter parameter2 = new MySqlParameter("@_userIDSend", MySqlDbType.VarChar, 10);

                parameter1.Value = messageID;
                parameter2.Value = userIDSend;

                return MySQLHelper.MySqlHelper.ExecuteNonQuery(conn, CommandType.Text, cmdText,
                    parameter1, parameter2);
            }
        }

        public int UpdUserMessageUserIDRecv(int messageID, int userIDRecv)
        {
            using (MySqlConnection conn = MySQLHelper.MySqlHelper.GetConnection(connStr))
            {
                string cmdText = $"UPDATE usermessage SET messageID=@_messageID WHERE usrIDRecv=@_userIDRecv;";
                MySqlParameter parameter1 = new MySqlParameter("@_messageID", MySqlDbType.Int32, 10);
                MySqlParameter parameter2 = new MySqlParameter("@_userIDRecv", MySqlDbType.VarChar, 10);

                parameter1.Value = messageID;
                parameter2.Value = userIDRecv;

                return MySQLHelper.MySqlHelper.ExecuteNonQuery(conn, CommandType.Text, cmdText,
                    parameter1, parameter2);
            }
        }

        public int UpdUserMessageUserNameSend(int messageID, string userNameSend)
        {
            using (MySqlConnection conn = MySQLHelper.MySqlHelper.GetConnection(connStr))
            {
                string cmdText = $"UPDATE usermessage SET messageID=@_messageID WHERE usrNameSend=@_userNameSend;";
                MySqlParameter parameter1 = new MySqlParameter("@_messageID", MySqlDbType.Int32, 10);
                MySqlParameter parameter2 = new MySqlParameter("@_userNameSend", MySqlDbType.VarChar, 10);

                parameter1.Value = messageID;
                parameter2.Value = userNameSend;

                return MySQLHelper.MySqlHelper.ExecuteNonQuery(conn, CommandType.Text, cmdText,
                    parameter1, parameter2);
            }
        }

        public int UpdUserMessageUserNameRecv(int messageID, string userNameRecv)
        {
            using (MySqlConnection conn = MySQLHelper.MySqlHelper.GetConnection(connStr))
            {
                string cmdText = $"UPDATE usermessage SET messageID=@_messageID WHERE usrNameRecv=@_userNameRecv;";
                MySqlParameter parameter1 = new MySqlParameter("@_messageID", MySqlDbType.Int32, 10);
                MySqlParameter parameter2 = new MySqlParameter("@_userNameRecv", MySqlDbType.VarChar, 10);

                parameter1.Value = messageID;
                parameter2.Value = userNameRecv;

                return MySQLHelper.MySqlHelper.ExecuteNonQuery(conn, CommandType.Text, cmdText,
                    parameter1, parameter2);
            }
        }

        //R

        public DataTable ReadUserMessage(params string[] fields)
        {
            if (fields.Length > 0)
            {
                string cmdText = string.Empty;
                foreach (var field in fields)
                {
                    cmdText = "SELECT " + field + " ";

                }
                cmdText += "FROM usermessage;";

                return MySQLHelper.MySqlHelper.GetDataTable(connStr, CommandType.Text, cmdText);
            }
            else
            {
                return null;
            }
        }

        public DataTable ReadUserMessage(int limit, params string[] fields)
        {
            if (fields.Length > 0)
            {
                string cmdText = string.Empty;
                foreach (var field in fields)
                {
                    cmdText = "SELECT " + field + " ";

                }
                cmdText += "FROM usermessage    " + $"LIMIT 0,{limit}";

                return MySQLHelper.MySqlHelper.GetDataTable(connStr, CommandType.Text, cmdText);
            }
            else
            {
                return null;
            }
        }

        public object ReadUserMessage(string uisiID, params string[] fields)
        {
            if (fields.Length > 0)
            {
                string cmdText = string.Empty;
                foreach (var field in fields)
                {
                    cmdText = "SELECT " + field + " ";

                }
                cmdText += "FROM usermessage" + $"WHERE usrID=@_userID;";
                MySqlParameter parameter1 = new MySqlParameter("@_userID", MySqlDbType.Int32, 10);
                parameter1.Value = uisiID;

                return MySQLHelper.MySqlHelper.ExecuteScalar(connStr, CommandType.Text, cmdText, parameter1);
            }
            else
            {
                return null;
            }
        }
    }
}
