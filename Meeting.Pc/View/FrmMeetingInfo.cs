using Meeting.Pc.Control;
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
    public partial class FrmMeetingInfo : Form
    {
        public FrmMeetingInfo()
        {
            InitializeComponent();
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

        }

        private void panelEx3_Click(object sender, EventArgs e)
        {
            //会议记录

        }

        private void panelEx6_Click(object sender, EventArgs e)
        {
            //检委会决定
            string phath = System.Environment.CurrentDirectory;
            FrmSign sign = new FrmSign();
            sign.phath = phath;
            Hide();
            sign.ShowDialog();
        }
    }
}
