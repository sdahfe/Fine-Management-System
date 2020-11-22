using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Semester_MS
{
    public partial class loading : Form
    {
        public loading()
        {
            InitializeComponent();
            timer1.Start();
        }
        int sec = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            percent.Text = sec.ToString() + "%";
            sec = sec + 20;
            if (sec == 100)
            {
                timer1.Stop();
                this.Close();
            }
        }
    }
}
