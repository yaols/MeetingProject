using Meeting.BLL;
using Meeting.Entity;
using Meeting.Interface;
using Meeting.Pc.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Meeting.Pc.View
{
    public partial class FrmMeetingInfo : Form
    {

        IMeetingInterface imeeting = new MeetingService();

        private string _meetingId = "";
        public FrmMeetingInfo(string meetingId)
        {
            InitializeComponent();
            _meetingId = meetingId;
            Initial(meetingId);
        }

        private void pxHome_Click(object sender, EventArgs e)
        {
            FrmMain main = new FrmMain();
            main.Show();
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

        private void panelEx7_Click(object sender, EventArgs e)
        {
            //查看材料
            FrmResources resources = new FrmResources(_issueid,_meetingId);
            resources.Show();
            Hide();
        }

        private void panelEx3_Click(object sender, EventArgs e)
        {
            //会议记录
            FrmRecord record = new FrmRecord(_meetingId);
            record.Show();
            Hide();
        }

        //IntPtr m_pDll;
        //private delegate bool m_GainPrivileges();

        private void panelEx6_Click(object sender, EventArgs e)
        {
            //检委会决定
            //m_pDll = Win32API.LoadLibrary(".\\InkAnnotations.dll");
            //if (m_pDll != null)
            //{
            //    IntPtr pAddOfFunToCall = Win32API.GetProcAddress(m_pDll, "GainPrivileges");
            //    m_GainPrivileges GainPrivileges = (m_GainPrivileges)Marshal.GetDelegateForFunctionPointer(
            //                                                                                         pAddOfFunToCall,
            //                                                                                       typeof(m_GainPrivileges));


            //    bool flag = GainPrivileges();  //获取权限，打开Word前调用，只需执行一次
            //}

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

        private int _issueid = 0;
        private void Initial(string meetingId) 
        {
            mMeeting model = imeeting.GetMeetingModel(Convert.ToInt32(meetingId));
            label4.Text = model.MeetingName;
            label5.Text = model.StartDate;
            label6.Text = model.EendDate;
            label11.Text = model.MeetingAddress;
            label14.Text = model.MeetingHost;
            label22.Text = model.SecretaryName;
            label12.Text = model.PeopleName;
            label24.Text = model.IssueList.IssueName;
            label25.Text = model.IssueList.RepostUser;
            label26.Text = model.IssueList.DepartName;

            _issueid = model.IssueList.Id;
        }
    }
}
