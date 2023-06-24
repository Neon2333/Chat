using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.UIL.Model
{
    /// <summary>
    /// 所有C/S通信的消息的父类
    /// </summary>
    /// <typeparam name="T">data的类型</typeparam>
    [Serializable]
    public abstract class PackageModel<T>:EventArgs where T:MessageModel
    {
        private string msg;    
        public string Msg { get => msg; set => msg = value; }

        private T data;     //数据主体
        public T Data { get => data; set => data = value; }

        private string code;    //状态码
        public string Code { get => code; set => code = value; }

        private bool success;   //Response成功与否
        public bool Success { get => success; set => success = value; }

        protected DateTime sendTime;  //发送时间
        public DateTime SendTime { get => sendTime; set => sendTime = value; }

        public PackageModel() { }

        public PackageModel(string msg, T data, string code, bool success, DateTime sendTime)
        {
            this.msg = msg;
            this.data = data;
            this.code = code;
            this.success = success;
            this.sendTime = sendTime;
        }

    }
}
