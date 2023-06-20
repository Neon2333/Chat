using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Client.Encrypt
{
    public class MD5Encrypt
    {
        public static string EncryptMD5(string str)
        {
            MD5 _md5 = new MD5CryptoServiceProvider();
            byte[] _bytes = Encoding.UTF8.GetBytes(str);
            byte[] bytesCrypt = _md5.ComputeHash(_bytes);
            string byteToStr16 = String.Empty;

            foreach (var _byte in bytesCrypt)
            {
                /*
                 ToString("X2") 为C#中的字符串格式控制符
                 X为     十六进制
                 2为     每次都是两位数
                 比如   0x0A ，若没有2,就只会输出0xA 
                 假设有两个数10和26，正常情况十六进制显示0xA、0x1A，这样看起来不整齐，为了好看，可以指定"X2"，这样显示出来就是：0x0A、0x1A。 
                 */
                byteToStr16 += _byte.ToString("x2");
            }
            return byteToStr16;
        }
    }
}
