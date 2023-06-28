using Server.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Server.UIL.Model
{
    /// <summary>
    /// 所有C/S通信的消息的父类
    /// </summary>
    /// <typeparam name="T">data的类型</typeparam>
    [Serializable]
    [XmlInclude(typeof(PackageModel))]
    public class PackageModel:EventArgs
    {
        private PackageType.PackageTypeDef packageType;     //package类型
        public PackageType.PackageTypeDef PackageType { get => packageType; set => packageType = value; }

        private string msg;    
        public string Msg { get => msg; set => msg = value; }

        private string dataType;    //data的类型
        public string DataType { get => dataType; set => dataType = value; }

        private object data;     //数据主体
        public object Data { get => data; set => data = value; }

        private bool success;   //Response成功与否
        public bool Success { get => success; set => success = value; }

        private string code;    //状态码
        public string Code { get => code; set => code = value; }

        protected DateTime sendTime;  //发送时间
        public DateTime SendTime { get => sendTime; set => sendTime = value; }

        public PackageModel() { }

        public PackageModel(PackageType.PackageTypeDef packType, string msg, string dataType, object data, string code, bool success, DateTime sendTime)
        {
            this.packageType = packType;
            this.msg = msg;
            this.dataType = dataType;
            this.data = data;
            this.code = code;
            this.success = success;
            this.sendTime = sendTime;
        }

    }
}
