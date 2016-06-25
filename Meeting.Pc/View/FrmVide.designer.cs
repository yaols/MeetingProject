namespace Meeting.Pc.View
{
    partial class FrmVide
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVide));
            this.plHead = new System.Windows.Forms.Panel();
            this.pxSave = new Meeting.Pc.Control.PanelEx();
            this.peRerurn = new Meeting.Pc.Control.PanelEx();
            this.label1 = new System.Windows.Forms.Label();
            this.plMain = new System.Windows.Forms.Panel();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.plHead.SuspendLayout();
            this.plMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // plHead
            // 
            this.plHead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.plHead.BackgroundImage = global::Meeting.Pc.Properties.Resources.head_background;
            this.plHead.Controls.Add(this.pxSave);
            this.plHead.Controls.Add(this.peRerurn);
            this.plHead.Controls.Add(this.label1);
            this.plHead.Font = new System.Drawing.Font("华文中宋", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plHead.Location = new System.Drawing.Point(0, 0);
            this.plHead.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.plHead.Name = "plHead";
            this.plHead.Size = new System.Drawing.Size(900, 90);
            this.plHead.TabIndex = 5;
            // 
            // pxSave
            // 
            this.pxSave.BackColor = System.Drawing.Color.Transparent;
            this.pxSave.BackgroundImage = global::Meeting.Pc.Properties.Resources.save;
            this.pxSave.BorderColor = System.Drawing.Color.Empty;
            this.pxSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pxSave.Location = new System.Drawing.Point(825, 54);
            this.pxSave.Name = "pxSave";
            this.pxSave.Size = new System.Drawing.Size(63, 21);
            this.pxSave.TabIndex = 7;
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
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(180)))), ((int)(((byte)(241)))));
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "材料:b201605";
            // 
            // plMain
            // 
            this.plMain.BackColor = System.Drawing.Color.White;
            this.plMain.Controls.Add(this.axWindowsMediaPlayer1);
            this.plMain.Location = new System.Drawing.Point(1, 90);
            this.plMain.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.plMain.Name = "plMain";
            this.plMain.Size = new System.Drawing.Size(898, 569);
            this.plMain.TabIndex = 6;
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(1, 1);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(896, 568);
            this.axWindowsMediaPlayer1.TabIndex = 0;
            // 
            // FrmVide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 660);
            this.Controls.Add(this.plMain);
            this.Controls.Add(this.plHead);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmVide";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmVide";
            this.plHead.ResumeLayout(false);
            this.plHead.PerformLayout();
            this.plMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plHead;
        private Control.PanelEx pxSave;
        private Control.PanelEx peRerurn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel plMain;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
    }
}