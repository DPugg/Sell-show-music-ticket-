using Band.ManageApp.Services;
using Band.ViewModels.Catalog.Show;
using Band.ViewModels.Catalog.ThanhVien;
using Band.ViewModels.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static Band.ViewModels.Utilities.SystemConstants;

namespace Band.ManageApp
{
    public partial class ImagesForm : Form
    {
        private ImageHandler _imageHandler;
        public NewListOfImageObject _images;
        private int _idObject;
        private ImageType _imgType;
        private int numOfImages;
        private ThanhVienApiClient _thanhVienApiClient;
        private ShowApiClient _showApiClient;
        private BandApiClient _bandApiClient;
        public delegate void SendImgList(List<Image> imgList);
        public delegate void SendInfo(ImageType imgeType, int id=-1);
        public SendImgList SenderImgList;
        public SendInfo SenderInfo;
        public ImagesForm()
        {
            InitializeComponent();
            _imageHandler = new ImageHandler();
            _images = new NewListOfImageObject();
            /*Sender = new SendImgList(GetImgList);*/
            SenderInfo = new SendInfo(GetInfo);
            SenderImgList = new SendImgList(GetImgList);
            _images.Change += delegate (object sender, EventArgs arg)
            {
                if (_images.Count >= 0) loadImages();
            };

            imgsContainer.VerticalScroll.Enabled = false;
            imgsContainer.VerticalScroll.Visible = false;
            imgsContainer.VerticalScroll.Maximum = 0;
            imgsContainer.AutoScroll = true;
        }
        private void GetImgList(List<Image> imgList)
        {
            foreach (var x in imgList)
            {
                _images.Add(new ImageObject(x));
            }
        }
        private void GetInfo(ImageType imageType,int id= -1)
        {
            _idObject = id;
            _imgType = imageType;

            if (imageType == ImageType.IMG_BAND)
            {
                _bandApiClient = new BandApiClient();
                foreach (var x in _bandApiClient.GetAllImg())
                {
                    _images.Add(new ImageObject(x));
                }
            }
            else if (imageType == ImageType.IMG_SHOW)
            {
                _showApiClient = new ShowApiClient();
                foreach (var x in _showApiClient.GetAllImgById(id))
                {
                    _images.Add(new ImageObject(x));
                }
            }
            else
            {
                _thanhVienApiClient = new ThanhVienApiClient();
                if (_imgType == ImageType.AVATAR_MEM)
                    foreach (var x in _thanhVienApiClient.GetAllAvatarById(id))
                    {
                        _images.Add(new ImageObject(x));
                    }
                else if (imageType == ImageType.COVER_MEM)
                    foreach (var x in _thanhVienApiClient.GetAllCoverById(id))
                    {
                        _images.Add(new ImageObject(x));
                    }
            }
            
            

            /*            _images.AddRange(_thanhVienApiClient.GetAllImgeById(id));
            */
        }
        private void addImgsBtn_Click(object sender, EventArgs e)
        {
            if (deleteBtn.Visible == true)
            {
                MessageBox.Show("Chưa lưu thay đổi!");
                return;
            }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "JPG|*.jpg|PNG|*.png|JPEG|*.jpeg|All files|*.*";
            DialogResult dialogResult = openFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                numOfImages = _images.Count;
                saveBtn.Visible = true;
                string[] files = openFileDialog.FileNames;
                foreach (string img in files)
                {
                    FlowLayoutPanel pnl = new FlowLayoutPanel();
                    pnl.Size = new Size(100, 150);
                    CheckBox checkBox = new CheckBox();
                    _images.Add(new ImageObject(Image.FromFile(img)));
                }
            }
            else saveBtn.Visible = false;
        }

        private void addImgsBtn_MouseHover(object sender, EventArgs e)
        {
            addImgsBtn.BackColor = Color.FromArgb(125, Color.Black);
        }

        private void addImgsBtn_MouseLeave(object sender, EventArgs e)
        {
            addImgsBtn.BackColor = Color.FromArgb(0, Color.Black);
        }

