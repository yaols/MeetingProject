using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Meeting.Pc.View
{
    public partial class FrmImage : Form
    {
        private string _meetingId = "";
        private string _url = "";
        private string _filename = "";
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public FrmImage(string url, string meetingid,string filename)
        {
            InitializeComponent();
            _meetingId = meetingid;
            _url = url;
            _filename = filename;

           
            timer.Enabled = true;
            timer.Interval = 300;
            timer.Tick += new EventHandler(timer1_Tick);
        }

        private void ExecWaitForm()
        {
            try
            {
                WaitFormService.Show();
            }
            catch (Exception ex)
            {
                WaitFormService.Close();
            }
        } 


        void timer1_Tick(object sender, EventArgs e)
        {
            Thread th = new Thread(new ThreadStart(this.ExecWaitForm));
            th.Start();  
            Image image = Image.FromStream(WebRequest.Create(_url).GetResponse().GetResponseStream());
            pictureBox1.BackgroundImage = image;
            pictureBox1.Width = image.Width;
            pictureBox1.Height = image.Height;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            label1.Text = "材料:" + _filename;
            timer.Enabled = false;
            WaitFormService.Close();
        }


        private void peRerurn_Click(object sender, EventArgs e)
        {
            FrmResources resources = new FrmResources(_meetingId);
            resources.Show();
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
