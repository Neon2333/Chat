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
using Client.Communication;
using Client.BLL;

namespace Client.UIL
{
    public partial class FrmLogin : DevExpress.XtraEditors.XtraForm
    {
        ClientSocket cc;

        private bool login = false;
        public bool Login { get => login; set => login = value; }


        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            cc = new ClientSocket();

            if (!cc.ConnectSvr())
            {
                ShowSocketError();
                return;
            }
        }

        private void simpleButton_signIn_Click(object sender, EventArgs e)
        {
            if (login)
            {
                this.Close();
            }



        }

        private void labelControl_signUp_Click(object sender, EventArgs e)
        {
            FrmSignUp frmSignUp = new FrmSignUp();
            frmSignUp.eventApplyUsrName += frmSignUp.GetUserName;
            frmSignUp.eventApplyPwd += frmSignUp.GetUerPwd;
            frmSignUp.ShowDialog();
        }

        
        private void labelControl_config_Click(object sender, EventArgs e)
        {
            FrmConfig frmConfig = new FrmConfig();
            frmConfig.eventApplySvrIP += frmConfig.GetSvrIP;
            frmConfig.eventApplySvrPort += frmConfig.GetSvrPort;
            frmConfig.ShowDialog();
        }


        

        private void ShowSocketError()
        {
            textEdit_socketError.BackColor = Color.LightYellow;
            textEdit_socketError.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            textEdit_socketError.Text = "网络连接错误，请检查网络连接..";
        }

        private void ClearSocketError()
        {
            textEdit_socketError.BackColor = Color.FromArgb(240, 240, 240);
            textEdit_socketError.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            textEdit_socketError.Text = "";
        }

        



    }
}