
namespace Band.ManageApp
{
    partial class ImagesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImagesForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.selectAllCheckBox = new System.Windows.Forms.CheckBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.removeImgsBtn = new System.Windows.Forms.PictureBox();
            this.addImgsBtn = new System.Windows.Forms.PictureBox();
            this.imgsContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.removeImgsBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addImgsBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.deleteBtn);
            this.panel1.Controls.Add(this.selectAllCheckBox);
            this.panel1.Controls.Add(this.saveBtn);
            this.panel1.Controls.Add(this.removeImgsBtn);
            this.panel1.Controls.Add(this.addImgsBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(565, 51);
            this.panel1.TabIndex = 0;
            // 
            // deleteBtn
            // 
            this.deleteBtn.Image = ((System.Drawing.Image)(resources.GetObject("deleteBtn.Image")));
            this.deleteBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.deleteBtn.Location = new System.Drawing.Point(493, 10);
            this.deleteBtn.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(60, 36);
            this.deleteBtn.TabIndex = 4;
            this.deleteBtn.Text = "Xoá";
            this.deleteBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Visible = false;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // selectAllCheckBox
            // 
            this.selectAllCheckBox.AutoSize = true;
            this.selectAllCheckBox.Location = new System.Drawing.Point(251, 20);
            this.selectAllCheckBox.Name = "selectAllCheckBox";
            this.selectAllCheckBox.Size = new System.Drawing.Size(57, 19);
            this.selectAllCheckBox.TabIndex = 3;
            this.selectAllCheckBox.Text = "Tất cả";
            this.selectAllCheckBox.UseVisualStyleBackColor = true;
            this.selectAllCheckBox.Visible = false;
            // 
            // saveBtn
            // 
            this.saveBtn.Image = ((System.Drawing.Image)(resources.GetObject("saveBtn.Image")));
            this.saveBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.saveBtn.Location = new System.Drawing.Point(456, 10);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(106, 36);
            this.saveBtn.TabIndex = 2;
            this.saveBtn.Text = "Lưu thay đổi";
            this.saveBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Visible = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // removeImgsBtn
            // 
            this.removeImgsBtn.Image = ((System.Drawing.Image)(resources.GetObject("removeImgsBtn.Image")));
            this.removeImgsBtn.Location = new System.Drawing.Point(53, 3);
            this.removeImgsBtn.Name = "removeImgsBtn";
            this.removeImgsBtn.Size = new System.Drawing.Size(42, 45);
            this.removeImgsBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.removeImgsBtn.TabIndex = 1;
            this.removeImgsBtn.TabStop = false;
            this.removeImgsBtn.Click += new System.EventHandler(this.removeImgsBtn_Click);
            // 
            // addImgsBtn
            // 
            this.addImgsBtn.Image = ((System.Drawing.Image)(resources.GetObject("addImgsBtn.Image")));
            this.addImgsBtn.Location = new System.Drawing.Point(3, 3);
            this.addImgsBtn.Name = "addImgsBtn";
            this.addImgsBtn.Size = new System.Drawing.Size(44, 45);
            this.addImgsBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.addImgsBtn.TabIndex = 0;
            this.addImgsBtn.TabStop = false;
            this.addImgsBtn.Click += new System.EventHandler(this.addImgsBtn_Click);
            this.addImgsBtn.MouseLeave += new System.EventHandler(this.addImgsBtn_MouseLeave);
            this.addImgsBtn.MouseHover += new System.EventHandler(this.addImgsBtn_MouseHover);
            // 
            // imgsContainer
            // 
            this.imgsContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgsContainer.Location = new System.Drawing.Point(0, 57);
            this.imgsContainer.Name = "imgsContainer";
            this.imgsContainer.Size = new System.Drawing.Size(565, 325);
            this.imgsContainer.TabIndex = 1;
            // 
            // ImagesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 383);
            this.Controls.Add(this.imgsContainer);
            this.Controls.Add(this.panel1);
            this.Name = "ImagesForm";
            this.Text = "ImagesForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImagesForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.removeImgsBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addImgsBtn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel imgsContainer;
        private System.Windows.Forms.PictureBox removeImgsBtn;
        private System.Windows.Forms.PictureBox addImgsBtn;
        private System.Windows.Forms.Button saveFileBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.CheckBox selectAllCheckBox;
        private System.Windows.Forms.Button deleteBtn;
    }
}