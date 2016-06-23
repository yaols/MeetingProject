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
    public partial class FrmResources : Form
    {
        private string _meetingId = "";
        public FrmResources(string meetingId)
        {
            InitializeComponent();
            _meetingId = meetingId;
        }

        private void pxHome_Click(object sender, EventArgs e)
        {
            FrmMain main = new FrmMain();
            main.Show();
            Hide();
        }

        private void peRerurn_Click(object sender, EventArgs e)
        {
            FrmMeetingInfo info = new FrmMeetingInfo("1");
            info.Show();
            Hide();
        }

        private void panelEx3_Click(object sender, EventArgs e)
        {
            FrmSign sign = new FrmSign(_meetingId);

            string phath = System.Environment.CurrentDirectory;
            // var word = new CtrlWinWord()
            //{
            sign.word.Dock = System.Windows.Forms.DockStyle.Fill;
            sign.word.Location = new System.Drawing.Point(0, 0);
            sign.word.Name = "文档";
            sign.word.TabIndex = 1;
            // };
            //加载word的完整路径  修改此处
            sign.word.LoadDocument(phath + @"\1.docx");
            sign.word.Show();

            Hide();
            sign.ShowDialog();
        }
    }
}
