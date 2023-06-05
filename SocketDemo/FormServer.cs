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

namespace SocketDemo
{
    public partial class FormServer : Form
    {
        public static bool flagRecvMsg = false;
        ServerSocket ss;

        public FormServer()
        {
            InitializeComponent();
        }

        private void init()
        {
            this.textBox_port.Text = "8888";

            foreach (var client in ss.ConnectedClients)
            {
                this.textBox_clients.Text += (client.UserName + "\n");
            }
        }

        private void button_startListen_Click(object sender, EventArgs e)
        {
            ss = new ServerSocket(IPAddress.Any, int.Parse(this.textBox_port.Text), 10, 1024, 1024);
            string initMsg = String.Empty;
            if(ss.initListen(out initMsg))
            {
                this.textBox_status.Text = initMsg;
            }
            
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            string msg = this.textBox_send.Text;
            if (ss.SendClientMsg(msg))
            {
                this.textBox_status.Text = "send success..";
            }
            else
            {
                this.textBox_status.Text = "send failed..";
            }
        }

        //将publiser传入的msg进行显示
        private void showRecvMsg(object sender, Message msg)
        {
            //this.textBox_receive.Text = msg.Msg;
            this.textBox_receive.Invoke(new Action(() => this.textBox_receive.Text = msg.ChatMsg));
        }

        private void button_receive_Click(object sender, EventArgs e)   
        {
            //ss.ReceiveMsg(this.textBox_receive, this.textBox_status);     //textbox传入函数，通过委托跨线程访问

            //ss.recvEvent += showRecvMsg;          //客户端将委托绑定事件，通过类Message封装接收的消息，EventHandler从publisher传入observer
            

        }

        private void button_dispose_Click(object sender, EventArgs e)
        {
            if(ss.Dispose())
                this.textBox_status.Text = "disconnected..";
        }

        private async void button_connectClient_Click(object sender, EventArgs e)
        {
            if(await ss.ConnectClient())
                textBox_status.Text = "connected..";
        }

        private void button_stopRecv_Click(object sender, EventArgs e)
        {
            if(ss.DisConnect())
                textBox_status.Text = "recv stop..";
        }
    }
}
