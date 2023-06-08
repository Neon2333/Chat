using Server.UIL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DAL
{
    internal class UserMessageService
    {
        /// <summary>
        /// 将Message序列化
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static byte[] UserMessageSerialize(UserMessage msg)
        {
            try
            {
                return DAL.SerializeHelper.SerializeHelper.SerializeToBinary(msg);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        /// <summary>
        /// 将Message反序列化
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static UserMessage UserMessageDeserilize(byte[] msgByte)
        {
            /*
             var date1 = new DateTime(2013, 6, 1, 12, 32, 30);
             DateTime.TryParse(dateString, out parsedDate)
             */
            try
            {
                return DAL.SerializeHelper.SerializeHelper.DeserializeWithBinary<UserMessage>(msgByte);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
