
namespace Client.UIL
{
    partial class FrmSignUp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelControl_usrNameSignUp = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_usrNameSignUp = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_pwdSignUp = new DevExpress.XtraEditors.TextEdit();
            this.labelControl_pwdSignUp = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_confirmPwdSignUp = new DevExpress.XtraEditors.TextEdit();
            this.labelControl_confirmPwdSignUp = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton_apply = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_cancel = new DevExpress.XtraEditors.SimpleButton();
            this.textEdit_pwdError = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_usrNameSignUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_pwdSignUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_confirmPwdSignUp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_pwdError.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl_usrNameSignUp
            // 
            this.labelControl_usrNameSignUp.Location = new System.Drawing.Point(129, 50);
            this.labelControl_usrNameSignUp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl_usrNameSignUp.Name = "labelControl_usrNameSignUp";
            this.labelControl_usrNameSignUp.Size = new System.Drawing.Size(45, 18);
            this.labelControl_usrNameSignUp.TabIndex = 0;
            this.labelControl_usrNameSignUp.Text = "用户名";
            // 
            // textEdit_usrNameSignUp
            // 
            this.textEdit_usrNameSignUp.Location = new System.Drawing.Point(290, 46);
            this.textEdit_usrNameSignUp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textEdit_usrNameSignUp.Name = "textEdit_usrNameSignUp";
            this.textEdit_usrNameSignUp.Size = new System.Drawing.Size(289, 24);
            this.textEdit_usrNameSignUp.TabIndex = 1;
            // 
            // textEdit_pwdSignUp
            // 
            this.textEdit_pwdSignUp.Location = new System.Drawing.Point(290, 111);
            this.textEdit_pwdSignUp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textEdit_pwdSignUp.Name = "textEdit_pwdSignUp";
            this.textEdit_pwdSignUp.Properties.PasswordChar = '*';
            this.textEdit_pwdSignUp.Size = new System.Drawing.Size(289, 24);
            this.textEdit_pwdSignUp.TabIndex = 3;
            // 
            // labelControl_pwdSignUp
            // 
            this.labelControl_pwdSignUp.Location = new System.Drawing.Point(129, 115);
            this.labelControl_pwdSignUp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl_pwdSignUp.Name = "labelControl_pwdSignUp";
            this.labelControl_pwdSignUp.Size = new System.Drawing.Size(30, 18);
            this.labelControl_pwdSignUp.TabIndex = 2;
            this.labelControl_pwdSignUp.Text = "密码";
            // 
            // textEdit_confirmPwdSignUp
            // 
            this.textEdit_confirmPwdSignUp.Location = new System.Drawing.Point(290, 180);
            this.textEdit_confirmPwdSignUp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textEdit_confirmPwdSignUp.Name = "textEdit_confirmPwdSignUp";
            this.textEdit_confirmPwdSignUp.Properties.PasswordChar = '*';
            this.textEdit_confirmPwdSignUp.Size = new System.Drawing.Size(289, 24);
            this.textEdit_confirmPwdSignUp.TabIndex = 5;
            // 
            // labelControl_confirmPwdSignUp
            // 
            this.labelControl_confirmPwdSignUp.Location = new System.Drawing.Point(129, 184);
            this.labelControl_confirmPwdSignUp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelControl_confirmPwdSignUp.Name = "labelControl_confirmPwdSignUp";
            this.labelControl_confirmPwdSignUp.Size = new System.Drawing.Size(60, 18);
            this.labelControl_confirmPwdSignUp.TabIndex = 4;
            this.labelControl_confirmPwdSignUp.Text = "确认密码";
            // 
            // simpleButton_apply
            // 
            this.simpleButton_apply.Location = new System.Drawing.Point(154, 281);
            this.simpleButton_apply.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.simpleButton_apply.Name = "simpleButton_apply";
            this.simpleButton_apply.Size = new System.Drawing.Size(181, 72);
            this.simpleButton_apply.TabIndex = 6;
            this.simpleButton_apply.Text = "确定(&S)";
            this.simpleButton_apply.Click += new System.EventHandler(this.simpleButton_apply_Click);
            // 
            // simpleButton_cancel
            // 
            this.simpleButton_cancel.Location = new System.Drawing.Point(425, 281);
            this.simpleButton_cancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.simpleButton_cancel.Name = "simpleButton_cancel";
            this.simpleButton_cancel.Size = new System.Drawing.Size(181, 72);
            this.simpleButton_cancel.TabIndex = 7;
            this.simpleButton_cancel.Text = "取消(&X)";
            this.simpleButton_cancel.Click += new System.EventHandler(this.simpleButton_cancel_Click);
            // 
            // textEdit_pwdError
            // 
            this.textEdit_pwdError.Location = new System.Drawing.Point(129, 394);
            this.textEdit_pwdError.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textEdit_pwdError.Name = "textEdit_pwdError";
            this.textEdit_pwdError.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.textEdit_pwdError.Properties.Appearance.Options.UseBackColor = true;
            this.textEdit_pwdError.Properties.AutoHeight = false;
            this.textEdit_pwdError.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.textEdit_pwdError.Size = new System.Drawing.Size(478, 41);
            this.textEdit_pwdError.TabIndex = 8;
            // 
            // FrmSignUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 416);
            this.Controls.Add(this.textEdit_pwdError);
            this.Controls.Add(this.simpleButton_cancel);
            this.Controls.Add(this.simpleButton_apply);
            this.Controls.Add(this.textEdit_confirmPwdSignUp);
            this.Controls.Add(this.labelControl_confirmPwdSignUp);
            this.Controls.Add(this.textEdit_pwdSignUp);
            this.Controls.Add(this.labelControl_pwdSignUp);
            this.Controls.Add(this.textEdit_usrNameSignUp);
            this.Controls.Add(this.labelControl_usrNameSignUp);
            this.Name = "FrmSignUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSignUp";
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_usrNameSignUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_pwdSignUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_confirmPwdSignUp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_pwdError.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl_usrNameSignUp;
        private DevExpress.XtraEditors.TextEdit textEdit_usrNameSignUp;
        private DevExpress.XtraEditors.TextEdit textEdit_pwdSignUp;
        private DevExpress.XtraEditors.LabelControl labelControl_pwdSignUp;
        private DevExpress.XtraEditors.TextEdit textEdit_confirmPwdSignUp;
        private DevExpress.XtraEditors.LabelControl labelControl_confirmPwdSignUp;
        private DevExpress.XtraEditors.SimpleButton simpleButton_apply;
        private DevExpress.XtraEditors.SimpleButton simpleButton_cancel;
        private DevExpress.XtraEditors.TextEdit textEdit_pwdError;
    }
}