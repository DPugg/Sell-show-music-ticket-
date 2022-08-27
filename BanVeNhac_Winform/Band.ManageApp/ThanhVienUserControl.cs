using Band.Data.Entities;
using Band.ManageApp.Services;
using Band.ViewModels.Catalog.ThanhVien;
using Band.ViewModels.Catalog.VaiTro;
using Band.ViewModels.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using static Band.ViewModels.Utilities.SystemConstants;

namespace Band.ManageApp
{
    public partial class ThanhVienUserControl : UserControl
    {
        private ImageHandler imageHandler;
        public ThanhVienViewModel thanhVien;
        private ThanhVienApiClient _thanhVienApiClient;
        public static ThanhVienUserControl _instance;
        private List<Image> _avatarList;
        private List<VaiTroViewModel> _vaiTroList;
        private List<Image> _coverList;
        private Image _avatar;
        private Image _cover;
        public event EventHandler AvatarChanged;
        public event EventHandler CoverChanged;
        public static ActionType _actionType;

        public static List<ThanhVienViewModel> dsThanhVien { set; get; }
        protected virtual void OnAvatarChanged()
        {
            if (AvatarChanged != null) AvatarChanged(this, EventArgs.Empty);
        }
        protected virtual void OnCoverChanged()
        {
            if (CoverChanged != null) CoverChanged(this, EventArgs.Empty);
        }
        public Image avatar
        {
            get
            {
                return _avatar;
            }

            set
            {
                //#3
                _avatar = value;
                OnAvatarChanged();
            }
        }
        public Image cover
        {
            get
            {
                return _cover;
            }

            set
            {
                //#3
                _cover = value;
                OnCoverChanged();
            }
        }

