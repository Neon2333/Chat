using Client.Communication;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.UIL;
using Client.BLL;
using ChatModel;


namespace Client.UIL
{
    public partial class FrmClientList : DevExpress.XtraEditors.XtraForm
    {
        private ClientSocket clientSocket = new ClientSocket();     //客户端通信类
        public ClientSocket ClientSocket { get => clientSocket; set => clientSocket = value; }

        

        public FrmClientList()
        {
            InitializeComponent();
            initFrm();
        }

        private void initFrm()
        {
            this.gridControl_userSignInList.DataSource = ClientUserSignIn.UserSignInList;
        }

        //后面将所有事件加以整理
        public void initEvent()
        {
            ProcessRecvPackage processRecvPackage = new ProcessRecvPackage();
            processRecvPackage.recvUserMessageEvent += showUserMessage;
        }

        public void showUserMessage(object sender, UserMessage userMessage)
        {
            textEdit_recv.BeginInvoke(new Action(() => textEdit_recv.Text += ($"{userMessage.SendTime} ,{userMessage.UserNameSend}: {userMessage.ChatMsg}" + "\r\n")));
        }


    }
}