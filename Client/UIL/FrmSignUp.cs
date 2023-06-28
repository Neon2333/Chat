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
        //public EventHandler<string> eventApplyUsrNameSignUp;  //注册，应用用户名
        //public EventHandler<string> eventApplyPwdSignUp;      //注册，应用密码
        //public EventHandler<bool> eventSignUp;    //注册事件

        public FrmSignUp()
        {
            InitializeComponent();
        }

        private void simpleButton_apply_Click(object sender, EventArgs e)
        {
            if (textEdit_pwdSignUp.Text.Equals(textEdit_confirmPwdSignUp.Text))
            {
                ClearPwdError();

                //注册
                if (ClientUserSignUp.SignUp(textEdit_usrNameSignUp.Text.Trim(), textEdit_pwdSignUp.Text.Trim()))
                {
                    //MessageBox.Show("注册成功！");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("注册失败！");
                }
            }
            else
            {
                ShowPwdError();
                textEdit_pwdSignUp.Text = "";
                textEdit_confirmPwdSignUp.Text = "";
            }

        }


        //public void GetUserName(object sender, string usrName)
        //{
        //    ClientSignUp.UsrName = usrName;
        //}

        //public void GetUerPwd(object sender, string usrPwd)
        //{
        //    ClientSignUp.UsrPwd = usrPwd;
        //}

        private void simpleButton_cancel_Click(object sender, EventArgs e)
        {
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