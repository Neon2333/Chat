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
using System.Threading;

namespace Client.UIL
{
    public partial class FrmLogin : DevExpress.XtraEditors.XtraForm
    {
        public static ClientUserSignIn clientUserSignIn;    //登录业务类实例
        private bool login = false;
        public bool Login { get => login; set => login = value; }
        
        private bool ifConnect = false;  //是否建立连接

        public FrmLogin()
        {
            InitializeComponent();
            clientUserSignIn = new ClientUserSignIn();
        }

        public void init()
        {

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            Task task = Task.Run(()=> {
                while (!ifConnect)
                {
                   ifConnect = ClientUserSignIn.clientSocket.ConnectSvr();
                   textEdit_socketError.BeginInvoke(new Action(ShowConnectError));
                   if (ifConnect)
                    {
                        ClientUserSignIn.defaultUserSignIn.ConnectTime = DateTime.Now;  //连接连上的时间
                       break;
                    }
                    System.Threading.Thread.Sleep(3000);
                }
            });
            
        }

        private void simpleButton_signIn_Click(object sender, EventArgs e)
        {
            string usrName = textEdit_usrNameLogin.Text.Trim();
            string usrPwd = textEdit_pwdLogin.Text.Trim();
            if(clientUserSignIn.DoSignIn(usrName, usrPwd, Timeout.Infinite))
            {
                login = true;
            }

            //if (login)
            //{
            //    this.Close();
            //    //FrmClientList frmClientList = new FrmClientList();
            //    //frmClientList.Show();
            //}



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
            //ShowSocketError();
        }

        /// <summary>
        /// 显示网络是否连接
        /// </summary>
        /// <param name="ifConnect"></param>
        private void ShowConnectError()
        {
            if (ifConnect)
            {
                textEdit_socketError.BackColor = Color.FromArgb(240, 240, 240);
                textEdit_socketError.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                textEdit_socketError.Text = "";
                return;
            }
            else
            {
                textEdit_socketError.BackColor = Color.LightYellow;
                textEdit_socketError.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
                textEdit_socketError.Text = "网络连接错误，请检查网络连接..";
                return;
            }
        }

    }
}