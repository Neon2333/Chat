using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;



namespace Client.Communication
{
    
    internal class SerializeHelper
    {
        #region int和byte[]互转
        /*
         int转换成byte数组原理:
         例如int 300,因为int占4字节，所以byte数组长度为4,先将300转换成二进制：
         00000000 00000000 00000001 00101100，然后将每个字节转换成十进制由
         低到高存入byte数组中，所以最后结果是44 1 0 0 ，byte[0]=44 byte[1]=1 
         byte[2]=0 byte[3]=0
         */

        public static byte[] IntToBytes(int value)
        {
            byte[] src = new byte[4];
            src[3] = (byte)((value >> 24) & 0xFF);
            src[2] = (byte)((value >> 16) & 0xFF);
            src[1] = (byte)((value >> 8) & 0xFF);
            src[0] = (byte)(value & 0xFF);
            return src;
        }


        public static int BytesToInt(byte[] src, int offset)
        {
            int value;
            value = (int)((src[offset] & 0xFF)
                    | ((src[offset + 1] & 0xFF) << 8)
                    | ((src[offset + 2] & 0xFF) << 16)
                    | ((src[offset + 3] & 0xFF) << 24));
            return value;
        }

        //public byte[] IntToBitConverter(int num)
        //{
        //    byte[] bytes = BitConverter.GetBytes(num);
        //    return bytes;
        //}

        //public int IntToBitConverter(byte[] bytes)
        //{
        //    int temp = BitConverter.ToInt32(bytes, 0);
        //    return temp;
        //}
        #endregion

        #region byte[]和string互转
        /// <summary>
        /// 使用UTF8编码将byte数组转成字符串
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string BytesToString(byte[] data)
        {
            return Encoding.UTF8.GetString(data, 0, data.Length);
        }

        /// <summary>
        /// 使用UTF-8编码将从偏移量处指定长度的字节数组转成字符串
        /// </summary>
        /// <param name="data"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string BytesToString(byte[] data, int offset, int count)
        {
            return Encoding.UTF8.GetString(data, offset, count);
        }


        /// <summary>
        /// 使用指定字符编码将byte数组转成字符串
        /// </summary>
        /// <param name="data"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string BytesToString(byte[] data, Encoding encoding)
        {
            return encoding.GetString(data, 0, data.Length);
        }


        public static string BytesToString(byte[] data, int offset, int count, Encoding encoding)
        {
            return encoding.GetString(data, offset, count);
        }

        /// <summary>
        /// 使用UTF8编码将字符串转成byte数组
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] StringToBytes (string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }

        /// <summary>
        /// 使用指定字符编码将字符串转成byte数组
        /// </summary>
        /// <param name="str"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static byte[] StringToBytes(string str, Encoding encoding)
        {
            return encoding.GetBytes(str);
        }
        #endregion

        #region 序列化
        /// <summary>
        /// 将对象序列化为二进制数据 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte[] SerializeObjToBinary(object obj)
        {
            MemoryStream stream = new MemoryStream();   //二进制流数据，所以用Stream
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, obj);

            byte[] data = stream.ToArray();
            stream.Close();

            return data;
        }

        /// <summary>
        /// 将对象序列化为XML数据
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte[] SerializeObjToXmlBytes(object obj)
        {
            MemoryStream stream = new MemoryStream();
            XmlSerializer xs = new XmlSerializer(obj.GetType());
            xs.Serialize(stream, obj);

            byte[] data = stream.ToArray();
            stream.Close();

            return data;
        }

        /// <summary>
        /// 将实体类转成符合xml格式的字符串。但暂时存在问题：XML编码不是utf-8而是utf-16。
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializeObjToXmlStr(object obj)
        {
            ////这里若直接使用StringWriter生成的xml字符串标头是utf - 16不是utf - 8
            ////通过内存流MemoryStream指定编码格式
            //using (MemoryStream ms = new MemoryStream())
            //{
            //    using (StreamWriter sw = new StreamWriter(ms, encoding))
            //    {
            //        Type t = obj.GetType();
            //        XmlSerializer serializer = new XmlSerializer(obj.GetType());
            //        serializer.Serialize(sw, obj);
            //        sw.Close();
            //        return Encoding.UTF8.GetString(ms.GetBuffer());
            //    }
            //}


            using (StringWriter sw = new StringWriter())
            {
                Type t = obj.GetType();
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(sw, obj);
                sw.Close();
                return sw.ToString();
            }
        }


        /// <summary>
        /// 将实体类序列化为xml，并保存为xml文件到指定路径
        /// </summary>
        /// <param name="obj">实体类实例</param>
        /// <param name="xmlPath">xml路径</param>
        /// <returns></returns>
        public static bool SerializeObjToXmlFile(object obj, string xmlPath)
        {
            try
            {
                string xmlStr = SerializeObjToXmlStr(obj);
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(xmlStr); //读取符合xml格式的字符串xml到XMLDocument，str不符合xml格式时会报错
                xmldoc.Save(xmlPath);   //文件存在会覆盖
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        #endregion


        #region 反序列化
        /// <summary>
        /// 将二进制数据反序列化
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static object DeserializeObjWithBinary(byte[] data)
        {
            MemoryStream stream = new MemoryStream();
            stream.Write(data, 0, data.Length);
            stream.Position = 0;

            BinaryFormatter bf = new BinaryFormatter()
            {
                Binder = new UBinder()
            };
            object obj = bf.Deserialize(stream);

            stream.Close();
            return obj;
        }

        /// <summary>
        /// 将二进制数据反序列化为指定类型对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static T DeserializeObjWithBinary<T>(byte[] data)
        {
            return (T)DeserializeObjWithBinary(data);
        }

        /// <summary>
        /// 将XML数据反序列化为指定类型对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static T DeserializeObjWithXmlBytes<T>(byte[] data)
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            using (MemoryStream stream = new MemoryStream())
            {
                stream.Write(data, 0, data.Length);
                stream.Position = 0;
                using (XmlTextReader reader = new XmlTextReader(stream))
                {
                    //Q：反序列化，类实例的string字段\r\n丢失\r
                    // 注意一定要创建出一个 XmlTextReader出来，   
                    // 因为MS默认的 reader.Normalization = true   
                    // 设置成false就不会把回车去掉了   
                    reader.Normalization = false;
                    object obj = xs.Deserialize(reader);

                    return (T)obj;
                }
            }
        }

        /// <summary>
        /// 将符合xml格式的字符串反序列化为实体类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xmlStr">符合xml格式的字符串</param>
        /// <returns></returns>
        public static T DeserializeObjWithXmlStr<T>(string xmlStr) where T:class
        {
            try
            {
                using (StringReader sr = new StringReader(xmlStr))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    return serializer.Deserialize(sr) as T;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        /// <summary>
        /// 读取xml文件内容，转成实体类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xmlPath"></param>
        /// <returns></returns>
        public static T DeserializeObjFromXmlfile<T>(string xmlPath) where T : class
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlPath);
            return DeserializeObjWithXmlStr<T>(xmlDocument.InnerXml);
        }
        #endregion

    }
}
