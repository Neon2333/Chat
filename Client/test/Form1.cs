using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.BLL;
using Client.Communication;
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

            //UserInfoSignIn uifs = new UserInfoSignIn();
            //uifs.ClientConnectSocket = ClientSocket.ConnectSvrSocket;
            //Task.Run(() => clientSocket.RecvData(uifs));

            //uifs.recvEvent += showChatMsg;

            //void showChatMsg(object sender, PackageModel package)
            //{
            //    UserMessage um = SerializeHelper.DeserializeObjWithXmlBytes<UserMessage>(data);
            //    textBox1.BeginInvoke(new Action(() => textBox1.Text += ($"{um.SendTime} ,{um.UserNameSend}: {um.ChatMsg}" + "\r\n")));
            //}

            //UserInfoSignUp uisu = new UserInfoSignUp();
            //uisu.UserID = 1;
            //uisu.UserName = "wk";
            //uisu.UserPwd = "123";
            //uisu.SignUpTime = DateTime.Now;

            //string xmlstr = Communication.SerializeHelper.SerializeObjToXmlStr(uisu);


            //textBox1.Text = xmlstr;
            //Communication.SerializeHelper.SerializeObjToXmlFile(uisu, @"C:\Users\Administrator\Desktop\uisu.xml");

            //UserInfoSignUp _uisu = Communication.SerializeHelper.DeserializeObjFromXmlfile<UserInfoSignUp>(@"C:\Users\Administrator\Desktop\uisu.xml");

            ProcessRecvPackage proPack = new ProcessRecvPackage();

            ProcessRecvPackage processRecvPackage = new ProcessRecvPackage();
            processRecvPackage.recvUserMessageEvent += showUserMessage;

        }


        public void showUserMessage(object sender, UserMessage userMessage)
        {
            textBox1.BeginInvoke(new Action(() => textBox1.Text += ($"{userMessage.SendTime} ,{userMessage.UserNameSend}: {userMessage.ChatMsg}" + "\r\n")));
        }
    }
}
