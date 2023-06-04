
namespace Client
{
    partial class FormClient
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1_IP = new System.Windows.Forms.TextBox();
            this.button_connectServer = new System.Windows.Forms.Button();
            this.textBox_sendMsg = new System.Windows.Forms.TextBox();
            this.textBox_recvMsg = new System.Windows.Forms.TextBox();
            this.button_sendMsg = new System.Windows.Forms.Button();
            this.button_recvMsg = new System.Windows.Forms.Button();
            this.textBox_status = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1_IP
            // 
            this.textBox1_IP.Location = new System.Drawing.Point(12, 44);
            this.textBox1_IP.Name = "textBox1_IP";
            this.textBox1_IP.Size = new System.Drawing.Size(198, 25);
            this.textBox1_IP.TabIndex = 0;
            // 
            // button_connectServer
            // 
            this.button_connectServer.Location = new System.Drawing.Point(286, 44);
            this.button_connectServer.Name = "button_connectServer";
            this.button_connectServer.Size = new System.Drawing.Size(176, 82);
            this.button_connectServer.TabIndex = 1;
            this.button_connectServer.Text = "连接服务器";
            this.button_connectServer.UseVisualStyleBackColor = true;
            // 
            // textBox_sendMsg
            // 
            this.textBox_sendMsg.Location = new System.Drawing.Point(561, 12);
            this.textBox_sendMsg.Multiline = true;
            this.textBox_sendMsg.Name = "textBox_sendMsg";
            this.textBox_sendMsg.Size = new System.Drawing.Size(481, 299);
            this.textBox_sendMsg.TabIndex = 2;
            // 
            // textBox_recvMsg
            // 
            this.textBox_recvMsg.Location = new System.Drawing.Point(561, 334);
            this.textBox_recvMsg.Multiline = true;
            this.textBox_recvMsg.Name = "textBox_recvMsg";
            this.textBox_recvMsg.Size = new System.Drawing.Size(481, 299);
            this.textBox_recvMsg.TabIndex = 3;
            // 
            // button_sendMsg
            // 
            this.button_sendMsg.Location = new System.Drawing.Point(286, 206);
            this.button_sendMsg.Name = "button_sendMsg";
            this.button_sendMsg.Size = new System.Drawing.Size(176, 91);
            this.button_sendMsg.TabIndex = 4;
            this.button_sendMsg.Text = "发送消息";
            this.button_sendMsg.UseVisualStyleBackColor = true;
            // 
            // button_recvMsg
            // 
            this.button_recvMsg.Location = new System.Drawing.Point(286, 392);
            this.button_recvMsg.Name = "button_recvMsg";
            this.button_recvMsg.Size = new System.Drawing.Size(176, 97);
            this.button_recvMsg.TabIndex = 5;
            this.button_recvMsg.Text = "接收消息";
            this.button_recvMsg.UseVisualStyleBackColor = true;
            // 
            // textBox_status
            // 
            this.textBox_status.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_status.Location = new System.Drawing.Point(12, 608);
            this.textBox_status.Name = "textBox_status";
            this.textBox_status.Size = new System.Drawing.Size(450, 25);
            this.textBox_status.TabIndex = 6;
            // 
            // FormClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 645);
            this.Controls.Add(this.textBox_status);
            this.Controls.Add(this.button_recvMsg);
            this.Controls.Add(this.button_sendMsg);
            this.Controls.Add(this.textBox_recvMsg);
            this.Controls.Add(this.textBox_sendMsg);
            this.Controls.Add(this.button_connectServer);
            this.Controls.Add(this.textBox1_IP);
            this.Name = "FormClient";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1_IP;
        private System.Windows.Forms.Button button_connectServer;
        private System.Windows.Forms.TextBox textBox_sendMsg;
        private System.Windows.Forms.TextBox textBox_recvMsg;
        private System.Windows.Forms.Button button_sendMsg;
        private System.Windows.Forms.Button button_recvMsg;
        private System.Windows.Forms.TextBox textBox_status;
    }
}

