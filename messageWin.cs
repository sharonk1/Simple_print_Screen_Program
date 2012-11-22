using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PrtScn
{
    public partial class messageWin : Form
    {
        public messageWin()
        {
            InitializeComponent();
        }

        private void messageWin_Load(object sender, EventArgs e)
        {
            this.SetDesktopLocation(0, 0);
            this.Opacity = 0.9;

            DateTime dt1 = DateTime.Now;
            int diff = 0;

            while (diff < 3)
            {

                DateTime dt2 = DateTime.Now;
                TimeSpan ts = dt2.Subtract(dt1);
                diff = (int)ts.TotalSeconds;
                Application.DoEvents();
                int t = 3 - diff;
                label3.Text = t.ToString();


            }
           // this.TransparencyKey = Color.Red;
          //  this.Left = Screen.PrimaryScreen.Bounds.Width / 2;
           // this.Height = Screen.PrimaryScreen.Bounds.Height / 2;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
