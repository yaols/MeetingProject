namespace Meeting.Pc.View
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
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.pbxLogin = new System.Windows.Forms.PictureBox();
            this.pbxPass = new System.Windows.Forms.PictureBox();
            this.plHead = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pbxMin = new System.Windows.Forms.PictureBox();
            this.pbxClose = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panelEx1 = new Meeting.Pc.Control.PanelEx();
            this.label4 = new System.Windows.Forms.Label();
            this.wtbPassword = new Meeting.Pc.WatermarkTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPass)).BeginInit();
            this.plHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).BeginInit();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "检委会会议系统";
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 13F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(175)))));
            this.label2.Location = new System.Drawing.Point(117, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "用户名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 13F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(175)))));
            this.label3.Location = new System.Drawing.Point(117, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "密  码";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(222, 253);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(77, 12);
            this.lblMessage.TabIndex = 12;
            this.lblMessage.Text = "请输入用户名";
            this.lblMessage.Visible = false;
            // 
            // pbxLogin
            // 
            this.pbxLogin.BackColor = System.Drawing.Color.Transparent;
            this.pbxLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxLogin.Image = global::Meeting.Pc.Properties.Resources.Login;
            this.pbxLogin.Location = new System.Drawing.Point(202, 285);
            this.pbxLogin.Name = "pbxLogin";
            this.pbxLogin.Size = new System.Drawing.Size(219, 37);
            this.pbxLogin.TabIndex = 13;
            this.pbxLogin.TabStop = false;
            this.pbxLogin.Click += new System.EventHandler(this.pbxLogin_Click);
            this.pbxLogin.MouseEnter += new System.EventHandler(this.pbxLogin_MouseEnter);
            this.pbxLogin.MouseLeave += new System.EventHandler(this.pbxLogin_MouseLeave);
            // 
            // pbxPass
            // 
            this.pbxPass.Image = global::Meeting.Pc.Properties.Resources.error;
            this.pbxPass.Location = new System.Drawing.Point(202, 251);
            this.pbxPass.Name = "pbxPass";
            this.pbxPass.Size = new System.Drawing.Size(14, 14);
            this.pbxPass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbxPass.TabIndex = 11;
            this.pbxPass.TabStop = false;
            this.pbxPass.Visible = false;
            // 
            // plHead
            // 
            this.plHead.BackColor = System.Drawing.Color.Transparent;
            this.plHead.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("plHead.BackgroundImage")));
            this.plHead.Controls.Add(this.label1);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("楷体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(242)))), ((int)(((byte)(252)))));
            this.label1.Location = new System.Drawing.Point(181, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 29);
            this.label1.TabIndex = 13;
            this.label1.Text = "检委会会议系统";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // comboBox1
            // 
            this.comboBox1.DropDownHeight = 98;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("宋体", 14F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.IntegralHeight = false;
            this.comboBox1.Location = new System.Drawing.Point(203, 156);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(219, 27);
            this.comboBox1.TabIndex = 17;
            // 
            // panelEx1
            // 
            this.panelEx1.BorderColor = System.Drawing.Color.Empty;
            this.panelEx1.Controls.Add(this.label4);
            this.panelEx1.Location = new System.Drawing.Point(3, 86);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(578, 292);
            this.panelEx1.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(209, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 22);
            this.label4.TabIndex = 0;
            this.label4.Text = "正在加载中请稍候.......";
            // 
            // wtbPassword
            // 
            this.wtbPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(173)))), ((int)(((byte)(175)))));
            this.wtbPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wtbPassword.Font = new System.Drawing.Font("宋体", 12F);
            this.wtbPassword.Location = new System.Drawing.Point(203, 209);
            this.wtbPassword.Multiline = true;
            this.wtbPassword.Name = "wtbPassword";
            this.wtbPassword.PasswordChar = '*';
            this.wtbPassword.Size = new System.Drawing.Size(219, 30);
            this.wtbPassword.TabIndex = 15;
            this.wtbPassword.WatermarkColor = System.Drawing.Color.DarkGray;
            this.wtbPassword.WatermarkTitle = " 请输入密码";
            this.wtbPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmLogin_KeyDown);
            this.wtbPassword.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.wtbUsername_PreviewKeyDown);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(584, 381);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.wtbPassword);
            this.Controls.Add(this.pbxLogin);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.pbxPass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.plHead);
            this.Controls.Add(this.comboBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmLogin";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmLogin_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmLogin_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FrmLogin_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPass)).EndInit();
            this.plHead.ResumeLayout(false);
            this.plHead.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel plHead;
        private System.Windows.Forms.PictureBox pbxMin;
        private System.Windows.Forms.PictureBox pbxClose;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pbxPass;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.PictureBox pbxLogin;
        private WatermarkTextBox wtbPassword;
        private Control.PanelEx panelEx1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

