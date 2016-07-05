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
    public partial class FrmVide : Form
    {
        private string _meetingId = "";
        public FrmVide(string path,string meetingId,string filename)
        {
            InitializeComponent();

            _meetingId = meetingId;
            Initial(path);
            Text = filename;
        }

        private void Initial(string path) 
        {
            axWindowsMediaPlayer1.URL = path;
           this.axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void peRerurn_Click(object sender, EventArgs e)
        {
            FrmResources resoureces = new FrmResources(_meetingId);
            resoureces.Show();
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
