namespace Meeting.Pc
{
    partial class FrmLogin
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.plHead = new System.Windows.Forms.Panel();
            this.pbxMin = new System.Windows.Forms.PictureBox();
            this.pbxClose = new System.Windows.Forms.PictureBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.plHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).BeginInit();
            this.SuspendLayout();
            // 
            // plHead
            // 
            this.plHead.BackColor = System.Drawing.Color.Transparent;
            this.plHead.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("plHead.BackgroundImage")));
            this.plHead.Controls.Add(this.pbxMin);
            this.plHead.Controls.Add(this.pbxClose);
            this.plHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.plHead.Location = new System.Drawing.Point(0, 0);
            this.plHead.Name = "plHead";
            this.plHead.Size = new System.Drawing.Size(584, 88);
            this.plHead.TabIndex = 6;
            this.plHead.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmLogin_MouseDown);
            this.plHead.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmLogin_MouseMove);
            this.plHead.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FrmLogin_MouseUp);
            // 
            // pbxMin
            // 
            this.pbxMin.BackColor = System.Drawing.Color.Transparent;
            this.pbxMin.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbxMin.Image = global::Meeting.Pc.Properties.Resources.minimality;
            this.pbxMin.Location = new System.Drawing.Point(521, 0);
            this.pbxMin.Name = "pbxMin";
            this.pbxMin.Size = new System.Drawing.Size(31, 23);
            this.pbxMin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbxMin.TabIndex = 12;
            this.pbxMin.TabStop = false;
            this.pbxMin.Click += new System.EventHandler(this.pbxMin_Click);
            this.pbxMin.MouseEnter += new System.EventHandler(this.pbxMin_MouseEnter);
            this.pbxMin.MouseLeave += new System.EventHandler(this.pbxMin_MouseLeave);
            // 
            // pbxClose
            // 
            this.pbxClose.BackColor = System.Drawing.Color.Transparent;
            this.pbxClose.BackgroundImage = global::Meeting.Pc.Properties.Resources.close;
            this.pbxClose.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbxClose.Image = global::Meeting.Pc.Properties.Resources.close;
            this.pbxClose.Location = new System.Drawing.Point(553, 0);
            this.pbxClose.Name = "pbxClose";
            this.pbxClose.Size = new System.Drawing.Size(31, 23);
            this.pbxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbxClose.TabIndex = 11;
            this.pbxClose.TabStop = false;
            this.pbxClose.Click += new System.EventHandler(this.pbxClose_Click);
            this.pbxClose.MouseEnter += new System.EventHandler(this.pbxClose_MouseEnter);
            this.pbxClose.MouseLeave += new System.EventHandler(this.pbxClose_MouseLeave);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "E药通";
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(584, 381);
            this.Controls.Add(this.plHead);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmLogin";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmLogin_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmLogin_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FrmLogin_MouseUp);
            this.plHead.ResumeLayout(false);
            this.plHead.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plHead;
        private System.Windows.Forms.PictureBox pbxMin;
        private System.Windows.Forms.PictureBox pbxClose;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

