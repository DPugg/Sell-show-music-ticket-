using Band.ManageApp.Services;
using Band.ViewModels.Catalog.Band;
using Band.ViewModels.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static Band.ViewModels.Utilities.SystemConstants;

namespace Band.ManageApp
{
    public partial class BandUserControl : UserControl
    {
        public static BandUserControl _instance;
        private ImageHandler imageHandler;
        private BandApiClient _bandApiClient;
        public static ActionType _actionType;
        private Image _logo;
        private Image _image;
        private List<Image> _imgList;
        public event EventHandler ImageChanged;
        public event EventHandler LogoChanged;
        public Image logo
        {
            get
            {
                return _logo;
            }

            set
            {
                //#3
                _logo = value;
                OnLogoChanged();
            }
        }
        protected virtual void OnLogoChanged()
        {
            if (LogoChanged != null) LogoChanged(this, EventArgs.Empty);
        }
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
        public BandViewModel _band { get; set; }
        public static BandUserControl Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BandUserControl();
                }
                return _instance;
            }
        }

        public BandUserControl()
        {
            InitializeComponent();
            imageHandler = new ImageHandler();
            LogoChanged += delegate (object sender, EventArgs arg)
            {
                logoImgBox.Image = logo;
            };
            ImageChanged += delegate (object sender, EventArgs arg)
            {
                imgBox.SizeMode = PictureBoxSizeMode.StretchImage;
                imgBox.Image = image;
            };
            logoImgBox.Controls.Add(editLogoBtn);
            editLogoBtn.Location = new Point(logoImgBox.Width - editLogoBtn.Width - 5, logoImgBox.Height - editLogoBtn.Height - 5);
            editLogoBtn.BackColor = Color.FromArgb(125, Color.White);
            imgBox.Controls.Add(editImgBtn);
            editImgBtn.Location = new Point(imgBox.Width - editImgBtn.Width - 5, imgBox.Height - editImgBtn.Height - 5);
            editImgBtn.BackColor = Color.FromArgb(125, Color.White);
            Read();
            
        }

        private void Read()
        {
            loadBandInfo();
            if (_band == null)
            {
                _actionType = ActionType.CREATE;
                saveBtn.Show();
                exitBtn.Show();
                return;
            }
            saveBtn.Hide();
            exitBtn.Hide();
            _actionType = ActionType.READ;
        }

        private void loadBandInfo()
        {
            if (_bandApiClient == null) _bandApiClient = new BandApiClient();
            /*if (_band == null) _band = new BandViewModel();*/
            _band=_bandApiClient.Get();
            if (_band == null)
            {
                MessageBox.Show("Chưa có thông tin của nhóm! Vui lòng thêm thông tin cho nhóm!");
                _actionType = ActionType.CREATE;
                return;
            }
            BindingData();
        }

        private void BindingData()
        {
            nameTxtBox.Text = _band.TenNhom;
            debuteDateBox.Value = _band.DebutDate;
            companyTxtBox.Text = _band.CongTy;
            spotifyTxtBox.Text = _band.Spotify;
            appleMusicTxtBox.Text = _band.AppleMusic;
            youtubeTxtBox.Text = _band.Youtube;
            detailTxtBox.Text = _band.ChiTiet;
            logo = (Image)imageHandler._imageConverter.ConvertFrom(_band.Logo);
            if(_band.Image!=null)
            image = (Image)imageHandler._imageConverter.ConvertFrom(_band.Image);
        }

        private void instaTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void nameTxtBox_TextChanged(object sender, EventArgs e)
        {
            if (_actionType == ActionType.CREATE) return;
            if (!nameTxtBox.Focused) return;
            if (!saveBtn.Visible)
            {
                Updating();
            }
        }

        private void Updating()
        {
            saveBtn.Visible = true;
            exitBtn.Show();
            _actionType = ActionType.UPDATE;
        }

        private void debuteDateBox_ValueChanged(object sender, EventArgs e)
        {
            if (_actionType == ActionType.CREATE) return;
            if (!nameTxtBox.Focused) return;
            if (!saveBtn.Visible)
                Updating();
        }

        private void companyTxtBox_TextChanged(object sender, EventArgs e)
        {
            if (_actionType == ActionType.CREATE) return;
            if (!nameTxtBox.Focused) return;
            if (!saveBtn.Visible)
                Updating();
        }

        private void spotifyTxtBox_TextChanged(object sender, EventArgs e)
        {
            if (_actionType == ActionType.CREATE) return;
            if (!nameTxtBox.Focused) return;
            if (!saveBtn.Visible)
                Updating();
        }

        private void youtubeTxtBox_TextChanged(object sender, EventArgs e)
        {
            if (_actionType == ActionType.CREATE) return;
            if (!nameTxtBox.Focused) return;
            if (!saveBtn.Visible)
                Updating();
        }

        private void detailTxtBox_TextChanged(object sender, EventArgs e)
        {
            if (_actionType == ActionType.CREATE) return;
            if (!nameTxtBox.Focused) return;
            if (!saveBtn.Visible)
                Updating();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (checkNull(nameTxtBox.Text))
            {
                MessageBox.Show("Tên nhóm không được rỗng!");
                nameTxtBox.Focus();
                return;
            }
            else if (checkNull(companyTxtBox.Text))
            {
                MessageBox.Show("Công ty chủ quản không được rỗng!");
                companyTxtBox.Focus();
                return;
            }
            bool response;
            if (_actionType == ActionType.CREATE)
            {
                var imgHandler = new ImageHandler();
                //Kiểm tra và thêm cover
                if (_imgList.Count <= 0)
                {
                    MessageBox.Show("Vui lòng thêm hình ảnh nhóm!");
                    return;
                }
                List<byte[]> byteImgList = new List<byte[]>();
                foreach (Image img in _imgList)
                {
                    byteImgList.Add(imgHandler.ImageToByteArray(img));
                }

                //Tạo request
                var request = new BandCreateRequest()
                {
                    AppleMusic = appleMusicTxtBox.Text,
                    ChiTiet = detailTxtBox.Text,
                    CongTy = companyTxtBox.Text,
                    DebutDate = debuteDateBox.Value,
                    Spotify = spotifyTxtBox.Text,
                    TenNhom = nameTxtBox.Text,
                    Youtube = youtubeTxtBox.Text,
                    Logo= imgHandler.ImageToByteArray(logoImgBox.Image),
                    ImageList= byteImgList
                };
                response = _bandApiClient.Create(request);
            }
            else
            {
                var request = new BandUpdateRequest()
                {
                    AppleMusic = appleMusicTxtBox.Text,
                    ChiTiet = detailTxtBox.Text,
                    CongTy = companyTxtBox.Text,
                    DebutDate = debuteDateBox.Value,
                    Spotify = spotifyTxtBox.Text,
                    TenNhom = nameTxtBox.Text,
                    Youtube = youtubeTxtBox.Text
                };
                response = _bandApiClient.Update(request);
            }
            
            if (response)
            {
                MessageBox.Show("Thành công!");
                Read();
            }
            else
                MessageBox.Show("Thất bại!");
        }

        private bool checkNull(object value)
        {
            if (value == null || value == DBNull.Value || String.IsNullOrWhiteSpace(value.ToString())) return true;
            return false;
        }

        private void editLogoBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPG|*.jpg|PNG|*.png|JPEG|*.jpeg|All files|*.*";
            DialogResult dialogResult = openFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                string file = openFileDialog.FileName;
                logoImgBox.Image = Image.FromFile(file);
                if (_actionType != ActionType.CREATE)
                {
                    var imgHandler = new ImageHandler();
                    _bandApiClient.UpdateLogo(imgHandler.ImageToByteArray(logoImgBox.Image));
                }
                
            }
        }

        private void editImgBtn_Click(object sender, EventArgs e)
        {
            var imagesForm = new ImagesForm();
            if (_actionType == ActionType.CREATE)
            {
                imagesForm.SenderInfo(ImageType.IMG_BAND);
                imagesForm.SenderImgList(_imgList);
                imagesForm.ShowDialog();
                if (imagesForm._images.Count > 0)
                {
                    if (_imgList == null) _imgList = new List<Image>();
                    _imgList.Clear();
                    foreach (var x in imagesForm._images)
                    {
                        _imgList.Add(x.Anh);
                    }
                    imgBox.Image = _imgList[0];
                }
                    
            }
            else
            {
                imagesForm.SenderInfo(ImageType.IMG_BAND, 0);
                imagesForm.ShowDialog();
                imgBox.Image = imagesForm._images[0].Anh;
            }
            
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Thoát và không lưu?",
                      "Chưa lưu thay đổi",
                       MessageBoxButtons.YesNo) == DialogResult.Yes) Read();
        }

        private void rightInfoPnl_Paint(object sender, PaintEventArgs e)
        {
            saveBtn.Show();
            exitBtn.Show();
        }
    }
}
