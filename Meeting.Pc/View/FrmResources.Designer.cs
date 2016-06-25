namespace Meeting.Pc.View
{
    partial class FrmResources
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
            this.plHead = new System.Windows.Forms.Panel();
            this.peRerurn = new Meeting.Pc.Control.PanelEx();
            this.pxHome = new Meeting.Pc.Control.PanelEx();
            this.label1 = new System.Windows.Forms.Label();
            this.plMain = new System.Windows.Forms.Panel();
            this.panelEx7 = new Meeting.Pc.Control.PanelEx();
            this.panelEx13 = new Meeting.Pc.Control.PanelEx();
            this.label8 = new System.Windows.Forms.Label();
            this.panelEx14 = new Meeting.Pc.Control.PanelEx();
            this.panelEx8 = new Meeting.Pc.Control.PanelEx();
            this.label5 = new System.Windows.Forms.Label();
            this.panelEx9 = new Meeting.Pc.Control.PanelEx();
            this.panelEx10 = new Meeting.Pc.Control.PanelEx();
            this.label6 = new System.Windows.Forms.Label();
            this.panelEx11 = new Meeting.Pc.Control.PanelEx();
            this.panelEx12 = new Meeting.Pc.Control.PanelEx();
            this.label7 = new System.Windows.Forms.Label();
            this.panelEx2 = new Meeting.Pc.Control.PanelEx();
            this.panelEx4 = new Meeting.Pc.Control.PanelEx();
            this.label4 = new System.Windows.Forms.Label();
            this.panelEx6 = new Meeting.Pc.Control.PanelEx();
            this.panelEx3 = new Meeting.Pc.Control.PanelEx();
            this.label3 = new System.Windows.Forms.Label();
            this.panelEx5 = new Meeting.Pc.Control.PanelEx();
            this.panelEx1 = new Meeting.Pc.Control.PanelEx();
            this.label2 = new System.Windows.Forms.Label();
            this.plHead.SuspendLayout();
            this.plMain.SuspendLayout();
            this.panelEx7.SuspendLayout();
            this.panelEx13.SuspendLayout();
            this.panelEx8.SuspendLayout();
            this.panelEx10.SuspendLayout();
            this.panelEx12.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.panelEx4.SuspendLayout();
            this.panelEx3.SuspendLayout();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // plHead
            // 
            this.plHead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.plHead.BackgroundImage = global::Meeting.Pc.Properties.Resources.head;
            this.plHead.Controls.Add(this.peRerurn);
            this.plHead.Controls.Add(this.pxHome);
            this.plHead.Controls.Add(this.label1);
            this.plHead.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plHead.Location = new System.Drawing.Point(0, 0);
            this.plHead.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.plHead.Name = "plHead";
            this.plHead.Size = new System.Drawing.Size(900, 90);
            this.plHead.TabIndex = 3;
            // 
            // peRerurn
            // 
            this.peRerurn.BackColor = System.Drawing.Color.Transparent;
            this.peRerurn.BackgroundImage = global::Meeting.Pc.Properties.Resources.rbtn;
            this.peRerurn.BorderColor = System.Drawing.Color.Empty;
            this.peRerurn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.peRerurn.Location = new System.Drawing.Point(16, 54);
            this.peRerurn.Name = "peRerurn";
            this.peRerurn.Size = new System.Drawing.Size(63, 21);
            this.peRerurn.TabIndex = 6;
            this.peRerurn.Click += new System.EventHandler(this.peRerurn_Click);
            // 
            // pxHome
            // 
            this.pxHome.BackColor = System.Drawing.Color.Transparent;
            this.pxHome.BackgroundImage = global::Meeting.Pc.Properties.Resources.returnHome;
            this.pxHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pxHome.BorderColor = System.Drawing.Color.Empty;
            this.pxHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pxHome.Location = new System.Drawing.Point(799, 12);
            this.pxHome.Name = "pxHome";
            this.pxHome.Size = new System.Drawing.Size(89, 27);
            this.pxHome.TabIndex = 5;
            this.pxHome.Click += new System.EventHandler(this.pxHome_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(180)))), ((int)(((byte)(241)))));
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "材料详情";
            // 
            // plMain
            // 
            this.plMain.BackColor = System.Drawing.Color.White;
            this.plMain.Controls.Add(this.panelEx7);
            this.plMain.Controls.Add(this.panelEx12);
            this.plMain.Controls.Add(this.panelEx2);
            this.plMain.Controls.Add(this.panelEx1);
            this.plMain.Location = new System.Drawing.Point(1, 90);
            this.plMain.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.plMain.Name = "plMain";
            this.plMain.Size = new System.Drawing.Size(898, 569);
            this.plMain.TabIndex = 4;
            // 
            // panelEx7
            // 
            this.panelEx7.BorderColor = System.Drawing.Color.Empty;
            this.panelEx7.Controls.Add(this.panelEx13);
            this.panelEx7.Controls.Add(this.panelEx8);
            this.panelEx7.Controls.Add(this.panelEx10);
            this.panelEx7.Location = new System.Drawing.Point(12, 279);
            this.panelEx7.Name = "panelEx7";
            this.panelEx7.Size = new System.Drawing.Size(875, 156);
            this.panelEx7.TabIndex = 4;
            // 
            // panelEx13
            // 
            this.panelEx13.BorderColor = System.Drawing.Color.Empty;
            this.panelEx13.Controls.Add(this.label8);
            this.panelEx13.Controls.Add(this.panelEx14);
            this.panelEx13.Location = new System.Drawing.Point(255, 9);
            this.panelEx13.Name = "panelEx13";
            this.panelEx13.Size = new System.Drawing.Size(95, 113);
            this.panelEx13.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "议题详情不016";
            // 
            // panelEx14
            // 
            this.panelEx14.BackgroundImage = global::Meeting.Pc.Properties.Resources.图片资料;
            this.panelEx14.BorderColor = System.Drawing.Color.Empty;
            this.panelEx14.Location = new System.Drawing.Point(22, 7);
            this.panelEx14.Name = "panelEx14";
            this.panelEx14.Size = new System.Drawing.Size(50, 50);
            this.panelEx14.TabIndex = 2;
            // 
            // panelEx8
            // 
            this.panelEx8.BorderColor = System.Drawing.Color.Empty;
            this.panelEx8.Controls.Add(this.label5);
            this.panelEx8.Controls.Add(this.panelEx9);
            this.panelEx8.Location = new System.Drawing.Point(136, 9);
            this.panelEx8.Name = "panelEx8";
            this.panelEx8.Size = new System.Drawing.Size(95, 113);
            this.panelEx8.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "议题详情不016";
            // 
            // panelEx9
            // 
            this.panelEx9.BackgroundImage = global::Meeting.Pc.Properties.Resources.音频资料;
            this.panelEx9.BorderColor = System.Drawing.Color.Empty;
            this.panelEx9.Location = new System.Drawing.Point(22, 7);
            this.panelEx9.Name = "panelEx9";
            this.panelEx9.Size = new System.Drawing.Size(50, 50);
            this.panelEx9.TabIndex = 2;
            // 
            // panelEx10
            // 
            this.panelEx10.BorderColor = System.Drawing.Color.Empty;
            this.panelEx10.Controls.Add(this.label6);
            this.panelEx10.Controls.Add(this.panelEx11);
            this.panelEx10.Location = new System.Drawing.Point(10, 9);
            this.panelEx10.Name = "panelEx10";
            this.panelEx10.Size = new System.Drawing.Size(95, 113);
            this.panelEx10.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "议题详情不016";
            // 
            // panelEx11
            // 
            this.panelEx11.BackgroundImage = global::Meeting.Pc.Properties.Resources.音频资料;
            this.panelEx11.BorderColor = System.Drawing.Color.Empty;
            this.panelEx11.Location = new System.Drawing.Point(22, 7);
            this.panelEx11.Name = "panelEx11";
            this.panelEx11.Size = new System.Drawing.Size(50, 50);
            this.panelEx11.TabIndex = 2;
            // 
            // panelEx12
            // 
            this.panelEx12.BackgroundImage = global::Meeting.Pc.Properties.Resources.head;
            this.panelEx12.BorderColor = System.Drawing.Color.Empty;
            this.panelEx12.Controls.Add(this.label7);
            this.panelEx12.Location = new System.Drawing.Point(12, 244);
            this.panelEx12.Name = "panelEx12";
            this.panelEx12.Size = new System.Drawing.Size(875, 30);
            this.panelEx12.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(180)))), ((int)(((byte)(241)))));
            this.label7.Location = new System.Drawing.Point(13, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 14);
            this.label7.TabIndex = 1;
            this.label7.Text = "多媒体材料";
            // 
            // panelEx2
            // 
            this.panelEx2.BorderColor = System.Drawing.Color.Empty;
            this.panelEx2.Controls.Add(this.panelEx4);
            this.panelEx2.Controls.Add(this.panelEx3);
            this.panelEx2.Location = new System.Drawing.Point(12, 45);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(875, 156);
            this.panelEx2.TabIndex = 2;
            // 
            // panelEx4
            // 
            this.panelEx4.BorderColor = System.Drawing.Color.Empty;
            this.panelEx4.Controls.Add(this.label4);
            this.panelEx4.Controls.Add(this.panelEx6);
            this.panelEx4.Location = new System.Drawing.Point(136, 9);
            this.panelEx4.Name = "panelEx4";
            this.panelEx4.Size = new System.Drawing.Size(95, 113);
            this.panelEx4.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "议题详情不016";
            // 
            // panelEx6
            // 
            this.panelEx6.BackgroundImage = global::Meeting.Pc.Properties.Resources.文本资料;
            this.panelEx6.BorderColor = System.Drawing.Color.Empty;
            this.panelEx6.Location = new System.Drawing.Point(22, 7);
            this.panelEx6.Name = "panelEx6";
            this.panelEx6.Size = new System.Drawing.Size(50, 50);
            this.panelEx6.TabIndex = 2;
            // 
            // panelEx3
            // 
            this.panelEx3.BorderColor = System.Drawing.Color.Empty;
            this.panelEx3.Controls.Add(this.label3);
            this.panelEx3.Controls.Add(this.panelEx5);
            this.panelEx3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelEx3.Location = new System.Drawing.Point(10, 9);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(95, 113);
            this.panelEx3.TabIndex = 0;
            this.panelEx3.Click += new System.EventHandler(this.panelEx3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "议题详情不016";
            this.label3.Click += new System.EventHandler(this.panelEx3_Click);
            // 
            // panelEx5
            // 
            this.panelEx5.BackgroundImage = global::Meeting.Pc.Properties.Resources.文本资料;
            this.panelEx5.BorderColor = System.Drawing.Color.Empty;
            this.panelEx5.Location = new System.Drawing.Point(22, 7);
            this.panelEx5.Name = "panelEx5";
            this.panelEx5.Size = new System.Drawing.Size(50, 50);
            this.panelEx5.TabIndex = 2;
            this.panelEx5.Click += new System.EventHandler(this.panelEx3_Click);
            // 
            // panelEx1
            // 
            this.panelEx1.BackgroundImage = global::Meeting.Pc.Properties.Resources.head;
            this.panelEx1.BorderColor = System.Drawing.Color.Empty;
            this.panelEx1.Controls.Add(this.label2);
            this.panelEx1.Location = new System.Drawing.Point(12, 10);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(875, 30);
            this.panelEx1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(180)))), ((int)(((byte)(241)))));
            this.label2.Location = new System.Drawing.Point(13, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "文本材料";
            // 
            // FrmResources
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 660);
            this.Controls.Add(this.plMain);
            this.Controls.Add(this.plHead);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmResources";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmResources";
            this.plHead.ResumeLayout(false);
            this.plHead.PerformLayout();
            this.plMain.ResumeLayout(false);
            this.panelEx7.ResumeLayout(false);
            this.panelEx13.ResumeLayout(false);
            this.panelEx13.PerformLayout();
            this.panelEx8.ResumeLayout(false);
            this.panelEx8.PerformLayout();
            this.panelEx10.ResumeLayout(false);
            this.panelEx10.PerformLayout();
            this.panelEx12.ResumeLayout(false);
            this.panelEx12.PerformLayout();
            this.panelEx2.ResumeLayout(false);
            this.panelEx4.ResumeLayout(false);
            this.panelEx4.PerformLayout();
            this.panelEx3.ResumeLayout(false);
            this.panelEx3.PerformLayout();
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plHead;
        private Control.PanelEx peRerurn;
        private Control.PanelEx pxHome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel plMain;
        private Control.PanelEx panelEx1;
        private System.Windows.Forms.Label label2;
        private Control.PanelEx panelEx2;
        private Control.PanelEx panelEx3;
        private System.Windows.Forms.Label label3;
        private Control.PanelEx panelEx5;
        private Control.PanelEx panelEx4;
        private System.Windows.Forms.Label label4;
        private Control.PanelEx panelEx6;
        private Control.PanelEx panelEx7;
        private Control.PanelEx panelEx8;
        private System.Windows.Forms.Label label5;
        private Control.PanelEx panelEx9;
        private Control.PanelEx panelEx10;
        private System.Windows.Forms.Label label6;
        private Control.PanelEx panelEx11;
        private Control.PanelEx panelEx12;
        private System.Windows.Forms.Label label7;
        private Control.PanelEx panelEx13;
        private System.Windows.Forms.Label label8;
        private Control.PanelEx panelEx14;
    }
}