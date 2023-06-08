namespace Server.UIL.View
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
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.button_disconnect = new System.Windows.Forms.Button();
            this.button_connectClient = new System.Windows.Forms.Button();
            this.button_stopRecv = new System.Windows.Forms.Button();
            this.textBox_clients = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_send
            // 
            this.button_send.Location = new System.Drawing.Point(217, 134);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(119, 41);
            this.button_send.TabIndex = 0;
            this.button_send.Text = "send";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // textBox_receive
            // 
            this.textBox_receive.Location = new System.Drawing.Point(402, 12);
            this.textBox_receive.Multiline = true;
            this.textBox_receive.Name = "textBox_receive";
            this.textBox_receive.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_receive.Size = new System.Drawing.Size(427, 235);
            this.textBox_receive.TabIndex = 1;
            // 
            // textBox_send
            // 
            this.textBox_send.Location = new System.Drawing.Point(402, 253);
            this.textBox_send.Multiline = true;
            this.textBox_send.Name = "textBox_send";
            this.textBox_send.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_send.Size = new System.Drawing.Size(427, 235);
            this.textBox_send.TabIndex = 2;
            // 
            // button_receive
            // 
            this.button_receive.Location = new System.Drawing.Point(217, 196);
            this.button_receive.Name = "button_receive";
            this.button_receive.Size = new System.Drawing.Size(119, 38);
            this.button_receive.TabIndex = 3;
            this.button_receive.Text = "receive";
            this.button_receive.UseVisualStyleBackColor = true;
            this.button_receive.Click += new System.EventHandler(this.button_receive_Click);
            // 
            // textBox_status
            // 
            this.textBox_status.Location = new System.Drawing.Point(10, 467);
            this.textBox_status.Name = "textBox_status";
            this.textBox_status.Size = new System.Drawing.Size(327, 21);
            this.textBox_status.TabIndex = 4;
            // 
            // button_startListen
            // 
            this.button_startListen.Location = new System.Drawing.Point(217, 12);
            this.button_startListen.Name = "button_startListen";
            this.button_startListen.Size = new System.Drawing.Size(119, 42);
            this.button_startListen.TabIndex = 6;
            this.button_startListen.Text = "启动监听";
            this.button_startListen.UseVisualStyleBackColor = true;
            this.button_startListen.Click += new System.EventHandler(this.button_startListen_Click);
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(8, 20);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(166, 21);
            this.textBox_port.TabIndex = 8;
            // 
            // button_disconnect
            // 
            this.button_disconnect.Location = new System.Drawing.Point(217, 314);
            this.button_disconnect.Name = "button_disconnect";
            this.button_disconnect.Size = new System.Drawing.Size(119, 33);
            this.button_disconnect.TabIndex = 9;
            this.button_disconnect.Text = "断开";
            this.button_disconnect.UseVisualStyleBackColor = true;
            this.button_disconnect.Click += new System.EventHandler(this.button_disconncet_Click);
            // 
            // button_connectClient
            // 
            this.button_connectClient.Location = new System.Drawing.Point(217, 69);
            this.button_connectClient.Name = "button_connectClient";
            this.button_connectClient.Size = new System.Drawing.Size(119, 45);
            this.button_connectClient.TabIndex = 10;
            this.button_connectClient.Text = "连接客户端";
            this.button_connectClient.UseVisualStyleBackColor = true;
            this.button_connectClient.Click += new System.EventHandler(this.button_connectClient_Click);
            // 
            // button_stopRecv
            // 
            this.button_stopRecv.Location = new System.Drawing.Point(217, 253);
            this.button_stopRecv.Name = "button_stopRecv";
            this.button_stopRecv.Size = new System.Drawing.Size(119, 42);
            this.button_stopRecv.TabIndex = 11;
            this.button_stopRecv.Text = "stop receive";
            this.button_stopRecv.UseVisualStyleBackColor = true;
            this.button_stopRecv.Click += new System.EventHandler(this.button_stopRecv_Click);
            // 
            // textBox_clients
            // 
            this.textBox_clients.Location = new System.Drawing.Point(5, 20);
            this.textBox_clients.Multiline = true;
            this.textBox_clients.Name = "textBox_clients";
            this.textBox_clients.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_clients.Size = new System.Drawing.Size(169, 368);
            this.textBox_clients.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_clients);
            this.groupBox1.Location = new System.Drawing.Point(12, 69);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(178, 393);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "connected clients";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_port);
            this.groupBox2.Location = new System.Drawing.Point(12, 3);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(178, 50);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "listenPort";
            // 
            // FormServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 497);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_stopRecv);
            this.Controls.Add(this.button_connectClient);
            this.Controls.Add(this.button_disconnect);
            this.Controls.Add(this.button_startListen);
            this.Controls.Add(this.textBox_status);
            this.Controls.Add(this.button_receive);
            this.Controls.Add(this.textBox_send);
            this.Controls.Add(this.textBox_receive);
            this.Controls.Add(this.button_send);
            this.Name = "FormServer";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.Button button_disconnect;
        private System.Windows.Forms.Button button_connectClient;
        private System.Windows.Forms.Button button_stopRecv;
        private System.Windows.Forms.TextBox textBox_clients;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

