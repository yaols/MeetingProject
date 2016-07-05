using Meeting.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Meeting.Interface;
using Meeting.BLL;
using Meeting.Pc.Control;
using System.IO;
using Meeting.Pc.Properties;
using System.Net;
using System.Configuration;


namespace Meeting.Pc.View
{
    public partial class FrmCreateMeeting : Form
    {
        IMeetingInterface imeeting = new MeetingService();

        private string _nickname = "";

        public FrmCreateMeeting(string nickname)
        {
            InitializeComponent();
            Initial();
            _nickname = nickname;
        }

        private void pxSave_Click(object sender, EventArgs e)
        {
            List<mMeetingPeople> modeList = new List<mMeetingPeople>();

            //会议保存
            mMeeting model = new mMeeting();
            model.MeetingName = "检委会" + text1.Text.Trim() + "年  第" + text2.Text.Trim() + "次  总第" + text3.Text.Trim() + "次会议";
            model.StartDate = dateStart.Value.ToString("yyyy-MM-dd HH:mm");
            model.EendDate = dateEnd.Value.ToString("yyyy-MM-dd HH:mm");
            model.MeetingAddress = watermarkTextBox1.Text.Trim();
            model.MeetingHost = comboBox2.SelectedValue.ToString();

            foreach (var item in panelEx12.Controls)
            {
                if (item is CheckBox)
                {
                    CheckBox chk = (CheckBox)item;
                    if (chk.Checked == true)
                    {
                        mMeetingPeople people = new mMeetingPeople();
                        people.UserId = Convert.ToInt32(chk.Tag);
                        people.RoleId = 4;
                        modeList.Add(people);
                    }
                }
            }

            model.IssueList = new mMeetingIssue();
            model.IssueList.IssueName = text4.Text.Trim();
            model.IssueList.DepartId = Convert.ToInt32(comboBox6.SelectedValue);
            model.IssueList.RepostUserId = Convert.ToInt32(comboBox5.SelectedValue);

            //先上传资料到服务器        然后将数据存入到数据库
            string date = DateTime.Now.ToString("yyyyMMddHHmmsss");
            foreach (var item in resources)
            {
                string url = ConfigurationManager.AppSettings["saveUrl"].ToString();
                item.ResourcesName =date  + "/" + item.ResourcesName;
                //WebClient webclient = new WebClient();
                //webclient.UploadFile(url, "POST", item.ResourcesUrl);
                Helper.UploadFileHttpRequest(item.ResourcesUrl, url, date);
            }




            if (imeeting.SaveMeeting(resources, modeList, model) > 0) 
            {
                MessageBox.Show("保存成功");
                FrmMain main = new FrmMain(_nickname);
                main.Show();
                Hide();
            }

            resources.Clear();
        }

        private void peRerurn_Click(object sender, EventArgs e)
        {
            //FrmMain frmMain = new FrmMain();
            //frmMain.Show();
            //Hide();
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

        private void Initial()
        {
            DataSet dataSet = imeeting.GetCreateMeeting();
            DataSetBingCom(dataSet);
        }


        private void DataSetBingCom(DataSet dataSet)
        {
            if (dataSet != null)
            {
                if (dataSet.Tables[0] != null && dataSet.Tables[0].Rows.Count > 0)
                {
                    comboBox2.DataSource = dataSet.Tables[0];
                    comboBox2.DisplayMember = "UserName";
                    comboBox2.ValueMember = "UserId";
                    comboBox2.SelectedIndex = 0;



                    comboBox5.DataSource = dataSet.Tables[0].Copy();
                    comboBox5.DisplayMember = "UserName";
                    comboBox5.ValueMember = "UserId";
                    comboBox5.SelectedIndex = 0;

                    int x = 0;
                    int y = 1;
                    foreach (DataRow item in dataSet.Tables[0].Rows)
                    {
                        if (panelEx12.Controls.Count % 11 == 0 && panelEx12.Controls.Count > 0)
                        {
                            x = 0;
                            y = y + 3;
                        }


                        CheckBox check = new CheckBox();
                        check.Location = new Point(x * 70 + 5, y * 10);
                        check.Width = 60;
                        check.Height = 16;
                        check.Text = item["UserName"].ToString();
                        check.Tag = item["UserId"].ToString();
                        panelEx12.Controls.Add(check);
                        x++;
                    }
                }

                //if (dataSet.Tables[1] != null && dataSet.Tables[1].Rows.Count > 0)
                //{
                //    comboBox1.DataSource = dataSet.Tables[1];
                //    comboBox1.DisplayMember = "MeetingAddress";
                //    comboBox1.ValueMember = "Id";
                //    comboBox1.SelectedIndex = 0;
                //}

                if (dataSet.Tables[2] != null && dataSet.Tables[2].Rows.Count > 0)
                {
                    comboBox6.DataSource = dataSet.Tables[2];
                    comboBox6.DisplayMember = "DepartName";
                    comboBox6.ValueMember = "Id";
                    comboBox6.SelectedIndex = 0;
                }
            }
        }

        List<mMeetingResources> resources = new List<mMeetingResources>();

        private void panelEx6_Click(object sender, EventArgs e)
        {
            //文本材料
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK) 
            {
                string filename = openFileDialog1.FileName;
                string safile = openFileDialog1.SafeFileName;
                AddImageContro(filename, safile);
            }
        }

        private int labelX = 755;
        private int panelX = 755;
        private int num = 0;

        private void AddImageContro(string fileUrl, string safile) 
        {
            mMeetingResources model = new mMeetingResources();

            if (num > 0) 
            {
                panelX = panelX - 135;
                labelX = labelX - 130;
            }

            PanelEx panel = new PanelEx();
            panel.Width = 91;
            panel.Height = 90;
            panel.Location = new Point(panelX, 47);

            Label label = new Label();
            label.Text = safile;
            label.Width = 120;
            label.Height = 12;
            label.Location = new Point(labelX, 146);
            if (safile.Contains(".doc") || safile.Contains(".docx")) 
            {
                panel.BackgroundImage = Resources.文本资料;
                //model.ResourcesType = 1;
            }

            if (safile.Contains(".txt"))
            {
                panel.BackgroundImage = Resources.文本资料;
                //model.ResourcesType = 1;
            }

            if (safile.Contains(".jpg") || safile.Contains(".png"))
            {
                panel.BackgroundImage = Resources.图片资料;
                //model.ResourcesType = 2;
            }

            if (safile.Contains(".mp3") || safile.Contains(".mp4"))
            {
                panel.BackgroundImage = Resources.音频资料;
                //model.ResourcesType = 3;
            }

            panelEx4.Controls.Add(panel);
            panelEx4.Controls.Add(label);
            num++;

            model.ResourcesName = safile;
            model.ResourcesUrl = fileUrl;

            resources.Add(model);
        }
    }
}
