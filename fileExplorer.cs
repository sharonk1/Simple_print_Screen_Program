using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace PrtScn
{
    public partial class fileExplorer : Form
    {
        public fileExplorer()
        {
            InitializeComponent();
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult result = ofd.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                fileTxt.Text = ofd.FileName;
             
                ProcessStartInfo info = new ProcessStartInfo();
                info.FileName = ofd.FileName; 
                   // info.UseShellExecute = true;
                    var process = Process.Start(info);
                    Thread.Sleep(2000);
                        SetParent(process.MainWindowHandle, workPanel.Handle);
                    //    SetParent(process.MainWindowHandle, workPanel.Handle);
                
            } 
            
      
        }

        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        private void fileExplorer_Load(object sender, EventArgs e)
        {
          int w  =Convert.ToInt32(this.Bounds.Width.ToString());
          int h = Convert.ToInt32(this.Bounds.Height.ToString());
          workPanel.Size = new Size(w-50,h-150);
        }
    }
}
