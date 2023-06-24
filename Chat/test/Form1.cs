using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Server.UIL.Model;

namespace Server.test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            UserInfoSignUp userInfo = new UserInfoSignUp();
            userInfo.UserID = 1;
            userInfo.UserName = "wk";
            userInfo.UserPwd = "231";
            userInfo.SignUpTime = DateTime.Now;

            byte[] bytes = Communication.SerializeHelper.SerializeObjToXmlBytes(userInfo);

            
        }
    }
}
