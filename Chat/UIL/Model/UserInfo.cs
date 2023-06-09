using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.UIL.Model
{
    public abstract class UserInfo: EventArgs
    {
        private int userID;      //用户ID
        public int UserID { get => userID; set => userID = value; }

        private string userName; //用户名
        public string UserName { get => userName; set => userName = value; }

        private string userPwd;  //用户密码
        public string UserPwd { get => userPwd; set => userPwd = value; }

        private DateTime signUpTime;    //注册时间
        public DateTime SignUpTime { get => signUpTime; set => signUpTime = value; }

        public UserInfo() { }

        public UserInfo(int userId, string userName, string userPwd, DateTime signUpTime) 
        {
            this.userID = userId;
            this.userName = userName;
            this.userPwd = userPwd;
            this.signUpTime = signUpTime;
        }
    }
}
