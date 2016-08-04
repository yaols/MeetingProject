using Meeting.BLL;
using Meeting.Common;
using Meeting.Entity;
using Meeting.Interface;
using Meeting.Pc.Control;
using Meeting.Pc.Properties;
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
        IMeetingIssue issue = new MeetingIssue();


        public FrmResources(string meetingid)
        {
            InitializeComponent();
            _meetingId = meetingid;
            Initial();
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
            Hide();
        }

        private void panelEx3_Click(object sender, EventArgs e)
        {
            PanelEx pxBtn = (PanelEx)sender;
            mMeetingResources model = (mMeetingResources)pxBtn.Tag;
        }


        private void Initial()
        {
            var model = issue.GetMeetingResources(Convert.ToInt32(_meetingId));

            int index = 0;
            foreach (var item in model)
            {
                PanelEx pxMain = new PanelEx();
                pxMain.Width = 1216;
                pxMain.Height = 55;
                pxMain.BorderColor = Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
                pxMain.BackColor = Color.White;
                pxMain.Location = new Point(0, index * 50);
                panelEx2.Controls.Add(pxMain);

                Label label = new Label();
                label.Font = new System.Drawing.Font("宋体", 10F);
                label.ForeColor = System.Drawing.Color.Black;
                label.Location = new System.Drawing.Point(26, 15);
                label.AutoSize = true;
                label.Text = (index+1).ToString();
                pxMain.Controls.Add(label);


                label = new Label();
                label.Font = new System.Drawing.Font("宋体", 10F);
                label.ForeColor = System.Drawing.Color.Black;
                label.Location = new System.Drawing.Point(220, 15);
                label.AutoSize = true;
                label.Text = item.ResourcesName;
                pxMain.Controls.Add(label);


                label = new Label();
                label.Font = new System.Drawing.Font("宋体", 10F);
                label.ForeColor = System.Drawing.Color.Black;
                label.Location = new System.Drawing.Point(820, 15);
                label.AutoSize = true;
                label.Text = item.ResourcesType;
                pxMain.Controls.Add(label);


                PanelEx pxBtn = new PanelEx();
                pxBtn.BackgroundImage = Resources.join;
                pxBtn.Cursor = System.Windows.Forms.Cursors.Hand;
                pxBtn.Click += new System.EventHandler(this.pbBtn_Click);
                pxBtn.Location = new System.Drawing.Point(1060, 15);
                pxBtn.Size = new System.Drawing.Size(78, 30);
                pxBtn.Tag = item;
                pxMain.Controls.Add(pxBtn);
                index++;
            }
        }

        private void pbBtn_Click(object sender, EventArgs e)
        {
            PanelEx pxBtn = (PanelEx)sender;
            mMeetingResources model = (mMeetingResources)pxBtn.Tag;
            ShowForm(model.ResourcesType,model.ResourcesName+model.ResourcesType);
        }


        private void ShowForm(string type,string filename) 
        {
            if (type == ".txt" || type == ".doc" || type == ".docx")
            {
                string url = Helper.DownloadFile(_meetingId, Consts.PcUrlPath,filename);
                if (!string.IsNullOrEmpty(url))
                {
                    FrmSign sign = new FrmSign(_meetingId, url,1);
                    sign.Show();
                    Hide();
                }
                else 
                {
                    MessageBox.Show("下载资源不存在!","系统消息提示");
                }
            }
            else if (type == ".png" || type == ".jpg" || type == ".gif" || type == ".jpeg"||type==".bmp")
            {
                string url = string.Format("{0}{1}/{2}", Consts.DwonUrlPath, _meetingId, filename);
                if (!string.IsNullOrEmpty(url))
                {
                    FrmImage image = new FrmImage(url, _meetingId, filename);
                    image.Show();
                    Hide();
                }
                else 
                {
                    MessageBox.Show("下载资源不存在!", "系统消息提示");
                }
            }
            else if (type == ".mp4" || type == ".wmv" || type == ".amv"||type==".mp3")
            {
                string url = string.Format("{0}{1}/{2}",Consts.DwonUrlPath,_meetingId,filename);
                if (!string.IsNullOrEmpty(url)) 
                {
                    FrmVide vide = new FrmVide(url, _meetingId, filename);
                    vide.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("下载资源不存在!", "系统消息提示");
                }
            }
            else if (type == ".mp3")
            {
                string url = string.Format("{0}{1}\\{2}",Consts.DwonUrlPath,_meetingId,filename+type);
                FrmVide vide = new FrmVide(url, _meetingId, filename);
                vide.Show();
                Hide();
            }
            else
            {
                string url = Helper.DownloadFile(_meetingId, Consts.PcUrlPath, filename);
                if (!string.IsNullOrEmpty(url))
                {
                    FrmSign sign = new FrmSign(_meetingId, url,1);
                    sign.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("下载资源不存在!", "系统消息提示");
                }
            }
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
