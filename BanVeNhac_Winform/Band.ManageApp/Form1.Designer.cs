
namespace Band.ManageApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.BandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ThanhVienMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statiscalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainContainer = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BandToolStripMenuItem,
            this.ThanhVienMenuItem,
            this.showToolStripMenuItem,
            this.statiscalToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(927, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // BandToolStripMenuItem
            // 
            this.BandToolStripMenuItem.Name = "BandToolStripMenuItem";
            this.BandToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.BandToolStripMenuItem.Text = "Nhóm";
            this.BandToolStripMenuItem.Click += new System.EventHandler(this.BandToolStripMenuItem_Click);
            // 
            // ThanhVienMenuItem
            // 
            this.ThanhVienMenuItem.Name = "ThanhVienMenuItem";
            this.ThanhVienMenuItem.Size = new System.Drawing.Size(77, 20);
            this.ThanhVienMenuItem.Text = "Thành viên";
            this.ThanhVienMenuItem.Click += new System.EventHandler(this.ThanhVienMenuItem_Click);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // statiscalToolStripMenuItem
            // 
            this.statiscalToolStripMenuItem.Name = "statiscalToolStripMenuItem";
            this.statiscalToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.statiscalToolStripMenuItem.Text = "Thống kê";
            this.statiscalToolStripMenuItem.Click += new System.EventHandler(this.statiscalToolStripMenuItem_Click);
            // 
            // mainContainer
            // 
            this.mainContainer.AutoScroll = true;
            this.mainContainer.Location = new System.Drawing.Point(12, 39);
            this.mainContainer.Name = "mainContainer";
            this.mainContainer.Size = new System.Drawing.Size(900, 670);
            this.mainContainer.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 722);
            this.Controls.Add(this.mainContainer);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Hệ thống quán lý nhóm nhạc ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem BandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ThanhVienMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statiscalToolStripMenuItem;
        private System.Windows.Forms.Panel mainContainer;
    }
}

