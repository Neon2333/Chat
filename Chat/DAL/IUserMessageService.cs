using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatModel;


namespace Server.DAL
{
    public interface IUserMessageService
    {
        //C
        int InsUserMessage(UserMessage um);

        int InsUserMessages(List<UserMessage> ums);

        //D

        int DeleUserMessageByMsgID(int messageID);

        int DeleUserMessageByMsgIDDateTime(int messageID, DateTime startTime, DateTime endTime);

        int DeleUserMessageByMsgIDs(List<int> messageIDs);

        int DeleUserMessageByUserIDSend(int userIDSend);

        int DeleUserMessageByUserNameSend(string userNameSend);

        int DeleUserMessageByUserIDRecv(int userIDRecv);

        int DeleUserMessageByUserNameRecv(string UserNameRecv);


        //U

        int UpdUserMessage(int messageID, string newChatMsg);

        int UpdUserMessage(int messageID, DateTime sendTime);

        int UpdUserMessageUserIDSend(int messageID, int userIDSend);

        int UpdUserMessageUserIDRecv(int messageID, int userIDRecv);

        int UpdUserMessageUserNameSend(int messageID, string userNameSend);

        int UpdUserMessageUserNameRecv(int messageID, string userNameRecv);

        //R

        DataTable ReadUserMessage(params string[] fields);

        DataTable ReadUserMessage(int limit, params string[] fields);

        object ReadUserMessage(string uisiID, params string[] fields);
    }
}
