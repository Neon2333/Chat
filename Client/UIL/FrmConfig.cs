using Client.Communication;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.UIL
{
    public partial class FrmConfig : DevExpress.XtraEditors.XtraForm
    {
        public EventHandler<string> eventApplySvrIP;
        public EventHandler<int> eventApplySvrPort;


        public FrmConfig()
        {
            InitializeComponent();
            textEdit_svrIP.Text = ClientSocket.SvrIP;
            textEdit_svrPort.Text = ClientSocket.SvrPort.ToString();
        }

        private void simpleButton_apply_Click(object sender, EventArgs e)
        {
            eventApplySvrIP(sender, textEdit_svrIP.Text.Trim());
            eventApplySvrPort(sender, Convert.ToInt32(textEdit_svrPort.Text.Trim()));
            this.Close();
        }

        private void simpleButton_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void GetSvrIP(object sender, string ip)
        {
            ClientSocket.SvrIP = ip;
        }

        public void GetSvrPort(object sender, int port)
        {
            ClientSocket.SvrPort = port;
        }
    }
}
