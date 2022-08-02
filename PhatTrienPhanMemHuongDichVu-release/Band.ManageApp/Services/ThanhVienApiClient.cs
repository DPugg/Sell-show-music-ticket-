using Band.ViewModels.Catalog.ThanhVien;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;
using System.Collections.Specialized;
using Band.ViewModels.Catalog.VaiTro;
using System.Drawing;
using Band.ViewModels.Utilities;
using Band.ViewModels.Catalog.Anh;
using System.IO;
using System.Windows.Forms;

namespace Band.ManageApp.Services
{
    public class ThanhVienApiClient : IThanhVienApiClient
    {
        private string uri = "https://localhost:44315/api/thanhvien/";
        public bool AddingImages(HinhAnhThanhVienRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            WebClient client = new WebClient();
/*            Uri uri = new Uri("https://localhost:44315/api/thanhvien/adding-avatars");
*/            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            var response = client.UploadString(uri+ "adding-images", "POST", json);
            if (response=="true") return true;
            return false;
        }

        public bool CreateThanhVien(ThanhVienCreateRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            /*var httpContent = new StringContent(json, Encoding.UTF8, "application/json");*/
            WebClient client = new WebClient();
            /*var client = _httpClientFactory.CreateClient();*/
            /*client.BaseAddress = "https://localhost:44315";*/
/*            Uri uri = new Uri("https://localhost:44315/api/thanhvien/");
*/            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            var response = "";
            try
            {
                response = client.UploadString(uri, "POST", json);

            }
            catch (WebException e)
            {
                string pageContent = new StreamReader(e.Response.GetResponseStream()).ReadToEnd().ToString();
                MessageBox.Show(pageContent);
            }
            if (response == "true") return true;
            return false;
        }

        public bool Delete(int idThanhVien)
        {
            WebClient client = new WebClient();
            client.QueryString.Add("idThanhVien", idThanhVien.ToString());
            /*            Uri uri = new Uri("https://localhost:44315/api/thanhvien/");
            *//*            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            */
            var response = client.UploadString(uri, "DELETE", "");
            if (response == "true") return true;
            return false;
        }

        public List<ByteArrayImageObject> GetAllCoverById(int idThanhVien)
        {
            WebClient client = new WebClient();
            client.QueryString.Add("IdThanhVien", idThanhVien.ToString());
            var response = client.DownloadString(uri + "covers-thanh-vien");
            List<ByteArrayImageObject> byeImageList = JsonConvert.DeserializeObject<List<ByteArrayImageObject>>(response);
            return byeImageList;
        }

        public bool DeleteImages(List<int> request)
        {
            var json = JsonConvert.SerializeObject(request);
            WebClient client = new WebClient();
/*            Uri uri = new Uri("https://localhost:44315/api/thanhvien/delete-images");
*/            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            var response = client.UploadString(uri+ "delete-images", "DELETE", json);
            if (response == "true") return true;
            return false;
        }

        public List<ThanhVienGetAllViewModel> GetAll()
        {
            WebClient client = new WebClient();
            var response = client.DownloadString(uri+"all");
            List<ThanhVienGetAllViewModel> result = JsonConvert.DeserializeObject<List<ThanhVienGetAllViewModel>>(response);
            return result;
        }

        public List<ByteArrayImageObject> GetAllAvatarById(int idThanhVien)
        {
            WebClient client = new WebClient();
/*            Uri uri = new Uri("https://localhost:44315/api/thanhvien/avatar-thanh-vien/");
*/            client.QueryString.Add("IdThanhVien", idThanhVien.ToString());
            var response = client.DownloadString(uri+ "avatar-thanh-vien");
            List<ByteArrayImageObject> byeImageList = JsonConvert.DeserializeObject<List<ByteArrayImageObject>>(response);
            return byeImageList;
        }

        public List<VaiTroViewModel> GetAllVaiTro()
        {
            WebClient client = new WebClient();
            Uri uri = new Uri("https://localhost:44315/api/vaitro/");
            var response = client.DownloadString(uri);
            List<VaiTroViewModel> result = JsonConvert.DeserializeObject<List<VaiTroViewModel>>(response);
            return result;
        }

        public ThanhVienViewModel GetById(int idThanhVien)
        {
            WebClient client = new WebClient();
/*            Uri uri = new Uri("https://localhost:44315/api/thanhvien/idthanhvien");
*/            client.QueryString.Add("IdThanhVien", idThanhVien.ToString());
            var response = client.DownloadString(uri+ "idthanhvien");
            ThanhVienViewModel result = JsonConvert.DeserializeObject<ThanhVienViewModel>(response);
            return result;
        }

        public bool UpdateThanhVien(ThanhVienUpdateRequestWithoutVaiTro request)
        {
            var json = JsonConvert.SerializeObject(request);
            /*var httpContent = new StringContent(json, Encoding.UTF8, "application/json");*/
            WebClient client = new WebClient();
            /*var client = _httpClientFactory.CreateClient();*/
            /*client.BaseAddress = "https://localhost:44315";*/
/*            Uri uri = new Uri("https://localhost:44315/api/thanhvien/");
*/            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            var response = client.UploadString(uri, "PUT", json);
            if (response == "true") return true;
            return false;
        }

        public bool UpdatePosition(ThanhVienUpdatePositionRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            var response = client.UploadString(uri+ "update-position", "POST", json);
            if (response == "true") return true;
            return false;
        }
    }
}
