namespace Meeting.Pc.View
{
    partial class FrmSign
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
            this.label1 = new System.Windows.Forms.Label();
            this.pxHome = new Meeting.Pc.Control.PanelEx();
            this.peRerurn = new Meeting.Pc.Control.PanelEx();
            this.panelEx1 = new Meeting.Pc.Control.PanelEx();
            this.plHead = new System.Windows.Forms.Panel();
            this.plMain = new System.Windows.Forms.Panel();
            this.plHead.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(180)))), ((int)(((byte)(241)))));
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "材料议题:10012";
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
            // peRerurn
            // 
            this.peRerurn.BackColor = System.Drawing.Color.Transparent;
            this.peRerurn.BackgroundImage = global::Meeting.Pc.Properties.Resources._return;
            this.peRerurn.BorderColor = System.Drawing.Color.Empty;
            this.peRerurn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.peRerurn.Location = new System.Drawing.Point(16, 54);
            this.peRerurn.Name = "peRerurn";
            this.peRerurn.Size = new System.Drawing.Size(63, 21);
            this.peRerurn.TabIndex = 6;
            this.peRerurn.Click += new System.EventHandler(this.peRerurn_Click);
            // 
            // panelEx1
            // 
            this.panelEx1.BackColor = System.Drawing.Color.Transparent;
            this.panelEx1.BackgroundImage = global::Meeting.Pc.Properties.Resources.表决;
            this.panelEx1.BorderColor = System.Drawing.Color.Empty;
            this.panelEx1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelEx1.Location = new System.Drawing.Point(96, 54);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(65, 25);
            this.panelEx1.TabIndex = 7;
            // 
            // plHead
            // 
            this.plHead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.plHead.BackgroundImage = global::Meeting.Pc.Properties.Resources.head_background;
            this.plHead.Controls.Add(this.panelEx1);
            this.plHead.Controls.Add(this.peRerurn);
            this.plHead.Controls.Add(this.pxHome);
            this.plHead.Controls.Add(this.label1);
            this.plHead.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plHead.Location = new System.Drawing.Point(0, 0);
            this.plHead.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.plHead.Name = "plHead";
            this.plHead.Size = new System.Drawing.Size(900, 90);
            this.plHead.TabIndex = 4;
            // 
            // plMain
            // 
            this.plMain.BackColor = System.Drawing.Color.White;
            this.plMain.Location = new System.Drawing.Point(1, 91);
            this.plMain.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.plMain.Name = "plMain";
            this.plMain.Size = new System.Drawing.Size(898, 569);
            this.plMain.TabIndex = 5;
            // 
            // FrmSign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 660);
            this.Controls.Add(this.plMain);
            this.Controls.Add(this.plHead);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSign";
            this.Load += new System.EventHandler(this.FrmSign_Load);
            this.plHead.ResumeLayout(false);
            this.plHead.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Control.PanelEx pxHome;
        private Control.PanelEx peRerurn;
        private Control.PanelEx panelEx1;
        private System.Windows.Forms.Panel plHead;
        private System.Windows.Forms.Panel plMain;

    }
}