using Band.ManageApp.Services;
using Band.ViewModels.Catalog.LoaiVe;
using Band.ViewModels.Catalog.Show;
using Band.ViewModels.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static Band.ViewModels.Utilities.SystemConstants;

namespace Band.ManageApp
{
    public partial class ShowsUserControl : UserControl
    {
        public static ShowsUserControl _instance;
        private ShowApiClient _showsApiClient;
        private ShowViewModel show;
        private List<LoaiVeViewModel> _dsLoaiVe;
        public static ActionType _actionType;
        private DateTime? _lastValue;
        private List<Image> _imageList;
        private Image _image;
        private bool isEdited;
        private ImageHandler imageHandler;
        public event EventHandler ImageChanged;
        public Image image
        {
            get
            {
                return _image;
            }

            set
            {
                //#3
                _image = value;
                OnImageChanged();
            }
        }
        protected virtual void OnImageChanged()
        {
            if (ImageChanged != null) ImageChanged(this, EventArgs.Empty);
        }

        public static ShowsUserControl Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ShowsUserControl();
                }
                return _instance;
            }
        }
        public ShowsUserControl()
        {
            InitializeComponent();
            show = new ShowViewModel();
            imageHandler = new ImageHandler();
            _showsApiClient = new ShowApiClient();
            _dsLoaiVe = new List<LoaiVeViewModel>();
            /*_actionType = ActionType.READ;*/
            ImageChanged += delegate (object sender, EventArgs arg)
            {
                showPictureBox.Image = image;
            };
            showPictureBox.Click += new EventHandler(editCoverImgBtn_Click);
            Read();
            showPictureBox.Controls.Add(editCoverImgBtn);
            editCoverImgBtn.Location = new Point(showPictureBox.Width - editCoverImgBtn.Width - 10, showPictureBox.Height - editCoverImgBtn.Height - 10);
            editCoverImgBtn.BackColor = Color.FromArgb(125, Color.White);
            performDatebox.MinDate = DateTime.Now;

            var tmp = (ShowGetAllViewModel)showsComboBox.SelectedValue;
            if (tmp == null)
            {
                MessageBox.Show("Show diễn rỗng! Tiến hành thêm Show!");
                addShow();
            }

        }
        private void loadDsShow()
        {
            showsComboBox.DisplayMember = "TenShow";
            showsComboBox.DataSource = _showsApiClient.GetAll();
        }

        private List<LoaiVeViewModel> loadLoaiVe()
        {
            return _showsApiClient.GetAllLoaiVe();
        }
        private void loadDataGridView()
        {
            tiketTypeCol.DataSource = _dsLoaiVe;
            tiketTypeCol.DisplayMember = "TenLoai";
            tiketTypeCol.ValueMember = "IdLoaiVe";
            ticketsTbl.RowCount = 3;
        }
        private void addShowBtn_Click(object sender, EventArgs e)
        {
            addShow();
            
        }

        private void addShow()
        {
            bool isContinue = true;
            if (_actionType != ActionType.READ)
            {

                if (MessageBox.Show("Thoát và không lưu?",
                       "Chưa lưu thay đổi",
                        MessageBoxButtons.YesNo) == DialogResult.No) isContinue = false;
            }
            if (isContinue)
            {
                _imageList = new List<Image>();
                var resourcePath = Path.Combine(Application.StartupPath, @"..\Resources\");
                showPictureBox.Image = new Bitmap(Path.GetFullPath(resourcePath + "image.png"));
                showPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                nameTxtBox.Text = "";
                nameTxtBox.ReadOnly=false;
                locationTxtBox.Text = "";
                locationTxtBox.ReadOnly = false;
                performDatebox.Value = DateTime.Today.AddDays(1);
                performTimeBox.Value = DateTime.Now;
                saleDateBox.Value = DateTime.Today;
                saleTimeBox.Value = DateTime.Now;
                detailTicketTxtBox.Text = "";
                saveBtn.Visible = true;
                exitBtn.Show();
                _actionType = ActionType.CREATE;
                deleteShowBtn.Hide();
                editShowInfoBtn.Hide();
                editTicketInfoBtn.Hide();
                ticketsTbl.ReadOnly = false;
                foreach (DataGridViewRow row in ticketsTbl.Rows)
                {
                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        row.Cells[i].Value = null;
                    }
                }
                if (showsComboBox.FindStringExact("--Đang thêm--") == -1)
                {
                    showsComboBox.SelectedItem = null;
                    showsComboBox.SelectedText = "--Đang thêm--";
                }
                showsComboBox.Enabled = false;

            }
        }

        private void ticketsTbl_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_actionType == ActionType.UPDATE) isEdited = true;
            if (e.RowIndex >= 0)
            {
                DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)ticketsTbl.Rows[e.RowIndex].Cells[0];
                if (cb.Value == null) return;
                string detail="";
                foreach(var x in _dsLoaiVe)
                {
                    if (x.IdLoaiVe == (int)cb.Value)
                    {
                        detail = x.ChiTiet;
                        break;
                    }
                }
                if (cb.Value != null)
                {
                    detailTicketTxtBox.Text = detail;
                    /*ticketsTbl.Rows[e.RowIndex].Cells[1].Value = detail;*/
                }
                ticketsTbl.Rows[e.RowIndex].Cells[3].Value = "Xoá";
            }
            ticketsTbl.Invalidate();
            /*var newValue = ticketsTbl.CurrentCell.EditedFormattedValue;
            var tmp = (LoaiVeViewModel)newValue;
            ticketsTbl.Rows[e.RowIndex].Cells[1].Value = tmp.ChiTiet;*/
        }

        private void ticketsTbl_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (ticketsTbl.IsCurrentCellDirty)
            {
                ticketsTbl.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }


        private void addShowBtn_MouseHover(object sender, EventArgs e)
        {
            addShowBtn.BackColor = Color.FromArgb(125, Color.Black);
        }

        private void addShowBtn_MouseLeave(object sender, EventArgs e)
        {
            addShowBtn.BackColor = Color.FromArgb(0, Color.Black);
        }

        private void editCoverImgBtn_Click(object sender, EventArgs e)
        {
            var showGetAllVm = new ShowGetAllViewModel();
            showGetAllVm = showsComboBox.SelectedValue as ShowGetAllViewModel;
            ImagesForm imagesForm = new ImagesForm();
            if (_actionType != ActionType.CREATE)
                imagesForm.SenderInfo(ImageType.IMG_SHOW, showGetAllVm.IdShow);
            else
            {
                imagesForm.SenderInfo(ImageType.IMG_SHOW);
                imagesForm.SenderImgList(_imageList);
            }
                

            imagesForm.ShowDialog();
            if (imagesForm._images.Count > 0)
                image = imagesForm._images.FirstOrDefault().Anh;
            if (_actionType == ActionType.CREATE && _imageList != null)
            {
                _imageList.Clear();
                foreach (var x in imagesForm._images)
                {
                    _imageList.Add(x.Anh);
                }
            }
        }

        private void showsComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            /*ComboBox cb = sender as ComboBox;
            ShowGetAllViewModel tmp = cb.SelectedValue as ShowGetAllViewModel;
            var i= tmp.IdShow;*/
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedValue != null)
            {
                
                ShowGetAllViewModel tmp = cb.SelectedValue as ShowGetAllViewModel;
                show = _showsApiClient.GetById(tmp.IdShow);

                var byteImage = imageHandler._imageConverter.ConvertFrom(show.HinhAnh);
                image = (Image)byteImage;

                bindingShowInfo(show);
                bindingTicketInfo(show);

                
                /*twitterTxtBox.Text = thanhVien.Twitter;
                storyTxtBox.Text = thanhVien.TieuSu;*/
            }
        }

        private void bindingTicketInfo(ShowViewModel show)
        {
            for (int i = 0; i < show.DsChiTietLoaiVe.Count; i++)
            {
                ticketsTbl.Rows[i].Cells[0].Value = show.DsChiTietLoaiVe[i].IdLoaiVe;
                ticketsTbl.Rows[i].Cells[1].Value = show.DsChiTietLoaiVe[i].Gia;
                ticketsTbl.Rows[i].Cells[2].Value = show.DsChiTietLoaiVe[i].SoLuongBanRa;
            }
        }

        private void performDatebox_ValueChanged(object sender, EventArgs e)
        {
            if(_lastValue.HasValue && _actionType==ActionType.READ)
                performDatebox.Value = _lastValue.Value;
        }

        private void performDatebox_MouseCaptureChanged(object sender, EventArgs e)
        {
            if (_actionType == ActionType.READ)
                _lastValue = performDatebox.Value;
        }

        private void performTimeBox_ValueChanged(object sender, EventArgs e)
        {
            if (_lastValue.HasValue && _actionType == ActionType.READ)
                performTimeBox.Value = _lastValue.Value;
        }

        private void performTimeBox_MouseCaptureChanged(object sender, EventArgs e)
        {
            if (_actionType == ActionType.READ)
                _lastValue = performTimeBox.Value;
        }

        private void saleDateBox_MouseCaptureChanged(object sender, EventArgs e)
        {
            if (_actionType == ActionType.READ)
                _lastValue = saleDateBox.Value;
        }

        private void saleDateBox_ValueChanged(object sender, EventArgs e)
        {
            if (_lastValue.HasValue && _actionType == ActionType.READ)
                saleDateBox.Value = _lastValue.Value;
        }

        private void saleTimeBox_ValueChanged(object sender, EventArgs e)
        {
            if (_lastValue.HasValue && _actionType == ActionType.READ)
                saleTimeBox.Value = _lastValue.Value;
        }

        private void saleTimeBox_MouseCaptureChanged(object sender, EventArgs e)
        {
            if (_actionType == ActionType.READ)
                _lastValue = saleTimeBox.Value;
        }

        private void editShowInfoBtn_Click(object sender, EventArgs e)
        {
            editShowInfo();
            
        }

        private void editShowInfo()
        {
            bool isContinue = true;
            if (_actionType == ActionType.CREATE) return;// Đang thêm mới
            if (_actionType != ActionType.READ && saveShowInfoBtn.Visible == false)
            {
                isContinue = false;
                if (MessageBox.Show("Thoát và không lưu?",
                       "Chưa lưu thay đổi",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bindingTicketInfo(show);
                    isContinue = true;
                }
            }
            if (isContinue && saveShowInfoBtn.Visible == false)
            {
                nameTxtBox.ReadOnly = false;
                locationTxtBox.ReadOnly = false;
                _actionType = ActionType.UPDATE;
                saveShowInfoBtn.Show();
            }
        }

        private void bindingShowInfo(ShowViewModel show)
        {
            nameTxtBox.Text = show.TenShow;
            locationTxtBox.Text = show.DiaDiem;
            performDatebox.Value = show.ThoiDiemBieuDien;
            performTimeBox.Value = show.ThoiDiemBieuDien;
            saleDateBox.Value = show.ThoiDiemMoBan;
            saleTimeBox.Value = show.ThoiDiemMoBan;
        }

        private void editTicketInfoBtn_Click(object sender, EventArgs e)
        {
            bool isContinue = true;
            if (_actionType != ActionType.READ && saveTiketInfoBtn.Visible == false)
            {
                isContinue = false;
                if (MessageBox.Show("Thoát và không lưu?",
                       "Chưa lưu thay đổi",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bindingShowInfo(show);
                    isContinue = true;
                }
            }
            if (isContinue && saveTiketInfoBtn.Visible == false)
            {
                ticketsTbl.ReadOnly = false;
                _actionType = ActionType.UPDATE;
                saveTiketInfoBtn.Show();
            } 
        }

        private void saveShowInfoBtn_Click(object sender, EventArgs e)
        {
            ShowGetAllViewModel tmp = new ShowGetAllViewModel();
            tmp = (ShowGetAllViewModel)showsComboBox.SelectedValue;
            var showInfoUpdateRequest = new ShowInfoUpdateRequest()
            {
                IdShow= tmp.IdShow,
                DiaDiem = locationTxtBox.Text,
                TenShow = nameTxtBox.Text,
                GioBieuDien = performTimeBox.Value,
                NgayBieuDien = performDatebox.Value,
                GioMoBan = saleTimeBox.Value,
                NgayMoBan = saleDateBox.Value,
            };
            if (_showsApiClient.UpdateShowInfor(showInfoUpdateRequest))
            {
                MessageBox.Show("Thành công!");
                Read();
            }
            else MessageBox.Show("Thất bại!");
        }

/*        private void saveBtn_Click_1(object sender, EventArgs e)
        {
            *//*foreach (DataGridViewRow row in ticketsTbl.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    if (row.Cells[i].Value == null || row.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(row.Cells[i].Value.ToString()))
                    {
                        MessageBox.Show("Vui lòng điền đẩy đủ thông tin");
                    }
                }
            }*//*

            List<byte[]> byteImageList = new List<byte[]>();
            foreach (Image img in _imageList)
            {
                byteImageList.Add(imageHandler.ImageToByteArray(img));
            }

            bool errorFlag = false;
            var dsChiTietVe = new List<ChiTietVeViewModel>();
            foreach (DataGridViewRow row in ticketsTbl.Rows)
            {
                int countNull = 0;
                *//*                int i = 0;*//*
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    if (row.Cells[i].Value == null || row.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(row.Cells[i].Value.ToString()))
                    {
                        countNull++;
                    }
                }
                if (countNull == 3) continue;
                else if (countNull == 0)
                    dsChiTietVe.Add(new ChiTietVeViewModel()
                    {
                        IdLoaiVe = (int)row.Cells[0].Value,
                        Gia = Convert.ToDecimal(row.Cells[1].Value.ToString()),
                        SoLuongBanRa = Convert.ToInt32(row.Cells[2].Value.ToString())
                    });
                else
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                    errorFlag = true;
                    break;
                }
            }
            if (!errorFlag)
            {
                var showCreateRequest = new ShowCreateRequest()
                {
                    DiaDiem = locationTxtBox.Text,
                    TenShow = nameTxtBox.Text,
                    GioBieuDien = performTimeBox.Value,
                    NgayBieuDien = performDatebox.Value,
                    GioMoBan = saleTimeBox.Value,
                    NgayMoBan = saleDateBox.Value,
                    DsHinhAnh = byteImageList,
                    DsChiTietLoaiVe = dsChiTietVe
                };
                if (_showsApiClient.Create(showCreateRequest))
                {
                    MessageBox.Show("Thành công!");
                }
                else MessageBox.Show("Thất bại!");
                saveBtn.Visible = false;
            }
        }
*/
        private void ticketsTbl_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(priceTicketCol_KeyPress);
            e.Control.KeyPress -= new KeyPressEventHandler(quantityTicketCol_KeyPress);
            if (ticketsTbl.CurrentCell.ColumnIndex == 1) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(priceTicketCol_KeyPress);
                }
            }
            else if (ticketsTbl.CurrentCell.ColumnIndex == 2) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(quantityTicketCol_KeyPress);
                }
            }
        }
        private void ticketPriceCol_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void priceTicketCol_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void quantityTicketCol_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            /*foreach (DataGridViewRow row in ticketsTbl.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    if (row.Cells[i].Value == null || row.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(row.Cells[i].Value.ToString()))
                    {
                        MessageBox.Show("Vui lòng điền đẩy đủ thông tin");
                    }
                }
            }*/

            //Kiểm tra hình ảnh
            if (_imageList.Count<=0)
            {
                MessageBox.Show("Vui lòng thêm hình ảnh quảng bá cho show diễn!");
                return;
            }
            List<byte[]> byteImageList = new List<byte[]>();
            foreach (Image img in _imageList)
            {
                byteImageList.Add(imageHandler.ImageToByteArray(img));
            }

            //Kiểm tra thông tin show
            if(checkNull(nameTxtBox.Text))
            {
                MessageBox.Show("Vui lòng nhập tên show diễn!");
                nameTxtBox.Focus();
                return;
            }
            else if(checkNull(locationTxtBox.Text))
            {
                MessageBox.Show("Vui lòng nhập địa điểm diễn ra show diễn!");
                locationTxtBox.Focus();
                return;
            }
            if (saleDateBox.Value >= performDatebox.Value)
            {
                MessageBox.Show("Thời gian mở bán vé phải nhỏ hơn ngày biểu diễn!");
                return;
            }


            //Kiểm tra danh sách loại vé
            var dsChiTietVe = new List<ChiTietVeViewModel>();
            int errorNum = getDsLoaiVeFromDGV(ref dsChiTietVe);
            if (errorNum == -1) //Thiếu thông tin loại vé
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin loại vé!");
                return;
            }
            else if (errorNum == -2)//Trùng loại vé
            {
                MessageBox.Show("Danh sách các loại vé không được trùng nhau!");
                return;
            }

            // Tạo request
            var showCreateRequest = new ShowCreateRequest()
            {
                DiaDiem = locationTxtBox.Text,
                TenShow = nameTxtBox.Text,
                GioBieuDien = performTimeBox.Value,
                NgayBieuDien = performDatebox.Value,
                GioMoBan = saleTimeBox.Value,
                NgayMoBan = saleDateBox.Value,
                DsHinhAnh = byteImageList,
                DsChiTietLoaiVe = dsChiTietVe
            };
            if (_showsApiClient.Create(showCreateRequest))
            {
                MessageBox.Show("Thành công!");
                Read();
                
            }
            else MessageBox.Show("Thất bại!");
        }

        private void Read()
        {
            _dsLoaiVe = loadLoaiVe();
            loadDataGridView();
            loadDsShow();
            saveBtn.Visible = false;
            saveBtn.Hide();
            exitBtn.Hide();
            showsComboBox.Enabled = true;
            showPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            showsComboBox.Show();
            deleteShowBtn.Show();
            editShowInfoBtn.Show();
            editTicketInfoBtn.Show();
            saveShowInfoBtn.Hide();
            saveTiketInfoBtn.Hide();
            /*nameTxtBox.ReadOnly = true;*/
            /*locationTxtBox.ReadOnly = true;*/
            ticketsTbl.ReadOnly = true;
            _actionType = ActionType.READ;
        }

        private int getDsLoaiVeFromDGV(ref List<ChiTietVeViewModel> dsChiTietVe)
        {
            var result = new List<ChiTietVeViewModel>();
            foreach (DataGridViewRow row in ticketsTbl.Rows)
            {
                int countNull = 0;
                for (int i = 0; i < row.Cells.Count - 1; i++)
                {
                    if (checkNull(row.Cells[i].Value))
                    {

                        countNull++;
                    }
                }
                if (countNull == 3) continue;
                else if (countNull == 0)
                {
                    result.Add(new ChiTietVeViewModel()
                    {
                        IdLoaiVe = (int)row.Cells[0].Value,
                        Gia = Convert.ToDecimal(row.Cells[1].Value.ToString()),
                        SoLuongBanRa = Convert.ToInt32(row.Cells[2].Value.ToString())
                    });
                }
                else
                {
                    
                    return -1;
                }
            }
            for(int i=0; i < result.Count-1; i++)
            {
                for(int j=i+1; j<result.Count; j++)
                {
                    if (result[i].IdLoaiVe == result[j].IdLoaiVe)
                    {
                        return -2;
                    }
                }
            }
            dsChiTietVe = result;
            return 1;
        }

        private void ticketsTbl_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                double price = Convert.ToDouble(ticketsTbl.Rows[e.RowIndex].Cells[1].Value);
                ticketsTbl.Columns[1].DefaultCellStyle.Format = "c0";
                ticketsTbl.Columns[1].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("vi-VN");
                ticketsTbl.Rows[e.RowIndex].Cells[1].Value = price;
            }
        }

        private void saveTiketInfoBtn_Click(object sender, EventArgs e)
        {
            var dsChiTietVe = new List<ChiTietVeViewModel>();
            int errorNum= getDsLoaiVeFromDGV(ref dsChiTietVe);
            if (errorNum == -1) //Thiếu thông tin loại vé
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin loại vé!");
                return;
            }
            else if(errorNum==-2)//Trùng loại vé
            {
                MessageBox.Show("Danh sách các loại vé không được trùng nhau!");
                return;
            }    
            else
            {
                ShowGetAllViewModel tmp = (ShowGetAllViewModel)showsComboBox.SelectedValue;
                var request = new TicketInfoUpdateRequest()
                {
                    IdShow = tmp.IdShow,
                    dsChiTietVe = dsChiTietVe
                };
                
                    
                if (_showsApiClient.UpdateTicketInfor(request))
                {
                    MessageBox.Show("Thành công!");
                    saveBtn.Visible = false;
                }
                else MessageBox.Show("Thất bại!");
            }
        }

        private bool checkNull(object value)
        {
            if (value == null || value == DBNull.Value || String.IsNullOrWhiteSpace(value.ToString())) return true;
            return false;
        }

        private void ticketsTbl_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                if (ticketsTbl.ReadOnly == true) return;
                foreach (DataGridViewRow row in ticketsTbl.Rows)
                {
                    int countNull = 0;
                    for (int i = 0; i < row.Cells.Count - 1; i++)
                    {
                        if (checkNull(row.Cells[i].Value))
                        {

                            countNull++;
                        }
                    }
                    if (countNull == 3) return;
                    else
                    {

                        if (MessageBox.Show("Bạn chắc chắn muốn xoá?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                ticketsTbl.Rows[e.RowIndex].Cells[i].Value = null;
                            }
                        }
                    }
                }
                
            }
        }

        private void deleteShowBtn_Click(object sender, EventArgs e)
        {
            var tmp = (ShowGetAllViewModel)showsComboBox.SelectedValue;
            if (!_showsApiClient.Delete(tmp.IdShow))
                MessageBox.Show("Thất bại!");
            else
            {
                MessageBox.Show("Thành công!");
                Read();
            }
        }

        private void locationTxtBox_TextChanged(object sender, EventArgs e)
        {
            if (!locationTxtBox.Focused) return;
            if (!saveShowInfoBtn.Visible)
            {
                editShowInfo();
            }
        }

        private void nameTxtBox_TextChanged(object sender, EventArgs e)
        {
            if (!nameTxtBox.Focused) return;
            if (!saveShowInfoBtn.Visible)
            {
                editShowInfo();
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Thoát và không lưu?",
                      "Chưa lưu thay đổi",
                       MessageBoxButtons.YesNo) == DialogResult.Yes) Read();
        }

        /*private ChiTietVeViewModel checkForCorrectnessChiTietVe(object id, object price, object quantity)
        {
            int countNull = 0;
            int idTicketType;
            if (id == null) countNull++;
            else idTicketType = (int)id;

            decimal priceTicket;
            if (price == null) countNull++;
            else priceTicket = (decimal)price;

            int quantityTicket;
            if (quantity == null) countNull++;
            else quantityTicket = (int)quantity;

            if (countNull == 3) return null;
            if()

        }*/
    }
}
