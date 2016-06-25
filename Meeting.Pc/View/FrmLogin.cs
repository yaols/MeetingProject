using log4net;
using Meeting.BLL;
using Meeting.Common;
using Meeting.Entity;
using Meeting.Interface;
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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        ILoginInterface ilogin = new LoginService();
        ILog log = LogHelper.GetLog("LoginController");

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

        private void pbxLogin_Click(object sender, EventArgs e)
        {
            //登陆
            if (!IsNullJudge())
            {
                return;
            }

            string userName = wtbUsername.Text.Trim();
            string userPass = wtbPassword.Text.Trim();

            mUser umodel  = ilogin.LoginUserInfo(userName, userPass);
            if (umodel.PassWord == userPass && umodel.UserName == userName)
            {
                UserInfo.RoleId = umodel.UserRoleId;
                FrmMain frmmain = new FrmMain();
                frmmain.Show();
                Hide();
            }
            else 
            {
                lblMessage.Text = "用户名或者密码错误!";
            }
        }

        private void pbxLogin_MouseEnter(object sender, EventArgs e)
        {
            //登陆按钮进入可见部分

        }

        private void pbxLogin_MouseLeave(object sender, EventArgs e)
        {
            //登陆按钮离开可见部分

        }


        private bool IsNullJudge()
        {
            //非空验证
            if (string.IsNullOrEmpty(wtbUsername.Text.Trim()))
            {
                wtbUsername.Focus();
                lblMessage.Text = "请输入用户名";
                SetMessageShow(true);
                return false;
            }

            if (string.IsNullOrEmpty(wtbPassword.Text.Trim()))
            {
                wtbPassword.Focus();
                lblMessage.Text = "请输入密码";
                SetMessageShow(true);
                return false;
            }
            return true;
        }

        private void SetMessageShow(bool isShow)
        {
            this.pbxPass.Visible = isShow;
            this.lblMessage.Visible = isShow;
        }
    }
}
