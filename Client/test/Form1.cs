using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.UIL.Model;

namespace Client.test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //Communication.ClientSocket clientSocket = new Communication.ClientSocket();

            //clientSocket.ConnectSvr();
            //string msg = clientSocket.RecvMsg();

            //textBox1.Text = msg;


            UserInfoSignUp uisu = new UserInfoSignUp();
            uisu.UserID = 1;
            uisu.UserName = "wk";
            uisu.UserPwd = "123";
            uisu.SignUpTime = DateTime.Now;

            string xmlstr = Communication.SerializeHelper.SerializeObjToXmlStr(uisu);


            textBox1.Text = xmlstr;
            Communication.SerializeHelper.SerializeObjToXmlFile(uisu, @"C:\Users\Administrator\Desktop\uisu.xml");

            UserInfoSignUp _uisu = Communication.SerializeHelper.DeserializeObjFromXmlfile<UserInfoSignUp>(@"C:\Users\Administrator\Desktop\uisu.xml");

        }
    }
}
