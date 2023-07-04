using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScoalaDeInfo
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }

        private void guna2ProgressBar1_ValueChanged(object sender, EventArgs e)
        {

        }
        int startP = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startP += 1;
            Progress.Value = startP;
            if(Progress.Value == 100)
            {
                Progress.Value = 0;
                timer1.Stop();
                Login obj = new Login();
                obj.Show();
                this.Hide();
            }

        }

        private void Loading_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
