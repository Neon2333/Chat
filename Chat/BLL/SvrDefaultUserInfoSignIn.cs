using ChatModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.BLL
{
    public class SvrDefaultUserInfoSignIn
    {
        public static UserInfoSignIn defaultUserInfoSignIn;

        public SvrDefaultUserInfoSignIn()
        {
            defaultUserInfoSignIn = new UserInfoSignIn();
            defaultUserInfoSignIn.UserName = "server";
            defaultUserInfoSignIn.LoginTime = DateTime.Now;
        }
    }
}
