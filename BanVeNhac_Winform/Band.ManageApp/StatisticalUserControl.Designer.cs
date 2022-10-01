
namespace Band.ManageApp
{
    partial class StatisticalUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.fromDateBox = new System.Windows.Forms.DateTimePicker();
            this.toDateBox = new System.Windows.Forms.DateTimePicker();
            this.statiscalDGV = new System.Windows.Forms.DataGridView();
            this.serialCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdShow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Show = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.performDateCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numTicketsCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numTicketsSoldCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expectedIncomeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actualIncomeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fillBtn = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.ticketsTbl = new System.Windows.Forms.DataGridView();
            this.tiketTypeCol = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.priceTicketCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityTicketCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationTxtBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.saleDateBox = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.statiscalDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ticketsTbl)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fromDateBox
            // 
            this.fromDateBox.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fromDateBox.Location = new System.Drawing.Point(169, 49);
            this.fromDateBox.Name = "fromDateBox";
            this.fromDateBox.Size = new System.Drawing.Size(142, 23);
            this.fromDateBox.TabIndex = 0;
            // 
            // toDateBox
            // 
            this.toDateBox.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.toDateBox.Location = new System.Drawing.Point(495, 49);
            this.toDateBox.Name = "toDateBox";
            this.toDateBox.Size = new System.Drawing.Size(147, 23);
            this.toDateBox.TabIndex = 1;
            // 
            // statiscalDGV
            // 
            this.statiscalDGV.BackgroundColor = System.Drawing.SystemColors.Control;
            this.statiscalDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.statiscalDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.serialCol,
            this.IdShow,
            this.Show,
            this.performDateCol,
            this.numTicketsCol,
            this.numTicketsSoldCol,
            this.expectedIncomeCol,
            this.actualIncomeCol});
            this.statiscalDGV.Location = new System.Drawing.Point(19, 94);
            this.statiscalDGV.Name = "statiscalDGV";
            this.statiscalDGV.ReadOnly = true;
            this.statiscalDGV.RowHeadersVisible = false;
            this.statiscalDGV.RowTemplate.Height = 25;
            this.statiscalDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.statiscalDGV.Size = new System.Drawing.Size(840, 205);
            this.statiscalDGV.TabIndex = 2;
            this.statiscalDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.statiscalDGV_CellContentClick);
            this.statiscalDGV.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.statiscalDGV_CellValueChanged);
            this.statiscalDGV.SelectionChanged += new System.EventHandler(this.statiscalDGV_SelectionChanged);
            // 
            // serialCol
            // 
            this.serialCol.HeaderText = "STT";
            this.serialCol.Name = "serialCol";
            this.serialCol.ReadOnly = true;
            this.serialCol.Width = 40;
            // 
            // IdShow
            // 
            this.IdShow.HeaderText = "IdShow";
            this.IdShow.Name = "IdShow";
            this.IdShow.ReadOnly = true;
            this.IdShow.Visible = false;
            // 
            // Show
            // 
            this.Show.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Show.HeaderText = "Show";
            this.Show.Name = "Show";
            this.Show.ReadOnly = true;
            // 
            // performDateCol
            // 
            this.performDateCol.HeaderText = "Ngày biểu diễn";
            this.performDateCol.Name = "performDateCol";
            this.performDateCol.ReadOnly = true;
            this.performDateCol.Width = 120;
            // 
            // numTicketsCol
            // 
            this.numTicketsCol.HeaderText = "Số vé bán ra";
            this.numTicketsCol.Name = "numTicketsCol";
            this.numTicketsCol.ReadOnly = true;
            this.numTicketsCol.Width = 120;
            // 
            // numTicketsSoldCol
            // 
            this.numTicketsSoldCol.HeaderText = "Số vé đã bán";
            this.numTicketsSoldCol.Name = "numTicketsSoldCol";
            this.numTicketsSoldCol.ReadOnly = true;
            this.numTicketsSoldCol.Width = 120;
            // 
            // expectedIncomeCol
            // 
            this.expectedIncomeCol.DataPropertyName = "C0";
            this.expectedIncomeCol.HeaderText = "Thu vào dự kiến";
            this.expectedIncomeCol.Name = "expectedIncomeCol";
            this.expectedIncomeCol.ReadOnly = true;
            this.expectedIncomeCol.Width = 130;
            // 
            // actualIncomeCol
            // 
            this.actualIncomeCol.DataPropertyName = "C0";
            this.actualIncomeCol.HeaderText = "Thu vào thực tế";
            this.actualIncomeCol.Name = "actualIncomeCol";
            this.actualIncomeCol.ReadOnly = true;
            this.actualIncomeCol.Width = 130;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Từ ngày";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(394, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Đến ngày";
            // 
            // fillBtn
            // 
            this.fillBtn.Location = new System.Drawing.Point(734, 51);
            this.fillBtn.Name = "fillBtn";
            this.fillBtn.Size = new System.Drawing.Size(75, 23);
            this.fillBtn.TabIndex = 5;
            this.fillBtn.Text = "Thống kê";
            this.fillBtn.UseVisualStyleBackColor = true;
            this.fillBtn.Click += new System.EventHandler(this.fillBtn_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(3, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(144, 25);
            this.label9.TabIndex = 19;
            this.label9.Text = "Thông tin show";
            // 
            // ticketsTbl
            // 
            this.ticketsTbl.AllowUserToAddRows = false;
            this.ticketsTbl.AllowUserToDeleteRows = false;
            this.ticketsTbl.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ticketsTbl.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ticketsTbl.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ticketsTbl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ticketsTbl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ticketsTbl.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tiketTypeCol,
            this.priceTicketCol,
            this.quantityTicketCol});
            this.ticketsTbl.Location = new System.Drawing.Point(439, 56);
            this.ticketsTbl.MultiSelect = false;
            this.ticketsTbl.Name = "ticketsTbl";
            this.ticketsTbl.ReadOnly = true;
            this.ticketsTbl.RowHeadersVisible = false;
            this.ticketsTbl.RowTemplate.Height = 25;
            this.ticketsTbl.Size = new System.Drawing.Size(370, 98);
            this.ticketsTbl.TabIndex = 14;
            // 
            // tiketTypeCol
            // 
            this.tiketTypeCol.HeaderText = "Loại vé";
            this.tiketTypeCol.Name = "tiketTypeCol";
            this.tiketTypeCol.ReadOnly = true;
            this.tiketTypeCol.Width = 120;
            // 
            // priceTicketCol
            // 
            this.priceTicketCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.priceTicketCol.DefaultCellStyle = dataGridViewCellStyle2;
            this.priceTicketCol.HeaderText = "Giá";
            this.priceTicketCol.Name = "priceTicketCol";
            this.priceTicketCol.ReadOnly = true;
            // 
            // quantityTicketCol
            // 
            this.quantityTicketCol.HeaderText = "Số lượng";
            this.quantityTicketCol.Name = "quantityTicketCol";
            this.quantityTicketCol.ReadOnly = true;
            this.quantityTicketCol.Width = 120;
            // 
            // locationTxtBox
            // 
            this.locationTxtBox.Location = new System.Drawing.Point(122, 56);
            this.locationTxtBox.Name = "locationTxtBox";
            this.locationTxtBox.Size = new System.Drawing.Size(262, 23);
            this.locationTxtBox.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "Địa điểm";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 115);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 15);
            this.label8.TabIndex = 18;
            this.label8.Text = "Ngày mở bán vé";
            // 
            // saleDateBox
            // 
            this.saleDateBox.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.saleDateBox.Location = new System.Drawing.Point(122, 107);
            this.saleDateBox.Name = "saleDateBox";
            this.saleDateBox.Size = new System.Drawing.Size(141, 23);
            this.saleDateBox.TabIndex = 17;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.saleDateBox);
            this.panel1.Controls.Add(this.ticketsTbl);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.locationTxtBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(22, 305);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(840, 180);
            this.panel1.TabIndex = 20;
            this.panel1.Visible = false;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(382, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 23);
            this.label3.TabIndex = 21;
            this.label3.Text = "Thống kê doanh số";
            // 
            // StatisticalUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.fillBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statiscalDGV);
            this.Controls.Add(this.toDateBox);
            this.Controls.Add(this.fromDateBox);
            this.Name = "StatisticalUserControl";
            this.Size = new System.Drawing.Size(900, 660);
            ((System.ComponentModel.ISupportInitialize)(this.statiscalDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ticketsTbl)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker fromDateBox;
        private System.Windows.Forms.DateTimePicker toDateBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Show;
        private System.Windows.Forms.DataGridViewTextBoxColumn performDateCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn numTicketsCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn numTicketsSold;
        private System.Windows.Forms.DataGridViewTextBoxColumn expectedIncomeCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn actualIncomeCol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button fillBtn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView ticketsTbl;
        private System.Windows.Forms.DataGridViewComboBoxColumn tiketTypeCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceTicketCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityTicketCol;
        private System.Windows.Forms.TextBox locationTxtBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker saleDateBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView statiscalDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdShow;
        private System.Windows.Forms.DataGridViewTextBoxColumn serialCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn numTicketsSoldCol;
        private System.Windows.Forms.Label label3;
    }
}
