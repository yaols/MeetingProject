using Meeting.Pc.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Meeting.Pc
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void pbxClose_MouseEnter(object sender, EventArgs e)
        {
            //关闭进入可见部分
            pbxClose.Image = Resources.close_select;
        }

        private void pbxClose_MouseLeave(object sender, EventArgs e)
        {
            //关闭离开可见部分
            pbxClose.Image = Resources.close;
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

        #region  窗体随鼠标移动
        private int _currentX;
        private int _currentY;
        private bool _canMove = false;
        private void FrmLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (_canMove)
            {
                Location = new Point(MousePosition.X - _currentX, MousePosition.Y - _currentY);
            }
        }

        private void FrmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            _currentX = e.X;
            _currentY = e.Y;
            _canMove = true;
        }

        private void FrmLogin_MouseUp(object sender, MouseEventArgs e)
        {
            _canMove = false;
        }
        #endregion

        private void pbxClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
    }
}
