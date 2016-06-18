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

namespace Meeting.Pc.View
{
    public partial class FrmMain : Form
    {
        IMeetingInterface imeeting = new MeetingService();
        ILog log = LogHelper.GetLog("FrmMain");
        private int  _pageSize = Tool.ToInt(ConfigurationManager.AppSettings["pagesize"].ToString());
      

        public FrmMain()
        {
            InitializeComponent();
            BingDataControl();
            PageControl pager = new PageControl();
            plPager.Controls.Add(pager);
            pager.Dock = DockStyle.Fill;
        }

        private void pelStartmeeting_MouseEnter(object sender, EventArgs e)
        {
            //已安排的会议进入可见部分
            pelStartmeeting.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(102)))));
            label3.ForeColor = Color.Black;
        }

        private void pelStartmeeting_MouseLeave(object sender, EventArgs e)
        {
            //已结束会议离开可见部分
            pelStartmeeting.BackColor = Color.White;
            label3.ForeColor = Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
        }

        private void pelEndmeeting_MouseEnter(object sender, EventArgs e)
        {
            //已安排的会议进入可见部分
            pelEndmeeting.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(102)))));
            label2.ForeColor = Color.Black;
        }

        private void pelEndmeeting_MouseLeave(object sender, EventArgs e)
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

        private void pelCreatemeeting_MouseLeave(object sender, EventArgs e)
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

        private List<mMeeting> GetMeetingList(int pageIndex,int meetingType) 
        {
            var dataSet = imeeting.GetMeetingList(meetingType,pageIndex,_pageSize);
            List<mMeeting> modeList = null;

            if (dataSet != null) 
            {
 
            }

            return modeList;
        }

        private int GetDataSetCount(DataTable dataTable)
        {
            if (dataTable != null && dataTable.Rows.Count > 0)
                return Tool.ToInt(dataTable.Rows[0][0].ToString());
            return 0;
        }

        private List<mMeeting> GetDataSetList(DataTable dataTable)
        {
            List<mMeeting> modeList = new List<mMeeting>();
            mMeeting model = null;

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow item in dataTable.Rows)
                {
                    model = new mMeeting();
                    model.RowId = Tool.ToInt(item["RowId"].ToString());
                    model.MeetingId = Tool.ToInt(item["MeetingId"].ToString());
                    model.MeetingName = item["MeetingName"].ToString();
                    model.StartDate = Convert.ToDateTime(item["StartDate"]).ToString("yyyy-MM-dd HH:mm");
                    model.EendDate = Convert.ToDateTime(item["EendDate"]).ToString("yyyy-MM-dd HH:mm");
                    modeList.Add(model);
                }
            }
            return modeList;
        }

        private void BingDataControl() 
        {
            for (int i = 0; i < 9; i++)
            {
                PanelEx pxMain = new PanelEx();
                pxMain.Width = 898;
                pxMain.Height = 55;
                pxMain.BorderColor = Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
                pxMain.BackColor = Color.White;
                pxMain.Location = new Point(0, i * 58);
                plMain.Controls.Add(pxMain);

                Label label = new Label();
                label.Font = new System.Drawing.Font("宋体", 10F);
                label.ForeColor = System.Drawing.Color.Black;
                label.Location = new System.Drawing.Point(14, 18);
                label.AutoSize = true;
                label.Text = "1. 检委会2013年第五次总第十次会议(未开始)  计划开始时间:2016-05-05 09:00  计划结束时间:2016-05-05 11:00";
                pxMain.Controls.Add(label);

                PanelEx pxBtn = new PanelEx();
                pxBtn.BackColor = System.Drawing.Color.Gray;
                pxBtn.Location = new System.Drawing.Point(811, 14);
                pxBtn.Size = new System.Drawing.Size(75, 27);
                pxMain.Controls.Add(pxBtn);
            }
        }
    }
}
