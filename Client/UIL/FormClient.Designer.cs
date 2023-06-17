
namespace Client.UIL
{
    partial class FormClient
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
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition4 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition5 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition6 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition3 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition4 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableSpan tableSpan2 = new DevExpress.XtraEditors.TableLayout.TableSpan();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement3 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement4 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            this.userPortrait = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.userName = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.tileView_userList = new DevExpress.XtraGrid.Views.Tile.TileView();
            this.textEdit_recv = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton_close = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_send = new DevExpress.XtraEditors.SimpleButton();
            this.textEdit_send = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton_recv = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileView_userList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_recv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_send.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // userPortrait
            // 
            this.userPortrait.Caption = "userPortrait";
            this.userPortrait.MinWidth = 25;
            this.userPortrait.Name = "userPortrait";
            this.userPortrait.Visible = true;
            this.userPortrait.VisibleIndex = 0;
            this.userPortrait.Width = 94;
            // 
            // userName
            // 
            this.userName.Caption = "userName";
            this.userName.MinWidth = 25;
            this.userName.Name = "userName";
            this.userName.Visible = true;
            this.userName.VisibleIndex = 1;
            this.userName.Width = 94;
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(8, 8);
            this.gridControl1.MainView = this.tileView_userList;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(350, 660);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.tileView_userList});
            // 
            // tileView_userList
            // 
            this.tileView_userList.Appearance.ItemNormal.BackColor = System.Drawing.Color.White;
            this.tileView_userList.Appearance.ItemNormal.Options.UseBackColor = true;
            this.tileView_userList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.userPortrait,
            this.userName});
            this.tileView_userList.GridControl = this.gridControl1;
            this.tileView_userList.Name = "tileView_userList";
            this.tileView_userList.OptionsTiles.GroupTextPadding = new System.Windows.Forms.Padding(0, -1, -1, -1);
            this.tileView_userList.OptionsTiles.ItemSize = new System.Drawing.Size(248, 60);
            this.tileView_userList.OptionsTiles.LayoutMode = DevExpress.XtraGrid.Views.Tile.TileViewLayoutMode.List;
            this.tileView_userList.OptionsTiles.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tileView_userList.TileColumns.Add(tableColumnDefinition4);
            this.tileView_userList.TileColumns.Add(tableColumnDefinition5);
            this.tileView_userList.TileColumns.Add(tableColumnDefinition6);
            this.tileView_userList.TileRows.Add(tableRowDefinition3);
            this.tileView_userList.TileRows.Add(tableRowDefinition4);
            tableSpan2.RowSpan = 2;
            this.tileView_userList.TileSpans.Add(tableSpan2);
            tileViewItemElement3.Column = this.userPortrait;
            tileViewItemElement3.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement3.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement3.Text = "userPortrait";
            tileViewItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement4.Column = this.userName;
            tileViewItemElement4.ColumnIndex = 1;
            tileViewItemElement4.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement4.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement4.Text = "userName";
            tileViewItemElement4.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            this.tileView_userList.TileTemplate.Add(tileViewItemElement3);
            this.tileView_userList.TileTemplate.Add(tileViewItemElement4);
            // 
            // textEdit_recv
            // 
            this.textEdit_recv.Location = new System.Drawing.Point(384, 12);
            this.textEdit_recv.Name = "textEdit_recv";
            this.textEdit_recv.Properties.AutoHeight = false;
            this.textEdit_recv.Size = new System.Drawing.Size(682, 449);
            this.textEdit_recv.TabIndex = 1;
            // 
            // simpleButton_close
            // 
            this.simpleButton_close.Location = new System.Drawing.Point(841, 638);
            this.simpleButton_close.Name = "simpleButton_close";
            this.simpleButton_close.Size = new System.Drawing.Size(105, 30);
            this.simpleButton_close.TabIndex = 2;
            this.simpleButton_close.Text = "关闭";
            // 
            // simpleButton_send
            // 
            this.simpleButton_send.Location = new System.Drawing.Point(952, 638);
            this.simpleButton_send.Name = "simpleButton_send";
            this.simpleButton_send.Size = new System.Drawing.Size(104, 30);
            this.simpleButton_send.TabIndex = 3;
            this.simpleButton_send.Text = "发送";
            // 
            // textEdit_send
            // 
            this.textEdit_send.Location = new System.Drawing.Point(384, 467);
            this.textEdit_send.Name = "textEdit_send";
            this.textEdit_send.Properties.AutoHeight = false;
            this.textEdit_send.Size = new System.Drawing.Size(682, 165);
            this.textEdit_send.TabIndex = 4;
            // 
            // simpleButton_recv
            // 
            this.simpleButton_recv.Location = new System.Drawing.Point(730, 638);
            this.simpleButton_recv.Name = "simpleButton_recv";
            this.simpleButton_recv.Size = new System.Drawing.Size(105, 30);
            this.simpleButton_recv.TabIndex = 5;
            this.simpleButton_recv.Text = "接收";
            this.simpleButton_recv.Click += new System.EventHandler(this.simpleButton_recv_Click);
            // 
            // FormClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 680);
            this.Controls.Add(this.simpleButton_recv);
            this.Controls.Add(this.textEdit_send);
            this.Controls.Add(this.simpleButton_send);
            this.Controls.Add(this.simpleButton_close);
            this.Controls.Add(this.textEdit_recv);
            this.Controls.Add(this.gridControl1);
            this.Name = "FormClient";
            this.Text = "Chat";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileView_userList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_recv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_send.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Tile.TileView tileView_userList;
        private DevExpress.XtraGrid.Columns.TileViewColumn userPortrait;
        private DevExpress.XtraGrid.Columns.TileViewColumn userName;
        private DevExpress.XtraEditors.TextEdit textEdit_recv;
        private DevExpress.XtraEditors.SimpleButton simpleButton_close;
        private DevExpress.XtraEditors.SimpleButton simpleButton_send;
        private DevExpress.XtraEditors.TextEdit textEdit_send;
        private DevExpress.XtraEditors.SimpleButton simpleButton_recv;
    }
}