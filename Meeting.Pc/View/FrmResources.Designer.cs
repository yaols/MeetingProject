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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmResources));
            this.plHead = new System.Windows.Forms.Panel();
            this.peRerurn = new Meeting.Pc.Control.PanelEx();
            this.label1 = new System.Windows.Forms.Label();
            this.plMain = new System.Windows.Forms.Panel();
            this.panelEx2 = new Meeting.Pc.Control.PanelEx();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.panelEx1 = new Meeting.Pc.Control.PanelEx();
            this.label2 = new System.Windows.Forms.Label();
            this.plHead.SuspendLayout();
            this.plMain.SuspendLayout();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // plHead
            // 
            this.plHead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.plHead.BackgroundImage = global::Meeting.Pc.Properties.Resources.head;
            this.plHead.Controls.Add(this.peRerurn);
            this.plHead.Controls.Add(this.label1);
            this.plHead.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plHead.Location = new System.Drawing.Point(0, 0);
            this.plHead.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.plHead.Name = "plHead";
            this.plHead.Size = new System.Drawing.Size(1240, 90);
            this.plHead.TabIndex = 3;
            this.plHead.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseDown);
            this.plHead.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseMove);
            this.plHead.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseUp);
            // 
            // peRerurn
            // 
            this.peRerurn.BackColor = System.Drawing.Color.Transparent;
            this.peRerurn.BackgroundImage = global::Meeting.Pc.Properties.Resources.rbtn;
            this.peRerurn.BorderColor = System.Drawing.Color.Empty;
            this.peRerurn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.peRerurn.Location = new System.Drawing.Point(16, 54);
            this.peRerurn.Name = "peRerurn";
            this.peRerurn.Size = new System.Drawing.Size(106, 32);
            this.peRerurn.TabIndex = 6;
            this.peRerurn.Click += new System.EventHandler(this.peRerurn_Click);
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
            this.plMain.Controls.Add(this.panelEx2);
            this.plMain.Controls.Add(this.label20);
            this.plMain.Controls.Add(this.label19);
            this.plMain.Controls.Add(this.label17);
            this.plMain.Controls.Add(this.label16);
            this.plMain.Controls.Add(this.panelEx1);
            this.plMain.Location = new System.Drawing.Point(1, 90);
            this.plMain.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.plMain.Name = "plMain";
            this.plMain.Size = new System.Drawing.Size(1238, 578);
            this.plMain.TabIndex = 4;
            // 
            // panelEx2
            // 
            this.panelEx2.BorderColor = System.Drawing.Color.Empty;
            this.panelEx2.Location = new System.Drawing.Point(11, 72);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(1216, 496);
            this.panelEx2.TabIndex = 36;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(1083, 49);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(31, 12);
            this.label20.TabIndex = 35;
            this.label20.Text = "操作";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(829, 49);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(31, 12);
            this.label19.TabIndex = 34;
            this.label19.Text = "格式";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(241, 49);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(57, 12);
            this.label17.TabIndex = 32;
            this.label17.Text = "材料名称";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(36, 49);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(31, 12);
            this.label16.TabIndex = 31;
            this.label16.Text = "序号";
            // 
            // panelEx1
            // 
            this.panelEx1.BackgroundImage = global::Meeting.Pc.Properties.Resources.head;
            this.panelEx1.BorderColor = System.Drawing.Color.Empty;
            this.panelEx1.Controls.Add(this.label2);
            this.panelEx1.Location = new System.Drawing.Point(12, 10);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(1215, 30);
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
            this.ClientSize = new System.Drawing.Size(1240, 670);
            this.Controls.Add(this.plMain);
            this.Controls.Add(this.plHead);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmResources";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmResources";
            this.plHead.ResumeLayout(false);
            this.plHead.PerformLayout();
            this.plMain.ResumeLayout(false);
            this.plMain.PerformLayout();
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plHead;
        private Control.PanelEx peRerurn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel plMain;
        private Control.PanelEx panelEx1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private Control.PanelEx panelEx2;
    }
}