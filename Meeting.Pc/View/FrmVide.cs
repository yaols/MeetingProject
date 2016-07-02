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
    }
}
