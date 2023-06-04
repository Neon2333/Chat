namespace SocketDemo
{
    partial class FormServer
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
            this.button_send = new System.Windows.Forms.Button();
            this.textBox_receive = new System.Windows.Forms.TextBox();
            this.textBox_send = new System.Windows.Forms.TextBox();
            this.button_receive = new System.Windows.Forms.Button();
            this.textBox_status = new System.Windows.Forms.TextBox();
            this.button_startListen = new System.Windows.Forms.Button();
            this.textBox_ip = new System.Windows.Forms.TextBox();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.button_dispose = new System.Windows.Forms.Button();
            this.button_connectClient = new System.Windows.Forms.Button();
            this.button_stopRecv = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_send
            // 
            this.button_send.Location = new System.Drawing.Point(289, 232);
            this.button_send.Margin = new System.Windows.Forms.Padding(4);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(159, 76);
            this.button_send.TabIndex = 0;
            this.button_send.Text = "send";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // textBox_receive
            // 
            this.textBox_receive.Location = new System.Drawing.Point(536, 15);
            this.textBox_receive.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_receive.Multiline = true;
            this.textBox_receive.Name = "textBox_receive";
            this.textBox_receive.Size = new System.Drawing.Size(568, 293);
            this.textBox_receive.TabIndex = 1;
            // 
            // textBox_send
            // 
            this.textBox_send.Location = new System.Drawing.Point(536, 316);
            this.textBox_send.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_send.Multiline = true;
            this.textBox_send.Name = "textBox_send";
            this.textBox_send.Size = new System.Drawing.Size(568, 293);
            this.textBox_send.TabIndex = 2;
            // 
            // button_receive
            // 
            this.button_receive.Location = new System.Drawing.Point(289, 345);
            this.button_receive.Margin = new System.Windows.Forms.Padding(4);
            this.button_receive.Name = "button_receive";
            this.button_receive.Size = new System.Drawing.Size(159, 83);
            this.button_receive.TabIndex = 3;
            this.button_receive.Text = "receive";
            this.button_receive.UseVisualStyleBackColor = true;
            this.button_receive.Click += new System.EventHandler(this.button_receive_Click);
            // 
            // textBox_status
            // 
            this.textBox_status.Location = new System.Drawing.Point(16, 584);
            this.textBox_status.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_status.Name = "textBox_status";
            this.textBox_status.ReadOnly = true;
            this.textBox_status.Size = new System.Drawing.Size(432, 25);
            this.textBox_status.TabIndex = 4;
            // 
            // button_startListen
            // 
            this.button_startListen.Location = new System.Drawing.Point(289, 15);
            this.button_startListen.Margin = new System.Windows.Forms.Padding(4);
            this.button_startListen.Name = "button_startListen";
            this.button_startListen.Size = new System.Drawing.Size(159, 76);
            this.button_startListen.TabIndex = 6;
            this.button_startListen.Text = "启动监听";
            this.button_startListen.UseVisualStyleBackColor = true;
            this.button_startListen.Click += new System.EventHandler(this.button_startListen_Click);
            // 
            // textBox_ip
            // 
            this.textBox_ip.Location = new System.Drawing.Point(16, 15);
            this.textBox_ip.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_ip.Name = "textBox_ip";
            this.textBox_ip.Size = new System.Drawing.Size(193, 25);
            this.textBox_ip.TabIndex = 7;
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(16, 55);
            this.textBox_port.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(193, 25);
            this.textBox_port.TabIndex = 8;
            // 
            // button_dispose
            // 
            this.button_dispose.Location = new System.Drawing.Point(289, 464);
            this.button_dispose.Margin = new System.Windows.Forms.Padding(4);
            this.button_dispose.Name = "button_dispose";
            this.button_dispose.Size = new System.Drawing.Size(159, 80);
            this.button_dispose.TabIndex = 9;
            this.button_dispose.Text = "断开";
            this.button_dispose.UseVisualStyleBackColor = true;
            this.button_dispose.Click += new System.EventHandler(this.button_dispose_Click);
            // 
            // button_connectClient
            // 
            this.button_connectClient.Location = new System.Drawing.Point(289, 122);
            this.button_connectClient.Margin = new System.Windows.Forms.Padding(4);
            this.button_connectClient.Name = "button_connectClient";
            this.button_connectClient.Size = new System.Drawing.Size(159, 77);
            this.button_connectClient.TabIndex = 10;
            this.button_connectClient.Text = "连接客户端";
            this.button_connectClient.UseVisualStyleBackColor = true;
            this.button_connectClient.Click += new System.EventHandler(this.button_connectClient_Click);
            // 
            // button_stopRecv
            // 
            this.button_stopRecv.Location = new System.Drawing.Point(102, 345);
            this.button_stopRecv.Margin = new System.Windows.Forms.Padding(4);
            this.button_stopRecv.Name = "button_stopRecv";
            this.button_stopRecv.Size = new System.Drawing.Size(159, 83);
            this.button_stopRecv.TabIndex = 11;
            this.button_stopRecv.Text = "stop receive";
            this.button_stopRecv.UseVisualStyleBackColor = true;
            this.button_stopRecv.Click += new System.EventHandler(this.button_stopRecv_Click);
            // 
            // FormServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 621);
            this.Controls.Add(this.button_stopRecv);
            this.Controls.Add(this.button_connectClient);
            this.Controls.Add(this.button_dispose);
            this.Controls.Add(this.textBox_port);
            this.Controls.Add(this.textBox_ip);
            this.Controls.Add(this.button_startListen);
            this.Controls.Add(this.textBox_status);
            this.Controls.Add(this.button_receive);
            this.Controls.Add(this.textBox_send);
            this.Controls.Add(this.textBox_receive);
            this.Controls.Add(this.button_send);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormServer";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.TextBox textBox_receive;
        private System.Windows.Forms.TextBox textBox_send;
        private System.Windows.Forms.Button button_receive;
        private System.Windows.Forms.TextBox textBox_status;
        private System.Windows.Forms.Button button_startListen;
        private System.Windows.Forms.TextBox textBox_ip;
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.Button button_dispose;
        private System.Windows.Forms.Button button_connectClient;
        private System.Windows.Forms.Button button_stopRecv;
    }
}

