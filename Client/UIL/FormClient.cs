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

namespace Client.UIL
{
    public partial class FormClient : DevExpress.XtraEditors.XtraForm
    {
        public FormClient()
        {
            InitializeComponent();

        }

        private void simpleButton_recv_Click(object sender, EventArgs e)
        {
            Socket ss = Client.Communication.ClientSocket.ConnectSvr();
            //Server传来过来的byte[]到Client反序列化时会报找不到程序集错误。
            //因为Server传过来的数据包含命名空间。
            //https://blog.csdn.net/w21fanfan1314/article/details/8280582
            this.textEdit_recv.Text = Client.Communication.ClientSocket.RecvMsg(ss);
        }
    }
}