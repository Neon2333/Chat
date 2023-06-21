using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Client.Communication
{
    internal class Package
    {
        public static byte[] SetPackage(byte[] data)
        {
            int len = data.Length;
            byte[] header = SerializeHelper.SerializeObjToXmlBytes(len);
            byte[] res = header.Concat(data).ToArray();
            return res;
        }

    }
}
