using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Client.UIL.Model
{
    public class UserInfoSignUp: UserInfo
    {
        private DateTime signUpTime;    //注册时间
        public DateTime SignUpTime { get => signUpTime; set => signUpTime = value; }

        public UserInfoSignUp() { }

        public UserInfoSignUp(int userId, string userName, string userPwd, DateTime signUpTime) :base(userId, userName, userPwd)
        {
            this.signUpTime = signUpTime;
        }
    }
}
