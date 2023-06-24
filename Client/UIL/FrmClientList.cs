using Client.Communication;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.UIL.Model;

namespace Client.UIL
{
    public partial class FrmClientList : DevExpress.XtraEditors.XtraForm
    {
        private ClientSocket clientSocket = new ClientSocket();
        public ClientSocket ClientSocket { get => clientSocket; set => clientSocket = value; }

        public FrmClientList()
        {
            InitializeComponent();

            ClientSocket clientSocket = new ClientSocket();
            UserInfoSignIn uifs = new UserInfoSignIn();
            Task.Run(() => clientSocket.RecvData(uifs));

            uifs.recvEvent += showChatMsg;
        }

        private void showChatMsg(object sender, byte[] data)
        {
            UserMessage um = SerializeHelper.DeserializeObjWithXmlBytes<UserMessage>(data);
            textEdit_recv.BeginInvoke(new Action(() => textEdit_recv.Text += ($"{um.SendTime} ,{um.UserNameSend}: {um.ChatMsg}" + "\r\n")));
        }
    }
}