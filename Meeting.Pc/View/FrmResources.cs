using Meeting.BLL;
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
        private int _issueid = 0;
        private string _meetingId = "";
        IMeetingIssue issue = new MeetingIssue();


        public FrmResources(int issueid, string meetingid)
        {
            InitializeComponent();
            _issueid = issueid;
            _meetingId = meetingid;
            Initial();
        }

        private void pxHome_Click(object sender, EventArgs e)
        {
            FrmMain main = new FrmMain();
            main.Show();
            Hide();
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

            //FrmSign sign = new FrmSign(_meetingId);
            //string phath = System.Environment.CurrentDirectory;
            //sign.word.Dock = System.Windows.Forms.DockStyle.Fill;
            //sign.word.Location = new System.Drawing.Point(0, 0);
            //sign.word.Name = "文档";
            //sign.word.TabIndex = 1;
            ////加载word的完整路径  修改此处
            //sign.word.LoadDocument(phath + @"\1.docx");
            //sign.word.Show();
            //Hide();
            //sign.ShowDialog();
        }


        private void Initial()
        {
            var model = issue.GetMeetingResources(_issueid);

            int textx = 10;  //文本图片坐标计算
            int videx = 10;  //多媒体图片坐标计算

            int num = 0;  //多媒体图标个数标示
            for (int i = 0; i < model.Count; i++)
            {


                PanelEx p = new PanelEx();
                p.Width = 122;
                p.Height = 127;


                PanelEx main = new PanelEx();
                main.Cursor = Cursors.Hand;
                main.Location = new Point(16, 7);
                main.Width = 91;
                main.Height = 90;
                main.Tag = model[i];
                main.Click += new System.EventHandler(panelEx3_Click);

                Label label = new Label();
                label.Location = new Point(23, 105);
                label.Width = 140;
                label.Height = 12;
                label.Text = model[i].ResourcesName;


                p.Controls.Add(label);
                p.Controls.Add(main);

                if (model[i].ResourcesType == 1)
                {
                    if (i > 0)
                        textx = textx + 160;
                    p.Location = new Point(textx, 9);
                    main.BackgroundImage = Resources.文本资料;
                    panelEx2.Controls.Add(p);
                }


                if (model[i].ResourcesType == 2)
                {
                    if (num > 0)
                        videx = videx + 160;
                    p.Location = new Point(videx, 9);
                    main.BackgroundImage = Resources.图片资料;
                    panelEx7.Controls.Add(p);
                    num++;
                }


                if (model[i].ResourcesType == 3)
                {
                    if (num > 0)
                        videx = videx + 160;

                    p.Location = new Point(videx, 9);
                    main.BackgroundImage = Resources.音频资料;
                    panelEx7.Controls.Add(p);
                    num++;
                }
            }
        }
    }
}
