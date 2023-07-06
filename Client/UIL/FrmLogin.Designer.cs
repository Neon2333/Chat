
namespace Client.UIL
{
    partial class FrmLogin
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
            this.components = new System.ComponentModel.Container();
            this.labelControl_usrNameLogin = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_usrNameLogin = new DevExpress.XtraEditors.TextEdit();
            this.textEdit_pwdLogin = new DevExpress.XtraEditors.TextEdit();
            this.labelControl_pwdLogin = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton_signIn = new DevExpress.XtraEditors.SimpleButton();
            this.checkEdit_savePwd = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl_config = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_signUp = new DevExpress.XtraEditors.LabelControl();
            this.checkEdit_autoLogin = new DevExpress.XtraEditors.CheckEdit();
            this.textEdit_socketError = new DevExpress.XtraEditors.TextEdit();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_usrNameLogin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_pwdLogin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_savePwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_autoLogin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_socketError.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl_usrNameLogin
            // 
            this.labelControl_usrNameLogin.Location = new System.Drawing.Point(88, 90);
            this.labelControl_usrNameLogin.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.labelControl_usrNameLogin.Name = "labelControl_usrNameLogin";
            this.labelControl_usrNameLogin.Size = new System.Drawing.Size(45, 18);
            this.labelControl_usrNameLogin.TabIndex = 0;
            this.labelControl_usrNameLogin.Text = "用户名";
            // 
            // textEdit_usrNameLogin
            // 
            this.textEdit_usrNameLogin.Location = new System.Drawing.Point(226, 86);
            this.textEdit_usrNameLogin.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.textEdit_usrNameLogin.Name = "textEdit_usrNameLogin";
            this.textEdit_usrNameLogin.Size = new System.Drawing.Size(385, 24);
            this.textEdit_usrNameLogin.TabIndex = 0;
            // 
            // textEdit_pwdLogin
            // 
            this.textEdit_pwdLogin.Location = new System.Drawing.Point(226, 195);
            this.textEdit_pwdLogin.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.textEdit_pwdLogin.Name = "textEdit_pwdLogin";
            this.textEdit_pwdLogin.Properties.PasswordChar = '*';
            this.textEdit_pwdLogin.Size = new System.Drawing.Size(385, 24);
            this.textEdit_pwdLogin.TabIndex = 1;
            // 
            // labelControl_pwdLogin
            // 
            this.labelControl_pwdLogin.Location = new System.Drawing.Point(88, 200);
            this.labelControl_pwdLogin.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.labelControl_pwdLogin.Name = "labelControl_pwdLogin";
            this.labelControl_pwdLogin.Size = new System.Drawing.Size(30, 18);
            this.labelControl_pwdLogin.TabIndex = 2;
            this.labelControl_pwdLogin.Text = "密码";
            // 
            // simpleButton_signIn
            // 
            this.simpleButton_signIn.Location = new System.Drawing.Point(226, 344);
            this.simpleButton_signIn.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.simpleButton_signIn.Name = "simpleButton_signIn";
            this.simpleButton_signIn.Size = new System.Drawing.Size(385, 78);
            this.simpleButton_signIn.TabIndex = 4;
            this.simpleButton_signIn.Text = "登录";
            this.simpleButton_signIn.Click += new System.EventHandler(this.simpleButton_signIn_Click);
            // 
            // checkEdit_savePwd
            // 
            this.checkEdit_savePwd.Location = new System.Drawing.Point(464, 261);
            this.checkEdit_savePwd.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.checkEdit_savePwd.Name = "checkEdit_savePwd";
            this.checkEdit_savePwd.Properties.Caption = "记住密码";
            this.checkEdit_savePwd.Size = new System.Drawing.Size(148, 24);
            this.checkEdit_savePwd.TabIndex = 3;
            // 
            // labelControl_config
            // 
            this.labelControl_config.Location = new System.Drawing.Point(680, 492);
            this.labelControl_config.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.labelControl_config.Name = "labelControl_config";
            this.labelControl_config.Size = new System.Drawing.Size(60, 18);
            this.labelControl_config.TabIndex = 6;
            this.labelControl_config.Text = "网络配置";
            this.labelControl_config.Click += new System.EventHandler(this.labelControl_config_Click);
            // 
            // labelControl_signUp
            // 
            this.labelControl_signUp.Location = new System.Drawing.Point(19, 492);
            this.labelControl_signUp.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.labelControl_signUp.Name = "labelControl_signUp";
            this.labelControl_signUp.Size = new System.Drawing.Size(60, 18);
            this.labelControl_signUp.TabIndex = 5;
            this.labelControl_signUp.Text = "注册账号";
            this.labelControl_signUp.Click += new System.EventHandler(this.labelControl_signUp_Click);
            // 
            // checkEdit_autoLogin
            // 
            this.checkEdit_autoLogin.Location = new System.Drawing.Point(226, 261);
            this.checkEdit_autoLogin.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.checkEdit_autoLogin.Name = "checkEdit_autoLogin";
            this.checkEdit_autoLogin.Properties.Caption = "自动登录";
            this.checkEdit_autoLogin.Size = new System.Drawing.Size(148, 24);
            this.checkEdit_autoLogin.TabIndex = 2;
            // 
            // textEdit_socketError
            // 
            this.textEdit_socketError.Location = new System.Drawing.Point(140, 469);
            this.textEdit_socketError.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.textEdit_socketError.Name = "textEdit_socketError";
            this.textEdit_socketError.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.textEdit_socketError.Properties.Appearance.Options.UseBackColor = true;
            this.textEdit_socketError.Properties.AutoHeight = false;
            this.textEdit_socketError.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.textEdit_socketError.Size = new System.Drawing.Size(510, 51);
            this.textEdit_socketError.TabIndex = 7;
            // 
            // FrmLogin
            // 
            this.AcceptButton = this.simpleButton_signIn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 543);
            this.Controls.Add(this.textEdit_socketError);
            this.Controls.Add(this.checkEdit_autoLogin);
            this.Controls.Add(this.labelControl_signUp);
            this.Controls.Add(this.labelControl_config);
            this.Controls.Add(this.checkEdit_savePwd);
            this.Controls.Add(this.simpleButton_signIn);
            this.Controls.Add(this.textEdit_pwdLogin);
            this.Controls.Add(this.labelControl_pwdLogin);
            this.Controls.Add(this.textEdit_usrNameLogin);
            this.Controls.Add(this.labelControl_usrNameLogin);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_usrNameLogin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_pwdLogin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_savePwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_autoLogin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_socketError.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl_usrNameLogin;
        private DevExpress.XtraEditors.TextEdit textEdit_usrNameLogin;
        private DevExpress.XtraEditors.TextEdit textEdit_pwdLogin;
        private DevExpress.XtraEditors.LabelControl labelControl_pwdLogin;
        private DevExpress.XtraEditors.SimpleButton simpleButton_signIn;
        private DevExpress.XtraEditors.CheckEdit checkEdit_savePwd;
        private DevExpress.XtraEditors.LabelControl labelControl_config;
        private DevExpress.XtraEditors.LabelControl labelControl_signUp;
        private DevExpress.XtraEditors.CheckEdit checkEdit_autoLogin;
        private DevExpress.XtraEditors.TextEdit textEdit_socketError;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
    }
}