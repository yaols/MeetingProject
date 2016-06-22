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
        public FrmResources(string meetingId)
        {
            InitializeComponent();
            _meetingId = meetingId;
        }

        private void pxHome_Click(object sender, EventArgs e)
        {
            FrmMain main = new FrmMain();
            main.Show();
            Hide();
        }

        private void peRerurn_Click(object sender, EventArgs e)
        {
            FrmMeetingInfo info = new FrmMeetingInfo("1");
            info.Show();
            Hide();
        }
    }
}
