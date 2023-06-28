using Client.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.BLL
{
    public class ClientUserSignIn
    {
        public static ClientSocket clientSocket;

        private static string usrName;
        public static string UsrName { get => usrName; set => usrName = value; }

        private static string usrPwd;
        public static string UsrPwd { get => usrPwd; set => usrPwd = value; }

        private bool login = false;
        public bool Login { get => login; set => login = value; }
        
        public ClientUserSignIn()
        {
            clientSocket = new ClientSocket();
        }


        public void SignIn()
        {
            //if ()
            //{
            //    login = true;
            //}
            //else
            //{
            //    login = false;
            //}



            //Server传来过来的byte[]到Client反序列化时会报找不到程序集错误。
            //因为Server传过来的数据包含命名空间。
            //https://blog.csdn.net/w21fanfan1314/article/details/8280582
        }
    }
}
