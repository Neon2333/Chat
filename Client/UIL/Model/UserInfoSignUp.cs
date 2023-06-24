using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.UIL.Model
{
    public class UserInfoSignUp: UserInfo
    {
        public UserInfoSignUp() { }

        public UserInfoSignUp(int userId, string userName, string userPwd, DateTime signUpTime) :base(userId, userName, userPwd, signUpTime)
        { }
    }
}
