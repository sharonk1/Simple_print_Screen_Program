using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System.Xml;
//using Microsoft.Expression.Encoder.ScreenCapture;
using System.Threading;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.InteropServices;
using Microsoft.CSharp;
using Microsoft.Expression.Encoder.ScreenCapture;
using System.Diagnostics;

using System.CodeDom.Compiler;


namespace PrtScn
{
     
    public partial class Form1 : Form
    {
        
        Boolean isPressed = false;
        Point pressedPoint = new Point(0, 0);
        XmlNodeList path;
        static ScreenCaptureJob job = new ScreenCaptureJob();
      //  System.Threading.Timer timer;
        public Form1()
        {
          
            InitializeComponent();



            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.AutoSaveBtn, "Auto Save");

            System.Windows.Forms.ToolTip ToolTip3 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.directorySaveBtn, "Save to Directory");

            System.Windows.Forms.ToolTip ToolTip2 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.exitBtn, "Exit");

            System.Windows.Forms.ToolTip ToolTip4 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.optionsBtn, "Options");

            System.Windows.Forms.ToolTip ToolTip5 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.recordingBtn, "Recording");

            System.Windows.Forms.ToolTip ToolTip6 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.stopBtn, "Stop Recording");

            System.Windows.Forms.ToolTip ToolTip7 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.fileExpBtn, "File Explorer");
           // isStartCapture = false;
        }

        private void autoSaveBtn_Click(object sender, EventArgs e)
        {

            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                string progPath = System.AppDomain.CurrentDomain.BaseDirectory;
                xmlDoc.Load(progPath+ @"\options.xml");
            }
            catch 
            {
                MessageBox.Show("Error saving the file, please try again");
                return;
            }

            path = xmlDoc.GetElementsByTagName("savePath0");  // get the path from xml file 


            DateTime Date = DateTime.Now; // this will be the file name
            int screensCounter = 0;
            string fileName;
            fileName = Date.ToString();
            fileName = fileName.Replace("/", ""); fileName = fileName.Replace(":", "");
          
            foreach (Screen screen in Screen.AllScreens)  // count number of screens connected
            {
                screensCounter += screen.Bounds.Width;
               
            }
            
            this.Visible = false; //  makes the application invisible 
            Thread.Sleep(300);    // to not capture itself

            // print screen....
            Bitmap printscreen = new Bitmap(screensCounter, Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage(printscreen as Image);
            graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);  
          
            try  // to save the file to the path
            {
                printscreen.Save(path[0].InnerText+ @"\" + fileName  + ".jpg", ImageFormat.Jpeg);
              
            }
            catch // if fails - save to default path c"\temp...
            {
                if (!Directory.Exists(@"C:\temp"))
                    Directory.CreateDirectory(@"C:\temp");

                printscreen.Save(@"c:\temp\" + fileName  + ".jpg", ImageFormat.Jpeg);
            }
            this.Visible = true;

        }

        private void directorySaveBtn_Click(object sender, EventArgs e)
        {
            int screensCounter = 0;

            
        

            foreach (Screen screen in Screen.AllScreens)
            {
                screensCounter += screen.Bounds.Width;

            }

            this.Visible = false;
            Thread.Sleep(300);
            Bitmap printscreen = new Bitmap(screensCounter, Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage(printscreen as Image);
            graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);

            this.Visible = true;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();

      

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                System.IO.FileStream fs =
                   (System.IO.FileStream)saveFileDialog1.OpenFile();
                // Saves the Image in the appropriate ImageFormat based upon the
                // File type selected in the dialog box.
                // NOTE that the FilterIndex property is one-based.
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        printscreen.Save(fs,
                         System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;

                    case 2:
                        printscreen.Save(fs,
                         System.Drawing.Imaging.ImageFormat.Bmp);
                        break;

                    case 3:
                        printscreen.Save(fs,
                        System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                }
               
               fs.Close();
            } 
        
        }


        private void exitBtn_Click(object sender, EventArgs e)
        {
              Application.Exit();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            isPressed = true;
            pressedPoint = new Point(e.X, e.Y);

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPressed)
            {
                this.Location = new Point(this.Location.X + (e.X - pressedPoint.X), this.Location.Y+ (e.Y- pressedPoint.Y));
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isPressed = false;
            this.Refresh();
        }



        private void optionsBtn_Click(object sender, EventArgs e)
        {
            Optionsw opt = new Optionsw();
            try
           {
                opt.Show();
           }
            catch(Exception err)
           {
               MessageBox.Show("Cannot load data! " + err);
           }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
          //  InitializeComponent();
            KeyboardListener.s_KeyEventHandler += new EventHandler(KeyboardListener_s_KeyEventHandler);
        }

        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vKey);
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        private void recordingBtn_Click(object sender, EventArgs e)
        {
            //capture cpt = new capture();
           // cpt.Show();


            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                string progPath = System.AppDomain.CurrentDomain.BaseDirectory;
                xmlDoc.Load(progPath + @"\options.xml");

                path = xmlDoc.GetElementsByTagName("savePath1");  // get the path from xml file 
                string directory = path[0].InnerText;
                directory = directory.Replace("\\", @"\");

                DateTime Date = DateTime.Now; // this will be the file name
                string fileName;
                fileName = Date.ToString();
                fileName = fileName.Replace("/", ""); fileName = fileName.Replace(":", "");

                XmlNodeList screens = xmlDoc.GetElementsByTagName("screens");  //  gets the screens that need to be recorded
                int scr =Convert.ToInt32(screens[0].InnerText);               //

                
  //***************************************************************************************************     
                switch (scr)
                {
                    case 0: // capture primary only
                    case 1:
                    default:
                job.CaptureRectangle = new Rectangle(0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                
                   break;
                    case 2:  // capture secondary if exist if not capture primary
                   if (Screen.AllScreens.Count() > 1)
                       job.CaptureRectangle = new Rectangle(0 + Screen.PrimaryScreen.Bounds.Width, 0, Screen.AllScreens.ElementAt(1).Bounds.Width, Screen.AllScreens.ElementAt(1).Bounds.Height);
                   else
                       job.CaptureRectangle = new Rectangle(0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                   break;
                   case 3 : // capture both if exist if not capture primary
                   if (Screen.AllScreens.Count() > 1)
                      job.CaptureRectangle = new Rectangle(0, 0, Screen.PrimaryScreen.Bounds.Width + Screen.AllScreens.ElementAt(1).Bounds.Width, Screen.PrimaryScreen.Bounds.Height + Screen.AllScreens.ElementAt(1).Bounds.Height);
                   else
                       job.CaptureRectangle = new Rectangle(0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                   break;
              
               }
 //*************************************************************************************   
                job.CaptureMouseCursor = true;
                
                try
                {
                    stopBtn.Visible = true;
                    stopBtn.Enabled = false;
                    recordingBtn.Enabled = false;
                    job.OutputScreenCaptureFileName = directory + @"\" + fileName + ".wmv";

                    messageWin ms = new messageWin();
                    ms.Show();
                    ms.SetDesktopLocation(0, 0);

                    // this sets a timer delay for 2 seconds 
                    //------------------------------------------------------------
                    DateTime dt1 = DateTime.Now;
                    int diff = 0;

                    while (diff < 3)
                    {

                        DateTime dt2 = DateTime.Now;
                        TimeSpan ts = dt2.Subtract(dt1);
                        diff = (int)ts.TotalSeconds;
                        Application.DoEvents();

                    }
                    //-------------------------------------------------------------
                    ms.Close();
                    
                    this.WindowState = FormWindowState.Minimized;
                    job.Start();
                    stopBtn.Enabled = true;
                    recordingBtn.Enabled = true;
                }
                catch
                {
                    if (!Directory.Exists(@"C:\temp"))
                        Directory.CreateDirectory(@"C:\temp");
                    job.OutputScreenCaptureFileName = @"C:\tmep\" + fileName + ".wmv";
                    job.Start();
                    



                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Cannot start recording, please try again" + err.ToString());
            }
          //  timer = new System.Threading.Timer(ComputeBoundOp, null, 0, 2000);
     
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            job.Stop();
            stopBtn.Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void fileExpBtn_Click_1(object sender, EventArgs e)
        {
            fileExplorer fe = new fileExplorer();
            fe.Show();
        }


        private void minBtn_Click(object sender, EventArgs e)
        {
            this.Refresh();
            this.WindowState = FormWindowState.Minimized;
     
        }

        private void KeyboardListener_s_KeyEventHandler(object sender, EventArgs e)
        {
            KeyboardListener.UniversalKeyEventArgs eventArgs = (KeyboardListener.UniversalKeyEventArgs)e;
            

            // 256 : key down    257 : key up
            if (eventArgs.m_Msg == 256)
            {
                if (eventArgs.KeyData.ToString() == @"F10")
                {
                    job.Stop();
                    this.WindowState = FormWindowState.Normal;
                    stopBtn.Visible = false;
                }
            }
          

        }

      


        
    /*
        private void ComputeBoundOp(Object state)
        {
          
            recordingBtn.Visible = false;
        }
     */
      }
   }
      

    
