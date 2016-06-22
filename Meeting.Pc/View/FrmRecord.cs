using Meeting.Pc.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Meeting.Pc.View
{
    public partial class FrmRecord : Form
    {
        public FrmRecord()
        {
            InitializeComponent();
        }

        private void pxHome_Click(object sender, EventArgs e)
        {
            FrmMain main = new FrmMain();
            main.Show();
            Hide();
        }

        private void peRerurn_Click(object sender, EventArgs e)
        {
            FrmMeetingInfo info = new FrmMeetingInfo();
            info.Show();
            Hide();
        }

        private void FrmRecord_Load(object sender, EventArgs e)
        {
            string phath = System.Environment.CurrentDirectory;
            var word = new CtrlWinWord()
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                Location = new System.Drawing.Point(0, 0),
                Name = "文档",
                TabIndex = 1
            };
            //加载word的完整路径  修改此处
            word.LoadDocument(phath + @"\1.docx");
            word.Show();
            panelEx3.Controls.Add(word);
        }
    }
}
