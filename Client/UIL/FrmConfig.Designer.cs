
namespace Client.UIL
{
    partial class FrmConfig
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
            this.labelControl_svrIP = new DevExpress.XtraEditors.LabelControl();
            this.textEdit_svrIP = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton_apply = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_cancel = new DevExpress.XtraEditors.SimpleButton();
            this.textEdit_svrPort = new DevExpress.XtraEditors.TextEdit();
            this.labelControl_svrPort = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_svrIP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_svrPort.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl_svrIP
            // 
            this.labelControl_svrIP.Location = new System.Drawing.Point(85, 38);
            this.labelControl_svrIP.Name = "labelControl_svrIP";
            this.labelControl_svrIP.Size = new System.Drawing.Size(59, 18);
            this.labelControl_svrIP.TabIndex = 0;
            this.labelControl_svrIP.Text = "服务器IP";
            // 
            // textEdit_svrIP
            // 
            this.textEdit_svrIP.Location = new System.Drawing.Point(191, 35);
            this.textEdit_svrIP.Name = "textEdit_svrIP";
            this.textEdit_svrIP.Size = new System.Drawing.Size(264, 24);
            this.textEdit_svrIP.TabIndex = 1;
            // 
            // simpleButton_apply
            // 
            this.simpleButton_apply.Location = new System.Drawing.Point(113, 261);
            this.simpleButton_apply.Name = "simpleButton_apply";
            this.simpleButton_apply.Size = new System.Drawing.Size(144, 52);
            this.simpleButton_apply.TabIndex = 2;
            this.simpleButton_apply.Text = "应用(&S)";
            this.simpleButton_apply.Click += new System.EventHandler(this.simpleButton_apply_Click);
            // 
            // simpleButton_cancel
            // 
            this.simpleButton_cancel.Location = new System.Drawing.Point(311, 261);
            this.simpleButton_cancel.Name = "simpleButton_cancel";
            this.simpleButton_cancel.Size = new System.Drawing.Size(144, 52);
            this.simpleButton_cancel.TabIndex = 3;
            this.simpleButton_cancel.Text = "取消(&X)";
            this.simpleButton_cancel.Click += new System.EventHandler(this.simpleButton_cancel_Click);
            // 
            // textEdit_svrPort
            // 
            this.textEdit_svrPort.Location = new System.Drawing.Point(191, 96);
            this.textEdit_svrPort.Name = "textEdit_svrPort";
            this.textEdit_svrPort.Size = new System.Drawing.Size(264, 24);
            this.textEdit_svrPort.TabIndex = 5;
            // 
            // labelControl_svrPort
            // 
            this.labelControl_svrPort.Location = new System.Drawing.Point(85, 99);
            this.labelControl_svrPort.Name = "labelControl_svrPort";
            this.labelControl_svrPort.Size = new System.Drawing.Size(75, 18);
            this.labelControl_svrPort.TabIndex = 4;
            this.labelControl_svrPort.Text = "服务器端口";
            // 
            // FrmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 360);
            this.Controls.Add(this.textEdit_svrPort);
            this.Controls.Add(this.labelControl_svrPort);
            this.Controls.Add(this.simpleButton_cancel);
            this.Controls.Add(this.simpleButton_apply);
            this.Controls.Add(this.textEdit_svrIP);
            this.Controls.Add(this.labelControl_svrIP);
            this.Name = "FrmConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "配置";
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_svrIP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_svrPort.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl_svrIP;
        private DevExpress.XtraEditors.TextEdit textEdit_svrIP;
        private DevExpress.XtraEditors.SimpleButton simpleButton_apply;
        private DevExpress.XtraEditors.SimpleButton simpleButton_cancel;
        private DevExpress.XtraEditors.TextEdit textEdit_svrPort;
        private DevExpress.XtraEditors.LabelControl labelControl_svrPort;
    }
}