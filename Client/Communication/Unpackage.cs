using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Communication
{
    internal class Unpackage
    {
        public static bool SetUnPackage(List<byte> data, int headLen, out byte[] package)
        {
            if (data.Count <= headLen)
            {
                package = null;
                return false;
            }
            else 
            {
                byte[] header = data.GetRange(0, headLen).ToArray();
                int dataBodyLen = SerializeHelper.DeserializeObjWithXmlBytes<int>(header);
                if ((data.Count - headLen) < dataBodyLen)
                {
                    package = null;
                    return false;
                }
                else
                {
                    data.RemoveRange(0, headLen);
                    package = data.GetRange(0, dataBodyLen).ToArray();
                    data.RemoveRange(0, dataBodyLen);
                    return true;
                }
            }



        }
    }
}
