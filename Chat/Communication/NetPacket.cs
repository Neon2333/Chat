using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Server.UIL.Model;

namespace Server.Communication
{
    //解决TCP客户端沾包、缺包
    //暂时包头不添加校验CRC

    public class NetPacket
    {
        private byte[] databodyLengthBytes = new byte[4];   //4字节记录int

        private byte[] dataTypeBytes = new byte[50];        //记录数据类型

        /// <summary>
        /// 封包：将data加上4byte记录数据体长度和记录数据类型的包头
        /// </summary>
        /// <param name="PackageModelBytes"></param>
        /// <param name=""></param>
        /// <returns>封包后的字节数据</returns>
        public byte[] Package(PackageModel package)
        {
            byte[] packageModelBytes = SerializeHelper.SerializeObjToXmlBytes(package);
            int databodyLength = packageModelBytes.Length;
            databodyLengthBytes = SerializeHelper.IntToBytes(databodyLength);
            byte[] res = databodyLengthBytes.Concat(packageModelBytes).ToArray();   //把包头加在数据体前
            return res;
        }

        /// <summary>
        /// 拆包
        /// 目前不知道效率如何？
        /// </summary>
        /// <param name="PackageModelBytes">动态缓冲区List<byte></param>
        /// <param name="onepacket"></param>
        /// <returns>拆出一个包的数据</returns>
        public bool UnPackage(ref List<byte> PackageModelBytes, out PackageModel onePackage)
        {
            if (PackageModelBytes.Count <= 4)
            {
                onePackage = null;
                return true;
            }
            else 
            {
                int bodyLen = SerializeHelper.BytesToInt(PackageModelBytes.GetRange(0, 4).ToArray(), 0);
                if ((PackageModelBytes.Count - 4) < bodyLen)
                {
                    onePackage = null;
                    return true;
                }
                else
                {
                    onePackage = SerializeHelper.DeserializeObjWithXmlBytes<PackageModel>(PackageModelBytes.GetRange(54, bodyLen).ToArray());
                    PackageModelBytes.RemoveRange(0, 4 + bodyLen);
                    return true;
                }
            }
        }

    }
}
