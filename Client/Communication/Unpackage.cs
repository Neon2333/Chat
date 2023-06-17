using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Communication
{
    internal class Unpackage
    {
        public static bool SetUnPackage(List<byte> data, out byte[] package)
        {
            if (data.Count <= 54)
            {
                package = null;
                return false;
            }
            else 
            {
                byte[] header = data.GetRange(0, 54).ToArray();
                int dataBodyLen = SerializeHelper.SerializeHelper.DeserializeWithBinary<int>(header);
                if ((data.Count - 54) < dataBodyLen)
                {
                    package = null;
                    return false;
                }
                else
                {
                    data.RemoveRange(0, 54);
                    package = data.GetRange(0, dataBodyLen).ToArray();
                    data.RemoveRange(0, dataBodyLen);
                    return true;
                }
            }
        }
    }
}
