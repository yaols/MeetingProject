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
    public partial class FrmSign : Form
    {
        public FrmSign()
        {
            InitializeComponent();
        }

        public string phath = "";

        private void FrmSign_Load(object sender, EventArgs e)
        {
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
            plMain.Controls.Add(word);
        }
    }
}