        private void removeImgsBtn_Click(object sender, EventArgs e)
        {
            if (saveBtn.Visible == true)
            {
                MessageBox.Show("Chưa lưu thay đổi!");
                return;
            }
            foreach (Control p in imgsContainer.Controls)
                if (p is Panel)
                    foreach (Control c in p.Controls)
                        if (c is CheckBox)
                            c.Visible=true;
            selectAllCheckBox.Visible = false;
            deleteBtn.Visible = true;
        }
        private void loadImages()
        {
            imgsContainer.Controls.Clear();
            foreach (var imgObj in _images)
            {
                Panel pnl = new Panel();
                pnl.Margin = Padding.Empty;
                pnl.Size = new Size((imgsContainer.Width) / 3, (imgsContainer.Width) / 3);
                pnl.Padding = new Padding(3, 3, 3, 15);
                CheckBox checkBox = new CheckBox();
                checkBox.Dock = DockStyle.Top;
                checkBox.CheckAlign = ContentAlignment.MiddleCenter;
                checkBox.Visible = false;
                PictureBox pic = new PictureBox();
                pic.Dock = DockStyle.Fill;
                pic.Image = imgObj.Anh;
                pic.SizeMode = PictureBoxSizeMode.Zoom;
                pnl.Controls.AddRange(new Control[] { pic, checkBox });
                imgsContainer.Controls.Add(pnl);
            }
        }
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            List<byte[]> byteImgList = new List<byte[]>();
            for (int i =numOfImages; i < _images.Count; i++)
            {
                byteImgList.Add(_images[i].CovertToByteArray());
            }
            if (_idObject != -1 && _imgType == ImageType.IMG_BAND)
            {
                if (_bandApiClient.AddingImages(byteImgList))
                {
                    MessageBox.Show("Thành công!");
                    _images.Clear();
                    foreach (var x in _bandApiClient.GetAllImg())
                    {
                        _images.Add(new ImageObject(x));
                    }
                }
            }
            else if (_idObject!=-1 && _imgType!=ImageType.IMG_SHOW)
            {
                HinhAnhThanhVienRequest request;
                if (_imgType == ImageType.AVATAR_MEM)
                {
                    request = new HinhAnhThanhVienRequest()
                    {
                        DsAnh = byteImgList,
                        IdThanhVien = _idObject,
                        IdLoai= (int)ImageType.AVATAR_MEM
                    };
                }
                else
                {
                    request = new HinhAnhThanhVienRequest()
                    {
                        DsAnh = byteImgList,
                        IdThanhVien = _idObject,
                        IdLoai = (int)ImageType.COVER_MEM
                    };
                }
                if (_thanhVienApiClient.AddingImages(request))
                {
                    MessageBox.Show("Thành công!");
                    _images.Clear();
                    if (_imgType == ImageType.AVATAR_MEM)
                    {
                        foreach (var x in _thanhVienApiClient.GetAllAvatarById(_idObject))
                        {
                            _images.Add(new ImageObject(x));
                        }
                    }
                    if (_imgType == ImageType.COVER_MEM)
                    {
                        foreach (var x in _thanhVienApiClient.GetAllCoverById(_idObject))
                        {
                            _images.Add(new ImageObject(x));
                        }
                    }
                } 
                    
                else MessageBox.Show("Thất bại!");
            }
            else if (_idObject != -1 && _imgType == ImageType.IMG_SHOW)
            {
                var request = new ImagesShowAddRequest()
                {
                    DsAnh = byteImgList,
                    IdShow = _idObject,
                    IdLoai = (int)ImageType.IMG_SHOW
                };
                if (_showApiClient.AddingImages(request))
                {
                    MessageBox.Show("Thành công!");
                    _images.Clear();

                    foreach (var x in _showApiClient.GetAllImgById(_idObject))
                    {
                        _images.Add(new ImageObject(x));
                    }
                }
                    
                else MessageBox.Show("Thất bại!");
            }
            saveBtn.Visible = false;
        }

        private void ImagesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_images.Count == 0 && _idObject!=-1)
            {
                MessageBox.Show("Hình ảnh không được trống!");
                e.Cancel = true;
            }
            if (saveBtn.Visible)
            {
                if (MessageBox.Show("Thoát và không lưu?",
                       "Chưa lưu thay đổi",
                        MessageBoxButtons.YesNo) == DialogResult.No)    e.Cancel = true;
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            int i = 0;
            var listId = new List<int>();
            var listimg = new List<int>();

            foreach (var p in imgsContainer.Controls.OfType<Panel>())
            {
                if (((CheckBox)p.Controls.OfType<CheckBox>().FirstOrDefault()).Checked)
                {
                    var img = ((PictureBox)p.Controls.OfType<PictureBox>().FirstOrDefault());
                    if (_idObject != -1)
                        listId.Add(_images[i].IdAnh.Value);
                    listimg.Add(i); 
                }
                i++;
            }
            if(listimg.Count == 0)
            {
                MessageBox.Show("Chưa chọn hình để xóa");
                return;
            }
            if (_idObject != -1 && _imgType == ImageType.IMG_BAND)
            {
                if (_bandApiClient == null)
                    _bandApiClient = new BandApiClient();
                _bandApiClient.DeleteImages(listId);
            }
            else if (_idObject!=-1 && _imgType!=ImageType.IMG_SHOW)
            {
                if (_thanhVienApiClient == null)
                    _thanhVienApiClient = new ThanhVienApiClient();
                _thanhVienApiClient.DeleteImages(listId);
            }
            else if (_idObject != -1 && _imgType == ImageType.IMG_SHOW)
            {
                if (_showApiClient == null)
                    _showApiClient = new ShowApiClient();
                _showApiClient.DeleteImages(listId);
            }
            _images.RemoveRange(listimg[0], listimg.Count);

            
            deleteBtn.Visible = false;
            selectAllCheckBox.Visible = false;
        }

        private void selectAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
