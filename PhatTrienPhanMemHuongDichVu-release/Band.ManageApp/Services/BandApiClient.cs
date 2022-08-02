using Band.ViewModels.Catalog.Band;
using Band.ViewModels.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Band.ManageApp.Services
{
    public class BandApiClient
    {
        private readonly string uri = "https://localhost:44315/api/band/";
        public bool Create(BandCreateRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            var response = client.UploadString(uri, "POST", json);
            if (response == "true") return true;
            return false;
        }
        public BandViewModel Get()
        {
            WebClient client = new WebClient();
            var response = client.DownloadString(uri);
            BandViewModel result = JsonConvert.DeserializeObject<BandViewModel>(response);
            return result;
        }
        public bool Update(BandUpdateRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            var response = "";
            try
            {
                response = client.UploadString(uri, "PUT", json);
            }
            
            catch (WebException e)
            {
                string pageContent = new StreamReader(e.Response.GetResponseStream()).ReadToEnd().ToString();
                MessageBox.Show(pageContent);
            }
            if (response == "true") return true;
            return false;
        }
        public bool UpdateLogo(byte[] request)
        {
            var json = JsonConvert.SerializeObject(request);
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            var response = client.UploadString(uri+ "update-image", "PUT", json);
            if (response == "true") return true;
            return false;
        }
        public NewListOfByteArrayImage GetAllImg()
        {
            WebClient client = new WebClient();
            var response = client.DownloadString(uri+"img");
            NewListOfByteArrayImage result = JsonConvert.DeserializeObject<NewListOfByteArrayImage>(response);
            return result;
        }

        public bool AddingImages(List<byte[]> dsAnh)
        {
            var json = JsonConvert.SerializeObject(dsAnh);
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            var response = client.UploadString(uri + "adding-images", "POST", json);
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
    }
}
