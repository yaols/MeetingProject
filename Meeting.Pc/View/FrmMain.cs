using log4net;
using Meeting.BLL;
using Meeting.Common;
using Meeting.Entity;
using Meeting.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Windows.Forms;
using Meeting.Pc.Control;
using Meeting.Pc.Properties;

namespace Meeting.Pc.View
{
    public partial class FrmMain : Form
    {
        IMeetingInterface imeeting = new MeetingService();
        ILog log = LogHelper.GetLog("FrmMain");
        private int _pageSize = Tool.ToInt(ConfigurationManager.AppSettings["pagesize"].ToString());
        PageControl pager = new PageControl();

        private string _nickname = "";

        public FrmMain(string nickname)
        {
            InitializeComponent();

            pelStartmeeting_Click(null,null);
            plPager.Controls.Add(pager);
            pager.Dock = DockStyle.Fill;
            pager.PageEvent += new PageControl.PageEventHandler(pagingControl1_PageEvent);

            label5.Text = "你好,"+nickname;
            _nickname = nickname;

            if (UserInfo.RoleId != 2) 
            {
                pelCreatemeeting.Visible = false;
            }
        }

        private void pagingControl1_PageEvent(int pageIndex, int meetingtype) 
        {
            pager.PageSize = _pageSize;
            GetMeetingList(pageIndex,meetingtype);
        }

