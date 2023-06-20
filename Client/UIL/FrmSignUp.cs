using Client.BLL;
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
    public partial class FrmSignUp : DevExpress.XtraEditors.XtraForm
    {
        public EventHandler<string> eventApplyUsrName;
        public EventHandler<string> eventApplyPwd;

        public FrmSignUp()
        {
            InitializeComponent();
        }

        private void simpleButton_apply_Click(object sender, EventArgs e)
        {
            if (textEdit_pwdSignUp.Text.Equals(textEdit_confirmPwdSignUp.Text))
            {
                ClearPwdError();
                eventApplyUsrName(sender, textEdit_usrNameSignUp.Text);
                eventApplyPwd(sender, textEdit_pwdSignUp.Text);
            }
            else
            {
                ShowPwdError();
                textEdit_pwdSignUp.Text = "";
                textEdit_confirmPwdSignUp.Text = "";
            }

        }

        private void simpleButton_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void GetUserName(object sender, string usrName)
        {
            ClientSignUp.UsrName = usrName;
        }

        public void GetUerPwd(object sender, string usrPwd)
        {
            ClientSignUp.UsrPwd = usrPwd;
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