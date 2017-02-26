using Meeting.BLL;
using Meeting.Entity;
using Meeting.Interface;
using Meeting.Pc.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Meeting.Pc.View
{
    public partial class FrmRecord : Form
    {
        private string _meetingId = "";
        IMeetingInterface imeeting = new MeetingService();
        IMeetingPeople ipeople = new MeetingPeopleService();
        private int _recordId = 0;

        public FrmRecord(string meetingId)
        {
            InitializeComponent();
            _meetingId = meetingId;
            Initial(meetingId);
        }

        private void pxHome_Click(object sender, EventArgs e)
        {
            //FrmMain main = new FrmMain();
            //main.Show();
            //Hide();
        }

        private void peRerurn_Click(object sender, EventArgs e)
        {
            FrmMeetingInfo info = new FrmMeetingInfo(_meetingId);
            info.Show();
            Helper.KillProcess();
            Hide();
        }



        private void FrmRecord_Load(object sender, EventArgs e)
        {
          

            ////先下载word
            //string path = System.Environment.CurrentDirectory;
            //string url = Helper.DownloadFile(_directory,path);

            //Helper.KillProcess();
            //var word = new CtrlWinWord()
            //{
            //    Dock = System.Windows.Forms.DockStyle.Fill,
            //    Location = new System.Drawing.Point(0, 0),
            //    Name = "文档",
            //    TabIndex = 1
            //};
            ////加载word的完整路径  修改此处
            //word.LoadDocument(url);
            ////word.LoadDocument(phath + @"\1.docx");
            //word.Show();
            //panelEx3.Controls.Add(word);
        }

        private void pxSave_Click(object sender, EventArgs e)
        {
            //会议记录保存上传


        }


        private string _directory = "";   //这次会议  上传材料的根目录
        private void Initial(string meetingId)
        {
            mMeeting model = imeeting.GetMeetingModel(meetingId);
            label4.Text = model.MeetingName;
            label5.Text = model.StartDate;
            label6.Text = model.EendDate;
            label11.Text = model.AddressName;
            label14.Text = model.MeetingHost;
            label22.Text = model.SecretaryName;
            label32.Text = model.MeetingDocument;
            label12.Text = model.PeopleName;
            label29.Text = model.LeavePeople;
            label30.Text = model.AttendPeople;

            textBox1.Text = ReplaceHtmlTag(ipeople.GetMeetingRecord(meetingId));

            var meetingOpinion = ipeople.GetMeetingOpinion(UserInfo.UserId,meetingId);
            textBox2.Text = meetingOpinion.OpinionMsg;
            label16.Text = UserInfo.UserName;
            _recordId = meetingOpinion.Id;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            ipeople.InserMeetingOpinion(_recordId,_meetingId,UserInfo.UserId,1,"");
            MessageBox.Show("审批操作成功!", "系统消息提示");
            FrmShow();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text.Trim()))
            {
                MessageBox.Show("您点不同意的时候,需要填写意见!", "系统消息提示");
            }
            else 
            {
                ipeople.InserMeetingOpinion(_recordId, _meetingId, UserInfo.UserId, 2,textBox2.Text.Trim());
                MessageBox.Show("审批操作成功!", "系统消息提示");
                FrmShow();
            }
        }

        private void FrmShow() 
        {
            FrmMeetingInfo meeting = new FrmMeetingInfo(_meetingId);
            Helper.NickName = UserInfo.UserName;
            meeting.Show();
            Hide();
        }


        public  string ReplaceHtmlTag(string html, int length = 0)
        {
            string strText = System.Text.RegularExpressions.Regex.Replace(html, "<[^>]+>", "");
            strText = System.Text.RegularExpressions.Regex.Replace(strText, "&[^;]+;", "");

            if (length > 0 && strText.Length > length)
                return strText.Substring(0, length);

            return strText;
        }
    }
}
