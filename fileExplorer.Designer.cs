namespace PrtScn
{
    partial class fileExplorer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fileExplorer));
            this.fileTxt = new System.Windows.Forms.TextBox();
            this.browseBtn = new System.Windows.Forms.Button();
            this.workPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // fileTxt
            // 
            this.fileTxt.Location = new System.Drawing.Point(21, 30);
            this.fileTxt.Name = "fileTxt";
            this.fileTxt.Size = new System.Drawing.Size(533, 20);
            this.fileTxt.TabIndex = 0;
            // 
            // browseBtn
            // 
            this.browseBtn.BackColor = System.Drawing.Color.Gray;
            this.browseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browseBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.browseBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.browseBtn.Location = new System.Drawing.Point(560, 27);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(60, 25);
            this.browseBtn.TabIndex = 5;
            this.browseBtn.Text = "Browse";
            this.browseBtn.UseVisualStyleBackColor = false;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // workPanel
            // 
            this.workPanel.AutoScroll = true;
            this.workPanel.AutoScrollMargin = new System.Drawing.Size(20, 100);
            this.workPanel.AutoSize = true;
            this.workPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.workPanel.Cursor = System.Windows.Forms.Cursors.No;
            this.workPanel.Location = new System.Drawing.Point(21, 76);
            this.workPanel.Name = "workPanel";
            this.workPanel.Size = new System.Drawing.Size(599, 351);
            this.workPanel.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(18, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "File upload:";
            // 
            // fileExplorer
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(649, 451);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.workPanel);
            this.Controls.Add(this.browseBtn);
            this.Controls.Add(this.fileTxt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "fileExplorer";
            this.Text = "file Explorer";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.fileExplorer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox fileTxt;
        private System.Windows.Forms.Button browseBtn;
        private System.Windows.Forms.Panel workPanel;
        private System.Windows.Forms.Label label1;
    }
}