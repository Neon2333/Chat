﻿
namespace Client.UIL
{
    partial class FrmClientList
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
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition1 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition2 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition3 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition1 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition2 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableSpan tableSpan1 = new DevExpress.XtraEditors.TableLayout.TableSpan();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement1 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement2 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            this.userPortrait = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.userName = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.gridControl_userSignInList = new DevExpress.XtraGrid.GridControl();
            this.tileView_userSignInList = new DevExpress.XtraGrid.Views.Tile.TileView();
            this.textEdit_recv = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton_close = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_send = new DevExpress.XtraEditors.SimpleButton();
            this.textEdit_send = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_userSignInList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileView_userSignInList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_recv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_send.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // userPortrait
            // 
            this.userPortrait.Caption = "userPortrait";
            this.userPortrait.FieldName = "usrName";
            this.userPortrait.MinWidth = 25;
            this.userPortrait.Name = "userPortrait";
            this.userPortrait.Visible = true;
            this.userPortrait.VisibleIndex = 0;
            this.userPortrait.Width = 94;
            // 
            // userName
            // 
            this.userName.Caption = "userName";
            this.userName.FieldName = "usrPortrait";
            this.userName.MinWidth = 25;
            this.userName.Name = "userName";
            this.userName.Visible = true;
            this.userName.VisibleIndex = 1;
            this.userName.Width = 94;
            // 
            // gridControl_userSignInList
            // 
            this.gridControl_userSignInList.Location = new System.Drawing.Point(8, 8);
            this.gridControl_userSignInList.MainView = this.tileView_userSignInList;
            this.gridControl_userSignInList.Name = "gridControl_userSignInList";
            this.gridControl_userSignInList.Size = new System.Drawing.Size(350, 660);
            this.gridControl_userSignInList.TabIndex = 0;
            this.gridControl_userSignInList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.tileView_userSignInList});
            // 
            // tileView_userSignInList
            // 
            this.tileView_userSignInList.Appearance.ItemNormal.BackColor = System.Drawing.Color.White;
            this.tileView_userSignInList.Appearance.ItemNormal.Options.UseBackColor = true;
            this.tileView_userSignInList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.userPortrait,
            this.userName});
            this.tileView_userSignInList.GridControl = this.gridControl_userSignInList;
            this.tileView_userSignInList.Name = "tileView_userSignInList";
            this.tileView_userSignInList.OptionsTiles.GroupTextPadding = new System.Windows.Forms.Padding(0, -1, -1, -1);
            this.tileView_userSignInList.OptionsTiles.ItemSize = new System.Drawing.Size(248, 60);
            this.tileView_userSignInList.OptionsTiles.LayoutMode = DevExpress.XtraGrid.Views.Tile.TileViewLayoutMode.List;
            this.tileView_userSignInList.OptionsTiles.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tileView_userSignInList.TileColumns.Add(tableColumnDefinition1);
            this.tileView_userSignInList.TileColumns.Add(tableColumnDefinition2);
            this.tileView_userSignInList.TileColumns.Add(tableColumnDefinition3);
            this.tileView_userSignInList.TileRows.Add(tableRowDefinition1);
            this.tileView_userSignInList.TileRows.Add(tableRowDefinition2);
            tableSpan1.RowSpan = 2;
            this.tileView_userSignInList.TileSpans.Add(tableSpan1);
            tileViewItemElement1.Column = this.userPortrait;
            tileViewItemElement1.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement1.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement1.Text = "userPortrait";
            tileViewItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement2.Column = this.userName;
            tileViewItemElement2.ColumnIndex = 1;
            tileViewItemElement2.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileViewItemElement2.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            tileViewItemElement2.Text = "userName";
            tileViewItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            this.tileView_userSignInList.TileTemplate.Add(tileViewItemElement1);
            this.tileView_userSignInList.TileTemplate.Add(tileViewItemElement2);
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
            // FrmClientList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 680);
            this.Controls.Add(this.textEdit_send);
            this.Controls.Add(this.simpleButton_send);
            this.Controls.Add(this.simpleButton_close);
            this.Controls.Add(this.textEdit_recv);
            this.Controls.Add(this.gridControl_userSignInList);
            this.Name = "FrmClientList";
            this.Text = "Chat";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_userSignInList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileView_userSignInList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_recv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit_send.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_userSignInList;
        private DevExpress.XtraGrid.Views.Tile.TileView tileView_userSignInList;
        private DevExpress.XtraGrid.Columns.TileViewColumn userPortrait;
        private DevExpress.XtraGrid.Columns.TileViewColumn userName;
        private DevExpress.XtraEditors.TextEdit textEdit_recv;
        private DevExpress.XtraEditors.SimpleButton simpleButton_close;
        private DevExpress.XtraEditors.SimpleButton simpleButton_send;
        private DevExpress.XtraEditors.TextEdit textEdit_send;
    }
}