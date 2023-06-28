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
        public FrmConfig()
        {
            InitializeComponent();
            textEdit_svrIP.Text = ClientSocket.SvrIP;
            textEdit_svrPort.Text = ClientSocket.SvrPort.ToString();
        }

        private void simpleButton_apply_Click(object sender, EventArgs e)
        {
            ClientSocket.SvrIP = textEdit_svrIP.Text.Trim();
            ClientSocket.SvrPort = Convert.ToInt32(textEdit_svrPort.Text.Trim());

            this.Close();
        }

        private void simpleButton_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
