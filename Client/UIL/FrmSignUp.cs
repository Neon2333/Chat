using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Client.BLL;

namespace Client.UIL
{
    public partial class FrmSignUp : DevExpress.XtraEditors.XtraForm
    {
        public FrmSignUp()
        {
            InitializeComponent();
        }

        ClientUserSignUp clientUserSignUp = new ClientUserSignUp();     //注册业务类实例
        private void simpleButton_applySignUp_Click(object sender, EventArgs e)
        {
            if (textEdit_pwdSignUp.Text.Equals(textEdit_confirmPwdSignUp.Text))
            {
                ClearPwdError();
                if (clientUserSignUp.DoSignUp(textEdit_usrNameSignUp.Text.Trim(), textEdit_pwdSignUp.Text.Trim(), Timeout.Infinite))
                {
                    MessageBox.Show("注册成功！");
                    this.Close();
                }
                else
                {
                    //防止超时返回false后，SignUp内的SendTask和RecvTask还在线程中执行
                    ClientUserSignIn.defaultUserSignIn.CancelSendSource.Cancel();
                    ClientUserSignIn.defaultUserSignIn.CancelRecvSource.Cancel();

                    MessageBox.Show("注册失败！");
                    this.Close();
                }
            }
            else
            {
                ShowPwdError();
                textEdit_pwdSignUp.Text = "";
                textEdit_confirmPwdSignUp.Text = "";
            }
        }

        private void simpleButton_cancelSignUp_Click(object sender, EventArgs e)
        {
            ClientUserSignIn.defaultUserSignIn.CancelSendSource.Cancel();
            ClientUserSignIn.defaultUserSignIn.CancelRecvSource.Cancel();

            this.Close();
        }

        private void ShowPwdError()
        {
            textEdit_pwdError.BackColor = Color.LightYellow;
            textEdit_pwdError.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            textEdit_pwdError.Text = "密码不一致，请重新输入..";
        }

        private void ClearPwdError()
        {
            textEdit_pwdError.BackColor = Color.FromArgb(240, 240, 240);
            textEdit_pwdError.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            textEdit_pwdError.Text = "";
        }
    }
}