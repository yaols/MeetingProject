using Meeting.Pc.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Meeting.Pc.View
{
    public partial class FrmMaxWord : Form
    {
        private string _path = "";

        public delegate void GetLoadWord(string path);//声明委托
        public GetLoadWord LoadWordTextHandler;//委托对象

        public FrmMaxWord(string path)
        {
            InitializeComponent();

            _path = path;
            Initial();
        }

        CtrlWinWord word = new CtrlWinWord();
        private void Initial()
        {

            word.Dock = System.Windows.Forms.DockStyle.Fill;
            word.Location = new System.Drawing.Point(0, 0);
            word.Name = "文档";
            word.TabIndex = 1;
            //加载word的完整路径  修改此处
            word.LoadDocument(_path + @"\1.docx");
            word.Show();
            panelEx1.Controls.Add(word);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            word.Save(_path + @"\1.docx");
            if (LoadWordTextHandler != null) 
            {
                LoadWordTextHandler(_path);
                Hide();
            }

        }
    }
}
