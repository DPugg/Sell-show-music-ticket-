using Band.ManageApp.Services;
using Band.ViewModels.Catalog.Show;
using Band.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace Band.ManageApp
{
    public partial class StatisticalUserControl : UserControl
    {
        public static StatisticalUserControl _instance;
        private ShowApiClient _showsApiClient;
        private PagingRequestBase _pagingRequest;
        private PageResult<ShowStatiscalViewModel> _data;

        public static StatisticalUserControl Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new StatisticalUserControl();
                }
                return _instance;
            }
        }
        public StatisticalUserControl()
        {
            InitializeComponent();
            _showsApiClient = new ShowApiClient();
            _pagingRequest = new PagingRequestBase()
            {
                PageIndex = 1,
                PageSize = 10
            };
            statiscalDGV.RowCount = 15;
            for (int i = 0; i < statiscalDGV.RowCount; i++)
            {
                statiscalDGV.Rows[i].Cells[0].Value = i + 1;
            }
        }

        private void fillBtn_Click(object sender, EventArgs e)
        {
            if(toDateBox.Value <= fromDateBox.Value)
            {
                MessageBox.Show("thời gian sau phải lớn hơn thời gian trước");
            }
            if (statiscalDGV.Rows[0].Cells[2].Value != null)
            {
                
                foreach (DataGridViewRow row in statiscalDGV.Rows)
                {
                    for (int i = 1; i < statiscalDGV.ColumnCount; i++)
                    {
                        row.Cells[i].Value = null;
                    }
                }
            } 
                
                
            _data=_showsApiClient.GetStatiscalPagingAsync(new ViewModels.Catalog.Show.StatiscalRequest()
            {
                FromDate = fromDateBox.Value,
                ToDate=toDateBox.Value,
                PageIndex=_pagingRequest.PageIndex,
                PageSize=_pagingRequest.PageSize
            });
            loadDataGridView();
        }
        private void loadDataGridView()
        {
/*            statiscalDGV.Rows[0].Selected = true;
*/            for (int i = 0; i < statiscalDGV.RowCount; i++)
            {
                if(i<_data.List.Count)
                {
                    int numTickets = 0;
                    int numTicketsSold = 0;
                    decimal expectedIncome = 0;
                    decimal actualIncome = 0;
                    foreach (var x in _data.List[i].DsChiTietLoaiVe)
                    {
                        numTickets += x.SoLuongBanRa;
                        numTicketsSold += (x.SoLuongBanRa - x.ConLai);
                        expectedIncome += (x.SoLuongBanRa * x.Gia);
                        actualIncome += ((x.SoLuongBanRa - x.ConLai) * x.Gia);
                    }
                    statiscalDGV.Rows[i].Cells["IdShow"].Value = _data.List[i].IdShow;
                    statiscalDGV.Rows[i].Cells["Show"].Value = _data.List[i].TenShow;
                    statiscalDGV.Rows[i].Cells["performDateCol"].Value = _data.List[i].ThoiDiemBieuDien.Date;
                    statiscalDGV.Rows[i].Cells["numTicketsCol"].Value = numTickets;
                    statiscalDGV.Rows[i].Cells["numTicketsSoldCol"].Value = numTicketsSold;
                    statiscalDGV.Rows[i].Cells["expectedIncomeCol"].Value = expectedIncome;
                    statiscalDGV.Rows[i].Cells["actualIncomeCol"].Value = actualIncome;

                }    
                
            }
        }

        private void statiscalDGV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var i = e.ColumnIndex;
            if ( e.RowIndex>0 && (i == 6 || i == 7))
            {
                if (statiscalDGV.Rows[e.RowIndex].Cells[i].Value != null)
                {
                    double price = Convert.ToDouble(statiscalDGV.Rows[e.RowIndex].Cells[i].Value);
                    statiscalDGV.Columns[i].DefaultCellStyle.Format = "c0";
                    statiscalDGV.Columns[i].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("vi-VN");
                    statiscalDGV.Rows[e.RowIndex].Cells[i].Value = price;
                }
                
            }
        }

        private void statiscalDGV_SelectionChanged(object sender, EventArgs e)
        {
            /*if(_data!=null)
                foreach (DataGridViewRow row in statiscalDGV.SelectedRows)
                {
                    locationTxtBox.Text = _data.List[(int)row.Cells[0].Value - 1].DiaDiem;
                }
*/
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void statiscalDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