        private void pelStartmeeting_MouseEnter(object sender, EventArgs e)
        {
            //已安排的会议进入可见部分
            pelStartmeeting.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(102)))));
            label3.ForeColor = Color.Black;
        }

        private void pelStartmeeting_MouseLeave()
        {
            //已安排会议离开可见部分
            pelStartmeeting.BackColor = Color.White;
            label3.ForeColor = Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
        }

        private void pelEndmeeting_MouseEnter(object sender, EventArgs e)
        {
            //已结束的会议进入可见部分
            pelEndmeeting.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(102)))));
            label2.ForeColor = Color.Black;
        }

        private void pelEndmeeting_MouseLeave()
        {
            //已结束会议离开可见部分
            pelEndmeeting.BackColor = Color.White;
            label2.ForeColor = Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
        }

        private void pelCreatemeeting_MouseEnter(object sender, EventArgs e)
        {
            //创建会议系统可见部分
            pelCreatemeeting.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(102)))));
            label4.ForeColor = Color.Black;
        }

        private void pelCreatemeeting_MouseLeave()
        {
            //创建会议系统离开部分
            pelCreatemeeting.BackColor = Color.White;
            label4.ForeColor = Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
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

        private void GetMeetingList(int pageIndex, int meetingType)
        {
            ClearControl();
            //数据查询
            var dataSet = imeeting.GetMeetingList(meetingType, UserInfo.UserId,pageIndex, _pageSize);
            if (dataSet != null)
            { 
                pager.PageIndex = pageIndex;
                pager.PageCount = (GetDataSetCount(dataSet.Tables[1])+_pageSize)/_pageSize;
                pager.PageSize = _pageSize;
                pager.SetControlsPage();
                GetDataSetList(dataSet.Tables[0]);
            }
        }

        private int GetDataSetCount(DataTable dataTable)
        {
            //获取总条数
            if (dataTable != null && dataTable.Rows.Count > 0)
                return Tool.ToInt(dataTable.Rows[0][0].ToString());
            return 0;
        }

        private void GetDataSetList(DataTable dataTable)
        {
            //获取数据集
            mMeeting model = null;
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                int index = 0;
                foreach (DataRow item in dataTable.Rows)
                {
                    model = new mMeeting();
                    model.RowId = Tool.ToInt(item["RowId"].ToString());
                    model.MeetingId = Tool.ToInt(item["MeetingId"].ToString());
                    model.MeetingName = item["MeetingName"].ToString();
                    model.StartDate = Convert.ToDateTime(item["StartDate"]).ToString("yyyy-MM-dd HH:mm");
                    model.EendDate = Convert.ToDateTime(item["EendDate"]).ToString("yyyy-MM-dd HH:mm");
                    BingDataControl(model,index);
                    index++;
                }
            }
        }

        private void BingDataControl(mMeeting model,int index)
        {
            //画控件
            PanelEx pxMain = new PanelEx();
            pxMain.Width = 1238;
            pxMain.Height = 55;
            pxMain.BorderColor = Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            pxMain.BackColor = Color.White;
            pxMain.Location = new Point(0, index * 58);
            plMain.Controls.Add(pxMain);

            Label label = new Label();
            label.Font = new System.Drawing.Font("宋体", 12F);
            label.ForeColor = System.Drawing.Color.Black;
            label.Location = new System.Drawing.Point(14, 18);
            label.AutoSize = true;
            label.Text = (index+1)+". "+model.MeetingName+"       计划开始时间: "+model.StartDate+"      计划结束时间: "+model.EendDate;
            pxMain.Controls.Add(label);

            PanelEx pxBtn = new PanelEx();
            pxBtn.BackgroundImage = Resources.join;
            pxBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            pxBtn.Click += new System.EventHandler(this.pbBtn_Click);
            pxBtn.Location = new System.Drawing.Point(1130, 12);
            pxBtn.Size = new System.Drawing.Size(78, 30);
            pxBtn.Tag = model.MeetingId;
            pxBtn.AutoSize = false;
            pxMain.Controls.Add(pxBtn);

        }

        IMeetingPeople people = new MeetingPeopleService();

        private void pbBtn_Click(object sender, EventArgs e)
        {
            PanelEx pxBtn = (PanelEx)sender;
            if (people.GetMeetingPeopleUserId(UserInfo.UserId,pxBtn.Tag.ToString()) > 0) 
            {
                FrmMeetingInfo meeting = new FrmMeetingInfo(pxBtn.Tag.ToString());
                Helper.NickName = _nickname;
                meeting.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("对不起你不是本次会议委员，无法进行审批!", "系统消息提示");
            }
        }

        private void pelStartmeeting_Click(object sender, EventArgs e)
        {
            //会议开始单机事件
            Startmeeting();
            GetMeetingList(1,0);
        }


        private void Startmeeting() 
        {
            //会议开始样式
            pelStartmeeting_MouseEnter(null,null);
            pelEndmeeting_MouseLeave();
            pelCreatemeeting_MouseLeave();
        }

        private void Endmeeting() 
        {
            //会议结束
            pelStartmeeting_MouseLeave();
            pelEndmeeting_MouseEnter(null,null);
            pelCreatemeeting_MouseLeave();
        }

        private void Createmeeting() 
        {
            //会议创建
            pelStartmeeting_MouseLeave();
            pelEndmeeting_MouseLeave();
            pelCreatemeeting_MouseEnter(null,null);

        }

        private void pelEndmeeting_Click(object sender, EventArgs e)
        {
            //会议结束单机事件
            Endmeeting();
            GetMeetingList(1, 1);
        }

        private void pelCreatemeeting_Click(object sender, EventArgs e)
        {
            //会议创建单机事件
            FrmCreateMeeting meeting = new FrmCreateMeeting(_nickname);
            meeting.Show();
            Hide();
        }

        private void ClearControl() 
        {
            plMain.Controls.Clear();
        }


        private void peSignout_Click(object sender, EventArgs e)
        {
            //关闭单击事件
            if (MessageBox.Show("确实要退出登录吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                //Application.Exit();
                FrmLogin login = new FrmLogin();
                login.Show();
                Hide();
            }
        }

        private void pbxMin_Click(object sender, EventArgs e)
        {
            //最小化事件
            notifyIcon1.Visible = true;
            Hide();
            Text = "";
        }

        private void notifyIcon1_MouseDown(object sender, MouseEventArgs e)
        {
            //图标上按下鼠标事件
            Show();
            notifyIcon1.Visible = false;
            Text = "检委会会议系统";
        }

        private void pbxMin_MouseEnter(object sender, EventArgs e)
        {
            //最小化进入可见部分
            pbxMin.Image = Resources.minimality_press;
        }

        private void pbxMin_MouseLeave(object sender, EventArgs e)
        {
            //最小化离开可见部分
            pbxMin.Image = Resources.minimality;
        }
    }
}
