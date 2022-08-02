using Band.ViewModels.Catalog.LoaiVe;
using Band.ViewModels.Catalog.Show;
using Band.ViewModels.Common;
using Band.ViewModels.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Band.ManageApp.Services
{
    class ShowApiClient : IShowApiClient
    {
        private readonly string uri = "https://localhost:44315/api/show/";

        public bool AddingImages(ImagesShowAddRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            var response = client.UploadString(uri + "adding-images", "POST", json);
            if (response == "true") return true;
            return false;
        }

        public bool Create(ShowCreateRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            var response = client.UploadString(uri, "POST", json);
            if (response == "true") return true;
            return false;
        }

        public List<ShowGetAllViewModel> GetAll()
        {
            WebClient client = new WebClient();
            var response = client.DownloadString(uri + "all");
            List<ShowGetAllViewModel> result = JsonConvert.DeserializeObject<List<ShowGetAllViewModel>>(response);
            return result;
        }

        public List<ByteArrayImageObject> GetAllImgById(int idShow)
        {
            WebClient client = new WebClient();
            client.QueryString.Add("idShow", idShow.ToString());
            var response = client.DownloadString(uri + "all-img");
            List<ByteArrayImageObject> byeImageList = JsonConvert.DeserializeObject<List<ByteArrayImageObject>>(response);
            return byeImageList;
        }

        public List<LoaiVeViewModel> GetAllLoaiVe()
        {
            WebClient client = new WebClient();
            var response = client.DownloadString(uri + "loai-ve");
            List<LoaiVeViewModel> result = JsonConvert.DeserializeObject<List<LoaiVeViewModel>>(response);
            return result;
        }

        public ShowViewModel GetById(int idShow)
        {
            WebClient client = new WebClient();
            client.QueryString.Add("idShow", idShow.ToString());
            var response = client.DownloadString(uri + "byid");
            ShowViewModel result = JsonConvert.DeserializeObject<ShowViewModel>(response);
            return result;
        }

        public bool UpdateShowInfor(ShowInfoUpdateRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            var response = client.UploadString(uri+"show-info", "PUT", json);
            if (response == "true") return true;
            return false;
        }

        public bool UpdateTicketInfor(TicketInfoUpdateRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            string response = "";
            try
            {
                response = client.UploadString(uri + "ticket-info", "PUT", json);
            }
            catch (WebException e)
            {
                response = "true";
            }
            if (response == "true") return true;
            return false;
        }

        public bool Delete(int idShow)
        {
            WebClient client = new WebClient();
            client.QueryString.Add("idShow", idShow.ToString());
            var response = client.UploadString(uri, "DELETE", "");
            if (response == "true") return true;
            return false;
        }
        public bool DeleteImages(List<int> request)
        {
            var json = JsonConvert.SerializeObject(request);
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            var response = client.UploadString(uri + "delete-images", "DELETE", json);
            if (response == "true") return true;
            return false;
        }

        public PageResult<ShowStatiscalViewModel> GetStatiscalPagingAsync(StatiscalRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            var response = "";
            try
            {
                response = client.UploadString(uri + "statiscal-paging", "POST", json);
            }
            catch (WebException e)
            {
                string pageContent = new StreamReader(e.Response.GetResponseStream()).ReadToEnd().ToString();
                MessageBox.Show(pageContent);
            }
            PageResult<ShowStatiscalViewModel> result = JsonConvert.DeserializeObject<PageResult<ShowStatiscalViewModel>>(response);
            return result;
        }
    }
}
