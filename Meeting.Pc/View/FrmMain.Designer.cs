namespace Meeting.Pc.View
{
    partial class FrmMain
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
            this.plMain = new System.Windows.Forms.Panel();
            this.plPager = new System.Windows.Forms.Panel();
            this.plHead = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.peSignout = new Meeting.Pc.Control.PanelEx();
            this.pelCreatemeeting = new Meeting.Pc.Control.PanelEx();
            this.label4 = new System.Windows.Forms.Label();
            this.pelEndmeeting = new Meeting.Pc.Control.PanelEx();
            this.label2 = new System.Windows.Forms.Label();
            this.pelStartmeeting = new Meeting.Pc.Control.PanelEx();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.plHead.SuspendLayout();
            this.pelCreatemeeting.SuspendLayout();
            this.pelEndmeeting.SuspendLayout();
            this.pelStartmeeting.SuspendLayout();
            this.SuspendLayout();
            // 
            // plMain
            // 
            this.plMain.BackColor = System.Drawing.Color.White;
            this.plMain.Location = new System.Drawing.Point(1, 90);
            this.plMain.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.plMain.Name = "plMain";
            this.plMain.Size = new System.Drawing.Size(898, 530);
            this.plMain.TabIndex = 1;
            // 
            // plPager
            // 
            this.plPager.BackColor = System.Drawing.Color.White;
            this.plPager.Location = new System.Drawing.Point(1, 619);
            this.plPager.Name = "plPager";
            this.plPager.Size = new System.Drawing.Size(898, 40);
            this.plPager.TabIndex = 2;
            // 
            // plHead
            // 
            this.plHead.BackgroundImage = global::Meeting.Pc.Properties.Resources.head;
            this.plHead.Controls.Add(this.label5);
            this.plHead.Controls.Add(this.peSignout);
            this.plHead.Controls.Add(this.pelCreatemeeting);
            this.plHead.Controls.Add(this.pelEndmeeting);
            this.plHead.Controls.Add(this.pelStartmeeting);
            this.plHead.Controls.Add(this.label1);
            this.plHead.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plHead.Location = new System.Drawing.Point(0, 0);
            this.plHead.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.plHead.Name = "plHead";
            this.plHead.Size = new System.Drawing.Size(900, 90);
            this.plHead.TabIndex = 0;
            this.plHead.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseDown);
            this.plHead.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseMove);
            this.plHead.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("宋体", 10F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(696, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 14);
            this.label5.TabIndex = 7;
            this.label5.Text = "你好";
            // 
            // peSignout
            // 
            this.peSignout.BackColor = System.Drawing.Color.Transparent;
            this.peSignout.BackgroundImage = global::Meeting.Pc.Properties.Resources.signout;
            this.peSignout.BorderColor = System.Drawing.Color.Empty;
            this.peSignout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.peSignout.Location = new System.Drawing.Point(789, 13);
            this.peSignout.Name = "peSignout";
            this.peSignout.Size = new System.Drawing.Size(81, 24);
            this.peSignout.TabIndex = 6;
            this.peSignout.Click += new System.EventHandler(this.peSignout_Click);
            // 
            // pelCreatemeeting
            // 
            this.pelCreatemeeting.BackColor = System.Drawing.Color.White;
            this.pelCreatemeeting.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(225)))), ((int)(((byte)(226)))));
            this.pelCreatemeeting.Controls.Add(this.label4);
            this.pelCreatemeeting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pelCreatemeeting.Location = new System.Drawing.Point(160, 61);
            this.pelCreatemeeting.Name = "pelCreatemeeting";
            this.pelCreatemeeting.Size = new System.Drawing.Size(81, 29);
            this.pelCreatemeeting.TabIndex = 4;
            this.pelCreatemeeting.Visible = false;
            this.pelCreatemeeting.Click += new System.EventHandler(this.pelCreatemeeting_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.label4.Location = new System.Drawing.Point(6, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "+创建会议";
            this.label4.Click += new System.EventHandler(this.pelCreatemeeting_Click);
            // 
            // pelEndmeeting
            // 
            this.pelEndmeeting.BackColor = System.Drawing.Color.White;
            this.pelEndmeeting.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(225)))), ((int)(((byte)(226)))));
            this.pelEndmeeting.Controls.Add(this.label2);
            this.pelEndmeeting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pelEndmeeting.Location = new System.Drawing.Point(80, 61);
            this.pelEndmeeting.Name = "pelEndmeeting";
            this.pelEndmeeting.Size = new System.Drawing.Size(81, 29);
            this.pelEndmeeting.TabIndex = 3;
            this.pelEndmeeting.Visible = false;
            this.pelEndmeeting.Click += new System.EventHandler(this.pelEndmeeting_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.label2.Location = new System.Drawing.Point(6, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "已结束会议";
            this.label2.Click += new System.EventHandler(this.pelEndmeeting_Click);
            // 
            // pelStartmeeting
            // 
            this.pelStartmeeting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(102)))));
            this.pelStartmeeting.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(225)))), ((int)(((byte)(226)))));
            this.pelStartmeeting.Controls.Add(this.label3);
            this.pelStartmeeting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pelStartmeeting.Location = new System.Drawing.Point(0, 61);
            this.pelStartmeeting.Name = "pelStartmeeting";
            this.pelStartmeeting.Size = new System.Drawing.Size(81, 29);
            this.pelStartmeeting.TabIndex = 2;
            this.pelStartmeeting.Click += new System.EventHandler(this.pelStartmeeting_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(6, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "已安排会议";
            this.label3.Click += new System.EventHandler(this.pelStartmeeting_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(180)))), ((int)(((byte)(241)))));
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "检委会会议系统";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ClientSize = new System.Drawing.Size(900, 660);
            this.Controls.Add(this.plPager);
            this.Controls.Add(this.plMain);
            this.Controls.Add(this.plHead);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMain";
            this.plHead.ResumeLayout(false);
            this.plHead.PerformLayout();
            this.pelCreatemeeting.ResumeLayout(false);
            this.pelCreatemeeting.PerformLayout();
            this.pelEndmeeting.ResumeLayout(false);
            this.pelEndmeeting.PerformLayout();
            this.pelStartmeeting.ResumeLayout(false);
            this.pelStartmeeting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plHead;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel plMain;
        private Control.PanelEx pelStartmeeting;
        private System.Windows.Forms.Label label3;
        private Control.PanelEx pelEndmeeting;
        private System.Windows.Forms.Label label2;
        private Control.PanelEx pelCreatemeeting;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel plPager;
        private Control.PanelEx peSignout;
        private System.Windows.Forms.Label label5;
    }
}