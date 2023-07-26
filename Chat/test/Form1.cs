using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Server.Communication;
using Server.DAL.MySQLService;
using ChatModel;


namespace Server.test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //InitializeComponent();
            //ServerSocket ss;
            //ss = new ServerSocket(IPAddress.Any, 8888, 10);

            //UserInfoSignIn user = new UserInfoSignIn();
            //user.UserName = "wk";
            
            //ss.Listen();
            
            ////user.connectedEvent += _onConnectEvent;

            //if ((ss.AcceptClientConnect(user)).Result)
            //{

            //}

            //if (ss.ConnectedClients.Count > 0)
            //{
            //    foreach (var client in ss.ConnectedClients)
            //    {
            //        Task.Run(() => ss.RecvData(client), client.CancelRecvToken);

            //        client.recvEvent += _onRecvEvent;
            //    }
            //}
            



        }

        private void _onConnectEvent(object sender, UserInfoSignIn client)
        {
            textEdit1.BeginInvoke(new Action(() => textEdit1.Text += ($"{client.ConnectTime}:{client.UserName}" + "\n")));
        }

        public void _onRecvEvent(object sender, PackageModel package)
        {
            UserInfoSignUp userSignUp = new UserInfoSignUp();
            if (package.PackageType==PackageModel.PackageTypeDef.RequestType_C)
            {
                Type dataType = Type.GetType("Server." + package.DataType);

                if(package.Data is UserInfoSignUp)
                {
                    userSignUp = package.Data as UserInfoSignUp;
                    DateTime sendTime = package.SendTime;

                }
                userSignUp.SignUpTime = DateTime.Now;

                UserInfoSignUpServiceMySQL userInfoSignUpServiceMySQL = new UserInfoSignUpServiceMySQL();
                int operCounts = userInfoSignUpServiceMySQL.InsUserInfoSignUp(userSignUp);

            }

        }
    }
}
