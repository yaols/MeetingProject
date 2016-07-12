using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Meeting.Common;
using System.Configuration;

namespace Meeting.Pc.Control
{
    public partial class PageControl : UserControl
    {
        public PageControl()
        {
            InitializeComponent();
        }

        #region  字段
        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount = 0;

        /// <summary>
        /// 当前页数
        /// </summary>
        public int PageIndex = 1;

        public int PageSize =0;

        /// <summary>
        /// 查询参数
        /// </summary>
        public int meetingtype =0;

        public delegate void PageEventHandler(int pageIndex, int meetingtype);
        /// <summary>
        /// 分页委托 返回当前页数
        /// </summary>
        public event PageEventHandler PageEvent;
        #endregion

        private void btnHome_Click(object sender, EventArgs e)
        {
            //首页
            PageIndex = 1;
            if (PageEvent != null)
            {
                PageEvent(PageIndex, meetingtype);
                SetControlsPage();
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            //上一页
            if (PageIndex - 1 > 0)
            {
                if (PageEvent != null)
                {
                    PageIndex = PageIndex - 1;
                    PageEvent(PageIndex, meetingtype);
                    SetControlsPage();
                }
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            //下一页
            if (PageIndex + 1 <= (PageCount + PageSize - 1) / PageSize)
            {
                if (PageEvent != null)
                {
                    PageIndex = PageIndex + 1;
                    PageEvent(PageIndex, meetingtype);
                    SetControlsPage();
                }
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            //末页
            if (PageEvent != null)
            {
                PageIndex = PageCount;
                PageEvent(PageCount, meetingtype);
                SetControlsPage();
            }
        }

        public void SetControlsPage()
        {
            label1.Text = "(当前页数 " + PageIndex + "/"+(PageCount + PageSize -1) / PageSize+")";

            label1.Location = new Point(550, 13);
        }
    }
}
