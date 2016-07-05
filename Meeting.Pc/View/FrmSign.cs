using Meeting.Common;
using Meeting.Pc.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Meeting.Pc.View
{
    public partial class FrmSign : Form
    {
        private string _meetingId = "";
        private string _url = "";

        public FrmSign(string meetingId, string url)
        {
            InitializeComponent();
            _meetingId = meetingId;
            _url = url;
        }


        Timer timer = new Timer();
        public CtrlWinWord word = new CtrlWinWord();
        private void FrmSign_Load(object sender, EventArgs e)
        {
            timer.Enabled = true;
            timer.Interval = 300;
            timer.Tick += new EventHandler(timer1_Tick);
        }



        void timer1_Tick(object sender, EventArgs e)
        {
            FrmLoad load = new FrmLoad();
            load.Show();

            string phath = System.Environment.CurrentDirectory;
            // var word = new CtrlWinWord()
            //{
            word.Dock = System.Windows.Forms.DockStyle.Fill;
            word.Location = new System.Drawing.Point(0, 0);
            word.Name = "文档";
            word.TabIndex = 1;
            // };
            //加载word的完整路径  修改此处
            word.LoadDocument(_url);
            word.Show();
            plMain.Controls.Add(word);

            load.Hide();
            timer.Enabled = false;
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
            word.Save(_url);
            word.Dispose();
            //Helper.KillProcess();

            string meesage = Helper.UploadFileHttpRequest(_url, Consts.SaveUrlPath, _meetingId);
            FrmMeetingInfo info = new FrmMeetingInfo(_meetingId);
            info.Show();
            Hide();

        }

        #region  窗体随鼠标移动
        private int _currentX;
        private int _currentY;
        private bool _canMove = false;
        private void FrmMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (_canMove)
            {
                Location = new Point(MousePosition.X - _currentX, MousePosition.Y - _currentY);
            }
        }

        private void FrmMain_MouseDown(object sender, MouseEventArgs e)
        {
            _currentX = e.X;
            _currentY = e.Y;
            _canMove = true;
        }

        private void FrmMain_MouseUp(object sender, MouseEventArgs e)
        {
            _canMove = false;
        }
        #endregion
    }
}
