using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices.WindowsRuntime;
using Server.Communication;
using Server.UIL.Model;

namespace Server.UIL.View
{
    public partial class FormServer : Form
    {
        public static bool flagRecvMsg = false;
        ServerSocket ss;

        public FormServer()
        {
            InitializeComponent();
            
            init();
        }

        private void init()
        {
            this.textBox_port.Text = "8888";
        }

        private void showConnectedClients(object sender, UserInfoSignIn client)
        {
            this.textBox_clients.BeginInvoke(new Action(() => this.textBox_clients.Text += ($"{client.ConnectTime}:{client.UserName}" + "\n")));

        }

        private void button_startListen_Click(object sender, EventArgs e)
        {
            ss = new ServerSocket(IPAddress.Any, int.Parse(this.textBox_port.Text), 10);
            string initMsg = String.Empty;
            if(ss.Listen())
            {
                this.textBox_status.Text = $"启动监听端口 {this.textBox_port.Text} 成功..";
            }
            else
            {
                this.textBox_status.Text = $"启动监听端口 {this.textBox_port.Text} 失败..";
            }

        }

        private async void button_connectClient_Click(object sender, EventArgs e)
        {
            try
            {
                UserInfoSignIn user = new UserInfoSignIn();
                user.UserName = "wk";
                user.connectedEvent += showConnectedClients;
                if (await ss.AcceptClientConnect(user))
                {
                    textBox_status.Text = "connected..";
                    this.textBox_status.ForeColor = System.Drawing.Color.Green;
                }   

                //if (ss.ConnectedClients.Count > 0)
                //{
                //    foreach (var client in ss.ConnectedClients)
                //    {
                //        client.connectedEvent += showConnectedClients;
                //    }
                //}
            }
            catch (Exception ex)
            {
                textBox_status.Text = "not connected..";
                this.textBox_status.ForeColor = System.Drawing.Color.DarkRed;
            }
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            try
            {
                if (ss.ConnectedClients.Count > 0)
                {
                    foreach (var client in ss.ConnectedClients)
                    {
                        //服务器ID设为-1
                        UserMessage msg = new UserMessage(-1, "server", client.UserID, client.UserName, DateTime.Now, this.textBox_send.Text);
                        ss.SendClientMsg(client, msg);
                    }   

                }

                this.textBox_status.Text = "send success..";
            }
            catch(Exception ex)
            {
                this.textBox_status.Text = "send failed..";
            }
        }

        //将publiser传入的msg进行显示
        private void showRecvMsg(object sender, UserMessage msg)
        {
            //this.textBox_receive.Text = msg.Msg;
            this.textBox_receive.BeginInvoke(new Action(() => this.textBox_receive.Text += ($"{msg.SendTime} ,{msg.UserNameSend}: {msg.ChatMsg}" + "\r\n")));
        }

        private void button_receive_Click(object sender, EventArgs e)   
        {
            //ss.ReceiveMsg(this.textBox_receive, this.textBox_status);     //textbox传入函数，通过委托跨线程访问

            
            //客户端将委托绑定事件，通过类Message封装接收的消息，EventHandler从publisher传入observer
            if (ss.ConnectedClients.Count > 0)
            {
                foreach (var client in ss.ConnectedClients)
                {
                    ss.ReceiveSendMsg(client, client);
                    client.recvEvent += showRecvMsg;
                }

            }
            
        }

        private void button_stopRecv_Click(object sender, EventArgs e)
        {
            try
            {
                if (ss.ConnectedClients.Count > 0)
                {
                    foreach (var client in ss.ConnectedClients)
                    {
                        ss.haltRecvMsg(client);
                    }
                }

                textBox_status.Text = "recv stop..";
            }
            catch (Exception ex)
            {

            }
        }

        private void button_disconncet_Click(object sender, EventArgs e)
        {
            try
            {
                if (ss.ConnectedClients.Count > 0)
                {
                    foreach (var client in ss.ConnectedClients)
                    {
                        ss.DisConnect(client);
                    }

                }
                this.textBox_status.Text = "disconnected..";

            }
            catch (Exception ex)
            {
            }
        }
        

    }
}
