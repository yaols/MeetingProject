using Meeting.Pc.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Meeting.Pc.View
{
    public partial class FrmSign : Form
    {
        private string _meetingId = "";
        public FrmSign(string meetingId)
        {
            InitializeComponent();
            _meetingId = meetingId;
        }



        public  CtrlWinWord word = new CtrlWinWord();
        private void FrmSign_Load(object sender, EventArgs e)
        {

           // string phath = System.Environment.CurrentDirectory;
           //// var word = new CtrlWinWord()
           // //{
           //     word.Dock = System.Windows.Forms.DockStyle.Fill;
           //     word.Location = new System.Drawing.Point(0, 0);
           //     word.Name = "文档";
           //     word.TabIndex = 1;
           //// };
           // //加载word的完整路径  修改此处
           // word.LoadDocument(phath + @"\1.docx");
           // word.Show();
            plMain.Controls.Add(word);
        }

        private void pxHome_Click(object sender, EventArgs e)
        {
            FrmMain main = new FrmMain();
            main.Show();
            Hide();
            Helper.KillProcess();
        }

        private void peRerurn_Click(object sender, EventArgs e)
        {
            FrmMeetingInfo info = new FrmMeetingInfo(_meetingId);
            info.Show();
            Hide();
            Helper.KillProcess();
        }


        //表决

        IntPtr m_pDll;
        private delegate bool m_StartInkAnnotations(int hWnd);
        private void panelEx1_Click(object sender, EventArgs e)
        {
            m_pDll = Win32API.LoadLibrary(".\\InkAnnotations.dll");

            if (m_pDll != null)
            {
                IntPtr pAddOfFunToCall = Win32API.GetProcAddress(m_pDll, "StartInkAnnotations");
                m_StartInkAnnotations StartInkAnnotations = (m_StartInkAnnotations)Marshal.GetDelegateForFunctionPointer(
                                                                                                     pAddOfFunToCall,
                                                                                                  typeof(m_StartInkAnnotations));

                bool flag = StartInkAnnotations(0); //开始墨迹注释，若非触摸屏，则调用批注
            }


        }

        private void pxSave_Click(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "1.docx";
            word.Save(path);
        }
    }
}
