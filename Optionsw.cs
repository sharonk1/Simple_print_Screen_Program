using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace PrtScn
{

    public partial class Optionsw : Form
    {
        public Optionsw()
        {
            InitializeComponent();

        }

       

        private void Optionsw_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.browseBtn, "Browse");

            System.Windows.Forms.ToolTip ToolTip3 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.closeBtn, "Close");

            System.Windows.Forms.ToolTip ToolTip2 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.saveBtn, "Save");

            XmlDocument xmlDoc = new XmlDocument();
            string progPath = System.AppDomain.CurrentDomain.BaseDirectory;
            try
            {
                xmlDoc.Load(progPath + @"\options.xml");
                XmlNodeList path = xmlDoc.GetElementsByTagName("savePath0");
                directorytxt.Text = path[0].InnerText;  // get the path from the xml file and put into textbox

                XmlNodeList path2 = xmlDoc.GetElementsByTagName("savePath1");
                directory2Txt.Text = path2[0].InnerText;  // get the video path from the xml file and put into textbox

                XmlNodeList screens = xmlDoc.GetElementsByTagName("screens");
                // string scr =screens[0].InnerText;
                int scr = Convert.ToInt32(screens[0].InnerText);

                switch (scr)
                {
                    case 0:
                        checkBox2.Checked = false;
                        checkBox1.Checked = false;
                        break;
                    case 1:
                        checkBox2.Checked = false;
                        checkBox1.Checked = true;
                        break;
                    case 2:
                        checkBox2.Checked = true;
                        checkBox1.Checked = false;
                        break;
                    case 3:
                        checkBox2.Checked = true;
                        checkBox1.Checked = true;
                        break;
                    default:
                        checkBox2.Checked = false;
                        checkBox1.Checked = true;
                        break;
                }
                XmlNodeList res = xmlDoc.GetElementsByTagName("resolution");
                savedResLbl.Text = savedResLbl.Text + res[0].InnerText;
            }
            catch ( Exception err)
            {
                MessageBox.Show("Cannot load data, please try again " + err);
            }
          
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();  
            directorytxt.Text = folderBrowserDialog1.SelectedPath.ToString();

        }

        private void browse2Btn_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            directory2Txt.Text = folderBrowserDialog1.SelectedPath.ToString();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            int scr=0;
            // update the xml file 
            string progPath = System.AppDomain.CurrentDomain.BaseDirectory;
            try
            {
                XDocument xmlDoc = XDocument.Load(progPath + @"\options.xml");
                if (directorytxt.Text != "")
                    xmlDoc.Root.Element("savePath0").Value = directorytxt.Text;
                else
                    xmlDoc.Element("savePath0").Value = @"C:\temp\";

                if (directory2Txt.Text != "")
                    xmlDoc.Root.Element("savePath1").Value = directory2Txt.Text;
                else
                    xmlDoc.Root.Element("savePath1").Value = @"C:\temp\";

                if ((!checkBox1.Checked) && (!checkBox2.Checked))
                    scr = 0;
                else if ((checkBox1.Checked) && (!checkBox2.Checked))
                    scr = 1;
                else if ((!checkBox1.Checked) && (checkBox2.Checked))
                    scr = 2;
                else if ((checkBox1.Checked) && (checkBox2.Checked))
                    scr = 3;
                else scr = 0;

                xmlDoc.Root.Element("screens").Value = scr.ToString();

                xmlDoc.Save(progPath + @"options.xml");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Cannot save data, please try again");
                this.Close();
            }
            
        }

     

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveResolution_Click(object sender, EventArgs e)
        {
            string progPath = System.AppDomain.CurrentDomain.BaseDirectory;
            try
            {
                XDocument xmlDoc = XDocument.Load(progPath + @"\options.xml");

                int heigth = Screen.PrimaryScreen.Bounds.Height;
                int width = Screen.PrimaryScreen.Bounds.Width;

                xmlDoc.Root.Element("resolution").Value = width.ToString() + "by" + heigth.ToString();
                xmlDoc.Save(progPath + @"options.xml");
                savedResLbl.Text = "Current saved: " + width.ToString() + "by" + heigth.ToString();
            }
            catch
            {
                MessageBox.Show("Cannot save data, please try again");
            }
        }

        private void restoreSavedResBtn_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load("options.xml");
                XmlNodeList res = xmlDoc.GetElementsByTagName("resolution");
                string resolutionStr = res[0].InnerText;
                resolutionStr = resolutionStr.Replace("by", ",");
                IList<string> resolution = resolutionStr.Split(',').ToList<string>();

                string H = resolution[0].ToString();
                string W = resolution[1].ToString();
                Resolution.CResolution ChangeRes1024 = new Resolution.CResolution(Convert.ToInt32(H), Convert.ToInt32(W));
            }
            catch
            {
                MessageBox.Show("Some error occurred, please try again");
            }
            }

  

      
    }
}
