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
        ClientUserSignIn clientUserSignIn;
        //public ClientSocket socketUserSignIn = new ClientSocket();

        private bool login = false;
        public bool Login { get => login; set => login = value; }


        public FrmLogin()
        {
            InitializeComponent();
            clientUserSignIn = new ClientUserSignIn();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            if (!ClientUserSignIn.clientSocket.ConnectSvr())
            {
                ShowSocketError();
                return;
            }

        }

        private void simpleButton_signIn_Click(object sender, EventArgs e)
        {
            ClientUserSignIn.UsrName = textEdit_usrNameLogin.Text.Trim();
            ClientUserSignIn.UsrPwd = textEdit_pwdLogin.Text.Trim();

            if (login)
            {
                this.Close();
                FrmClientList frmClientList = new FrmClientList();
                frmClientList.Show();
            }



        }

        private void labelControl_signUp_Click(object sender, EventArgs e)
        {
            FrmSignUp frmSignUp = new FrmSignUp();
            //frmSignUp.eventApplyUsrNameSignUp += frmSignUp.GetUserName;
            //frmSignUp.eventApplyPwdSignUp += frmSignUp.GetUerPwd;
            frmSignUp.ShowDialog();
        }

        
        private void labelControl_config_Click(object sender, EventArgs e)
        {
            FrmConfig frmConfig = new FrmConfig();
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