        public static ThanhVienUserControl Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ThanhVienUserControl();
                }
                return _instance;
            }
        }
        public ThanhVienUserControl()
        {
            InitializeComponent();
            imageHandler = new ImageHandler();
            _actionType = ActionType.READ;
            dsThanhVien = new List<ThanhVienViewModel>();

            /*images = new NewListOfImage();
            images.Change += delegate (object sender, EventArgs arg)
            {
                if (images.Count() > 0) avatarImgBox.Image = images.First();
            };*/
            AvatarChanged += delegate (object sender, EventArgs arg)
            {
                avatarImgBox.Image = avatar;
            };
            CoverChanged += delegate (object sender, EventArgs arg)
            {
                coverImgBox.SizeMode = PictureBoxSizeMode.StretchImage;
                coverImgBox.Image = cover;
            };
            Read();
            var tmp = (ThanhVienGetAllViewModel)thanhVienCombobox.SelectedValue;
            if (tmp == null)
            {
                MessageBox.Show("Danh sách thành viên rỗng! Vui lòng thêm thành viên mới!");
                Create();
            }
            /*loadDsVaiTro();*/
            /*            bindingData();
            */            /*saveBtn.Visible = false;*/
            /*editAvatarBtn.Image= SetImageOpacity(editAvatarBtn.Image, 0.2f);
            editCoverImgBtn.Image = SetImageOpacity(editCoverImgBtn.Image, 0.2f);
            editVaiTroBtn.Image = SetImageOpacity(editVaiTroBtn.Image, 0.2f);*/

            avatarImgBox.Controls.Add(editAvatarBtn);
            editAvatarBtn.Location = new Point(avatarImgBox.Width - editAvatarBtn.Width - 5, avatarImgBox.Height - editAvatarBtn.Height - 5);
            editAvatarBtn.BackColor = Color.FromArgb(125, Color.White);

            coverImgBox.Controls.Add(editCoverImgBtn);
            editCoverImgBtn.Location = new Point(coverImgBox.Width - editCoverImgBtn.Width - 10, coverImgBox.Height - editCoverImgBtn.Height - 10);
            editCoverImgBtn.BackColor = Color.FromArgb(125, Color.White);
            txtHoatDong.Enabled = false;

        }

        private void Read()
        {
            loadDsThanhVien();
            thanhVienCombobox.Enabled = true;
            addVaiTroBtn.Hide();
            editVaiTroBtn.Show();
            saveBtn.Hide();
            exitBtn.Hide();
            dsVaiTroLbl.Show();
        }

        private void Create()
        {
            _avatarList = new NewListOfImage();
            _coverList = new NewListOfImage();
            var resourcePath=Path.Combine(Application.StartupPath, @"..\Resources\");
            /*MessageBox.Show(Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\Resources\user.png")));*/
         //   avatarImgBox.Image = new Bitmap(Path.GetFullPath(resourcePath+"user.png"));
         //   coverImgBox.Image = new Bitmap(Path.GetFullPath(resourcePath + "image.png"));
            avatarImgBox.Image = new Bitmap(@"C:\Users\maima\OneDrive\Documents\ThucTap\Sell-show-music-ticket-\BanVeNhac_Winform\Band.ManageApp\Resources\user.png");
            coverImgBox.Image = new Bitmap(@"C:\Users\maima\OneDrive\Documents\ThucTap\Sell-show-music-ticket-\BanVeNhac_Winform\Band.ManageApp\Resources\image.png");
            coverImgBox.SizeMode = PictureBoxSizeMode.Zoom;
            nameTxtBox.Text = "";
            nationTxtBox.Text = "";
            stageNameTxtBox.Text = "";
            instaTxtBox.Text = "";
            twitterTxtBox.Text = "";
            storyTxtBox.Text = "";
            dsVaiTroLbl.Visible = false;

            /*thanhVienCombobox.DataSource*/
            if (thanhVienCombobox.FindStringExact("--Đang thêm--")==-1)
            {
                thanhVienCombobox.SelectedItem = null;
                thanhVienCombobox.SelectedText = "--Đang thêm--";
            }
            
            thanhVienCombobox.Enabled = false;
            vaiTroListBox.Show();
            loadDsVaiTro();
            saveBtn.Visible = true;
            exitBtn.Visible = true;
            editVaiTroBtn.Hide();
            addVaiTroBtn.Show();
            _actionType = ActionType.CREATE;
        }

        private void addMemberBtn_Click(object sender, EventArgs e)
        {
                
            Create();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            _thanhVienApiClient = new ThanhVienApiClient();
            if (_actionType == ActionType.UPDATE_POSITION)
            {
                
                //Kiểm tra và thêm vai trò
                if (vaiTroListBox.CheckedItems == null || vaiTroListBox.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Vui lòng thêm vai trò thành viên!");
                    return;
                }

                List<int> dsIdVaiTro = new List<int>();
                int index = 0;
                var dsVaiTroMoi = new List<string>();

                foreach (VaiTroViewModel x in vaiTroListBox.CheckedItems)
                {
                    if (!_vaiTroList.Contains(x))
                        dsVaiTroMoi.Add(x.TenVaiTro);
                    else
                        dsIdVaiTro.Add(x.IdVaiTro);
                    index++;
                }

                //Tạo request
                ThanhVienGetAllViewModel tmp = thanhVienCombobox.SelectedValue as ThanhVienGetAllViewModel;
                var request = new ThanhVienUpdatePositionRequest()
                {
                    IdThanhVien = tmp.IdThanhVien,
                    DsIdVaiTro = dsIdVaiTro,
                    DsVaiTroMoi = dsVaiTroMoi
                };
                var response = _thanhVienApiClient.UpdatePosition(request);
                if (response)
                {
                    MessageBox.Show("Thành công!");
                    Read();
                    thanhVienCombobox.SelectedIndex = thanhVienCombobox.FindStringExact(tmp.NgheDanh);
                }
                else
                    MessageBox.Show("Thất bại!");

            }
            else if (_actionType == ActionType.UPDATE)
            {
                editVaiTroBtn.Hide();
                //Kiểm tra thông tin và thêm thông tin thành viên
                if (checkNull(nameTxtBox.Text))
                {
                    MessageBox.Show("Họ và tên không được rỗng!");
                    nameTxtBox.Focus();
                    return;
                }
                else if (checkNull(nationTxtBox.Text))
                {
                    MessageBox.Show("Quốc tịch không được rỗng!");
                    nationTxtBox.Focus();
                    return;
                }
                else if (checkNull(stageNameTxtBox.Text))
                {
                    MessageBox.Show("Nghệ danh không được rỗng!");
                    stageNameTxtBox.Focus();
                    return;
                }
                ThanhVienGetAllViewModel tmp = thanhVienCombobox.SelectedValue as ThanhVienGetAllViewModel;
                var request = new ThanhVienUpdateRequestWithoutVaiTro()
                {
                    IdThanhVien = tmp.IdThanhVien,
                    DebutDate=debuteDateBox.Value,
                    Instagram=instaTxtBox.Text,
                    NgaySinh=dobBox.Value,
                    NgheDanh=stageNameTxtBox.Text,
                    QuocTich=nationTxtBox.Text,
                    TenKhaiSinh=nameTxtBox.Text,
                    TieuSu=storyTxtBox.Text,
                    Twitter=twitterTxtBox.Text
                };
                var response = _thanhVienApiClient.UpdateThanhVien(request);
                if (response)
                {
                    MessageBox.Show("Thành công!");
                    Read();
                    thanhVienCombobox.SelectedIndex = thanhVienCombobox.FindStringExact(request.NgheDanh);
/*                    _ = _thanhVienApiClient.GetById(tmp.IdThanhVien);
*/              }
                else
                    MessageBox.Show("Thất bại!");
            }
            else if(_actionType == ActionType.CREATE)
            {
                //Kiểm tra và thêm avatar
                if (_avatarList.Count <= 0)
                {
                    MessageBox.Show("Vui lòng thêm hình ảnh thành viên!");
                    return;
                }
                List<byte[]> byteAvatarList = new List<byte[]>();
                foreach (Image img in _avatarList)
                {
                    byteAvatarList.Add(imageHandler.ImageToByteArray(img));
                }

                //Kiểm tra và thêm cover
                if (_coverList.Count <= 0)
                {
                    MessageBox.Show("Vui lòng thêm hình ảnh thành viên!");
                    return;
                }
                List<byte[]> byteCoverList = new List<byte[]>();
                foreach (Image img in _coverList)
                {
                    byteCoverList.Add(imageHandler.ImageToByteArray(img));
                }

                //Kiểm tra thông tin và thêm thông tin thành viên
                if (checkNull(nameTxtBox.Text))
                {
                    MessageBox.Show("Họ và tên không được rỗng!");
                    nameTxtBox.Focus();
                    return;
                }
                else if (checkNull(nationTxtBox.Text))
                {
                    MessageBox.Show("Quốc tịch không được rỗng!");
                    nationTxtBox.Focus();
                    return;
                }
                else if (checkNull(stageNameTxtBox.Text))
                {
                    MessageBox.Show("Nghệ danh không được rỗng!");
                    stageNameTxtBox.Focus();
                    return;
                }


                //Kiểm tra và thêm vai trò
                if (vaiTroListBox.CheckedItems == null || vaiTroListBox.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Vui lòng thêm vai trò thành viên!");
                    return;
                }

                List<int> dsIdVaiTro = new List<int>();
                int index = 0;
                var dsTenVaiTro = new List<String>();
                foreach (var x in _vaiTroList)
                {
                    dsTenVaiTro.Add(x.TenVaiTro);
                }
                var dsVaiTroMoi = new List<string>();
                if (_vaiTroList.Count > 0)
                {
                    foreach (VaiTroViewModel x in vaiTroListBox.CheckedItems)
                    {
                        if (!dsTenVaiTro.Contains(x.TenVaiTro))
                            dsVaiTroMoi.Add(x.TenVaiTro);
                        else
                            dsIdVaiTro.Add(x.IdVaiTro);
                        index++;
                    }
                }
                else
                    foreach (VaiTroViewModel x in vaiTroListBox.CheckedItems)
                    {
                        dsVaiTroMoi.Add(x.TenVaiTro);
                    }

                //Tạo request
                var request = new ThanhVienCreateRequest()
                {
                    TenKhaiSinh = nameTxtBox.Text,
                    NgaySinh = dobBox.Value,
                    QuocTich = nationTxtBox.Text,
                    NgheDanh = stageNameTxtBox.Text,
                    DebutDate = debuteDateBox.Value,
                    Instagram = instaTxtBox.Text,
                    Twitter = twitterTxtBox.Text,
                    TieuSu = storyTxtBox.Text,
                    TrangThai = "Hoạt động",
                    DsAvatar = byteAvatarList,
                    DsCover = byteCoverList,
                    DsIdVaiTro = dsIdVaiTro,
                    DsVaiTroMoi=dsVaiTroMoi
                };

                if (_thanhVienApiClient.CreateThanhVien(request))
                {
                    MessageBox.Show("Thành công!");
                    Read();
                }
                else MessageBox.Show("Thất bại!");
            }
        }
        public static Image SetImageOpacity(Image image, float opacity)
        {
            Image tmpImage = image;
            try
            {
                //create a Bitmap the size of the image provided  
                Bitmap bmp = new Bitmap(tmpImage.Width, tmpImage.Height);

                //create a graphics object from the image  
                using (Graphics gfx = Graphics.FromImage(bmp))
                {

                    //create a color matrix object  
                    ColorMatrix matrix = new ColorMatrix();

                    //set the opacity  
                    matrix.Matrix33 = opacity;

                    //create image attributes  
                    ImageAttributes attributes = new ImageAttributes();

                    //set the color(opacity) of the image  
                    attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                    //now draw the image  
                    gfx.DrawImage(tmpImage, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, tmpImage.Width, tmpImage.Height, GraphicsUnit.Pixel, attributes);
                }
                return bmp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        private void editAvatarBtn_Click(object sender, EventArgs e)
        {
            var thanhVienGetAllVm = new ThanhVienGetAllViewModel();
            thanhVienGetAllVm = thanhVienCombobox.SelectedValue as ThanhVienGetAllViewModel;

            var imagesForm = new ImagesForm();
            if (_actionType != ActionType.CREATE)
                imagesForm.SenderInfo(ImageType.AVATAR_MEM, thanhVienGetAllVm.IdThanhVien);
            else
            {
                imagesForm.SenderInfo(ImageType.AVATAR_MEM);
                imagesForm.SenderImgList(_avatarList);
            }
                
            /*            imagesForm.ShowDialog();*/
            imagesForm.ShowDialog();
            if(imagesForm._images.Count>0)
                avatar = imagesForm._images.FirstOrDefault().Anh;
            if (_actionType == ActionType.CREATE && _avatarList != null)
            {
                _avatarList.Clear();
                foreach (var x in imagesForm._images)
                {
                    _avatarList.Add(x.Anh);
                }
            }    
                
            /*if (imagesForm.ShowDialog() == DialogResult.OK)
            {
                avatar = imagesForm._images.FirstOrDefault().Anh;
                if (_actionType == ActionType.CREATE && _avatarList != null)
                    _avatarList.Clear();
                foreach (var x in imagesForm._images)
                {
                    _avatarList.Add(x.Anh);
                }
            };*/

        /*imagesForm.Sender(images);*/
            
        /*            imagesForm.Parent = this;*/
        }

        private void editAvatarBtn_MouseLeave(object sender, EventArgs e)
        {
            editAvatarBtn.Visible = false;
        }
        private void loadDsThanhVien()
        {
            _thanhVienApiClient = new ThanhVienApiClient();
            thanhVienCombobox.DataSource = _thanhVienApiClient.GetAll();
            thanhVienCombobox.DisplayMember = "NgheDanh";
        }
        private void loadDsVaiTro()
        {
            if (_vaiTroList!=null && _vaiTroList.Count > 0) vaiTroListBox.Items.Clear();
            _vaiTroList = new List<VaiTroViewModel>();
            _vaiTroList = _thanhVienApiClient.GetAllVaiTro();
            foreach(var x in _vaiTroList)
            {
                vaiTroListBox.Items.Add(x);
            }
            vaiTroListBox.Visible = true;
        }
/*        void bindingData()
        {
            nameTxtBox.DataBindings.Add(new Binding("Text", thanhVienCombobox.DataSource, "TenKhaiSinh"));
            dobBox.DataBindings.Add(new Binding("Value", thanhVienCombobox.DataSource, "NgaySinh"));
            nationTxtBox.DataBindings.Add(new Binding("Text", thanhVienCombobox.DataSource, "QuocTich"));
            stageNameTxtBox.DataBindings.Add(new Binding("Text", thanhVienCombobox.DataSource, "NgheDanh"));
            debuteDateBox.DataBindings.Add(new Binding("Value", thanhVienCombobox.DataSource, "DebutDate"));
            instaTxtBox.DataBindings.Add(new Binding("Text", thanhVienCombobox.DataSource, "Instagram"));
            twitterTxtBox.DataBindings.Add(new Binding("Text", thanhVienCombobox.DataSource, "Twitter"));
            storyTxtBox.DataBindings.Add(new Binding("Text", thanhVienCombobox.DataSource, "Tieusu"));
        }*/

        private void thanhVienCombobox_SelectedValueChanged(object sender, EventArgs e)
        {
            /*if(_actionType==ActionType.UPDATE|| _actionType == ActionType.UPDATE_POSITION)
            {
                if (MessageBox.Show("Thoát và không lưu?",
                      "Chưa lưu thay đổi",
                       MessageBoxButtons.YesNo) == DialogResult.No) return;
            }*/
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedValue != null)
            {
                thanhVien = new ThanhVienViewModel();
                //Binding cho avatar
                ThanhVienGetAllViewModel tmp = cb.SelectedValue as ThanhVienGetAllViewModel;

                thanhVien = _thanhVienApiClient.GetById(tmp.IdThanhVien);
                

                /*images.Clear();
                foreach(var x in thanhVien.DsHinhAnh)
                {
                    var hinhAnh = imageConverter.ConvertFrom(x);
                    images.Add((Image)hinhAnh);
                }*/
                var byteAvatar = imageHandler._imageConverter.ConvertFrom(thanhVien.Avatar);
                avatar = (Image)byteAvatar;
                if (thanhVien.Cover != null)
                {
                    var byteCover = imageHandler._imageConverter.ConvertFrom(thanhVien.Cover);
                    cover = (Image)byteCover;
                }
                else cover = coverImgBox.ErrorImage;

                dsVaiTroLbl.Items.Clear();
                foreach (var x in thanhVien.DsVaiTro)
                {
                    dsVaiTroLbl.Items.Add(x.TenVaiTro);
                }

                //Binding
                nameTxtBox.Text = thanhVien.TenKhaiSinh;
                dobBox.Value = thanhVien.NgaySinh;
                nationTxtBox.Text = thanhVien.QuocTich;
                stageNameTxtBox.Text = thanhVien.NgheDanh;
                debuteDateBox.Value = thanhVien.DebutDate;
                instaTxtBox.Text = thanhVien.Instagram;
                twitterTxtBox.Text = thanhVien.Twitter;
                storyTxtBox.Text = thanhVien.TieuSu;
                txtHoatDong.Text = thanhVien.TrangThai;
            }
            _actionType = ActionType.READ;
        }

/*        private void addHandlers()
        {
            foreach (TextBox control in infoPnl.Controls.OfType<TextBox>())
            {
                control.TextChanged += new EventHandler(OnContentChanged);
            }
            foreach (ComboBox control in infoPnl.Controls.OfType<ComboBox>())
            {
                control.SelectedIndexChanged += new EventHandler(OnContentChanged);
            }
            foreach (DateTimePicker control in infoPnl.Controls.OfType<DateTimePicker>())
            {
                control.ValueChanged += new EventHandler(OnContentChanged);
            }
            dsVaiTroLbl.TextChanged += new EventHandler(OnContentChanged);
            storyTxtBox.TextChanged += new EventHandler(OnContentChanged);
        }
        protected void OnContentChanged(object sender, EventArgs e)
        {
            if (ContentChanged != null) saveBtn.Visible = true;
            
        }*/

        private void nameTxtBox_TextChanged(object sender, EventArgs e)
        {
            if (!nameTxtBox.Focused) return;
            if (!saveBtn.Visible) 
            {
                Updating();
            }
        }

        private void dobBox_ValueChanged(object sender, EventArgs e)
        {
            if (!dobBox.Focused) return;
            if (!saveBtn.Visible)
            {
                Updating();
            }
        }

        private void nationTxtBox_TextChanged(object sender, EventArgs e)
        {
            if (!nationTxtBox.Focused) return;
            if (!saveBtn.Visible)
            {
                Updating();
            }
        }

        private void stageNameTxtBox_TextChanged(object sender, EventArgs e)
        {
            if (!stageNameTxtBox.Focused) return;
            if (!saveBtn.Visible)
            {
                Updating();
            }
        }

        private void debuteDateBox_ValueChanged(object sender, EventArgs e)
        {
            if (!debuteDateBox.Focused) return;
            if (!saveBtn.Visible)
            {
                Updating();
            }
        }

        private void instaTxtBox_TextChanged(object sender, EventArgs e)
        {
            if (!instaTxtBox.Focused) return;
            if (!saveBtn.Visible)
            {
                Updating();
            }
        }

        private void Updating()
        {
            saveBtn.Visible = true;
            thanhVienCombobox.Enabled = false;
            _actionType = ActionType.UPDATE;
        }

        private void twitterTxtBox_TextChanged(object sender, EventArgs e)
        {
            if (!twitterTxtBox.Focused) return;
            if (!saveBtn.Visible)
            {
                Updating();
            }
        }

        private void storyTxtBox_TextChanged(object sender, EventArgs e)
        {
            if (!storyTxtBox.Focused) return;
            if (!saveBtn.Visible)
            {
                Updating();
            }
        }

        private void editVaiTroBtn_Click(object sender, EventArgs e)
        {
            editVaiTroBtn.Hide();
            addVaiTroBtn.Show();
            
            dsVaiTroLbl.Hide();
            vaiTroListBox.Show();
            saveBtn.Show();
            exitBtn.Show();
            loadDsVaiTro();
            var dsTenVaiTro = new List<string>();
            foreach(var x in thanhVien.DsVaiTro)
            {
                dsTenVaiTro.Add(x.TenVaiTro);
            }
            for (int i = 0; i < vaiTroListBox.Items.Count; i++)
            {
                if (dsTenVaiTro.Contains(vaiTroListBox.Items[i].ToString()))
                {
                    vaiTroListBox.SetItemChecked(i, true);
                }
            }
            _actionType = ActionType.UPDATE_POSITION;
        }

        private bool checkForCorrectnessThanhVien(ThanhVienCreateRequest thanhVien)
        {
            
            if (String.IsNullOrEmpty(stageNameTxtBox.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                stageNameTxtBox.Focus();
                return false;
            }

            foreach (Control c in leftInfoPnl.Controls)
            {
                if (c is TextBox)
                {
                    if (String.IsNullOrEmpty(c.Text))
                    {
                        MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                        c.Focus();
                        return false;
                    }
                }
            }
            return true;
            /*if (nameTxtBox.Text.Length == 0 || nationTxtBox.Text.Length == 0 
                || stageNameTxtBox.Text.Length == 0 || thanhVien.DsAnh == null 
                || thanhVien.DsIdVaiTro == null) return false;
            return true;*/
        }


        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (_actionType == ActionType.UPDATE || _actionType == ActionType.UPDATE_POSITION)
            {
                MessageBox.Show("Chưa lưu thay đổi!");
                return;
            }

            var thanhVienGetAllVm = new ThanhVienGetAllViewModel();
            thanhVienGetAllVm = thanhVienCombobox.SelectedValue as ThanhVienGetAllViewModel;

            ThanhVienGetAllViewModel tmp = thanhVienCombobox.SelectedValue as ThanhVienGetAllViewModel;
            var request = new ThanhVienUpdateRequestWithoutVaiTro()
            {
                IdThanhVien = tmp.IdThanhVien,
                DebutDate = debuteDateBox.Value,
                Instagram = instaTxtBox.Text,
                NgaySinh = dobBox.Value,
                NgheDanh = stageNameTxtBox.Text,
                QuocTich = nationTxtBox.Text,
                TenKhaiSinh = nameTxtBox.Text,
                TieuSu = storyTxtBox.Text,
                Twitter = twitterTxtBox.Text,
                TrangThai = "Ngưng hoạt động"
            };
            if (MessageBox.Show($"Xoá khỏi nhóm thành viên {thanhVienGetAllVm.NgheDanh}",
                       "Xoá thành viên",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //              _thanhVienApiClient.Delete(thanhVienGetAllVm.IdThanhVien);
                _thanhVienApiClient.UpdateThanhVien(request);
                loadDsThanhVien();
            }
        }

        private void editCoverImgBtn_Click(object sender, EventArgs e)
        {
            var thanhVienGetAllVm = new ThanhVienGetAllViewModel();
            thanhVienGetAllVm = thanhVienCombobox.SelectedValue as ThanhVienGetAllViewModel;
            ImagesForm imagesForm = new ImagesForm();
            /*imagesForm.Sender(images);*/
            if (_actionType != ActionType.CREATE)
                imagesForm.SenderInfo(ImageType.COVER_MEM, thanhVienGetAllVm.IdThanhVien);
            else
            {
                imagesForm.SenderInfo(ImageType.COVER_MEM);
                imagesForm.SenderImgList(_coverList);
            }    

            imagesForm.ShowDialog();
            if (imagesForm._images.Count > 0)
                cover = imagesForm._images.FirstOrDefault().Anh;
            if (_actionType == ActionType.CREATE && _coverList != null)
            {
                _coverList.Clear();
                foreach (var x in imagesForm._images)
                {
                    _coverList.Add(x.Anh);
                }
            }
                
            /*            imagesForm.ShowDialog();*/
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Thoát và không lưu?",
                      "Chưa lưu thay đổi",
                       MessageBoxButtons.YesNo) == DialogResult.Yes) Read();
        }

        private void addVaiTroBtn_Click(object sender, EventArgs e)
        {
            var vaiTro= Prompt.ShowDialog("Thêm vai trò mới", "Vai trò");
            while (vaiTroListBox.Items.Contains(vaiTro)) 
            {
                MessageBox.Show($"Vai trò {vaiTro} đã tồn tại");
                vaiTro = Prompt.ShowDialog("Thêm vai trò mới", "Vai trò");
            }
            if (vaiTro == null || vaiTro.Length == 0) return;
            else
            {
                vaiTroListBox.Items.Add(new VaiTroViewModel() {
                    TenVaiTro=vaiTro
                });
                vaiTroListBox.SetItemChecked(vaiTroListBox.FindStringExact(vaiTro), true);
            }
            
        }

        private bool checkNull(object value)
        {
            if (value == null || value == DBNull.Value || String.IsNullOrWhiteSpace(value.ToString())) return true;
            return false;
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void txtHoatDong_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
