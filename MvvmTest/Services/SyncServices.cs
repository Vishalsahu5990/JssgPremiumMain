using System;
using System.Threading.Tasks;
using DataAccessLayer.APIRepository;
using DataAccessLayer.Helper;
using DataAccessLayer.Models;
using PortableLibrary.Models;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using MvvmTest.Helpers;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace MvvmTest.Services
{
    public class SyncServices : ISyncServices 
    {
        static HttpClient client = new HttpClient();
        public SyncServices()
        {
            if (!Plugin.Connectivity.CrossConnectivity.Current.IsConnected)
            {
                CommonHelpers.ShowToast("Please check your connection or try again later!");
                return;
            }
        }
        public  List<LoginModel> ValidateUser(string userId, string password)
        {          
            CommonHelpers.ShowLoader();
            string url = URL.APIBaseAddress;
            HttpResponseMessage response = null;
            List<LoginModel> _loginModel = null;
            JObject j = new JObject();
            j.Add("method", URL.Login);
            j.Add("mobile", userId);
            j.Add("password", password);
            j.Add("deviceId", CommonHelpers.DeviceToken); 

           try
            {
                var json = JsonConvert.SerializeObject(j);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = client.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    using (StreamReader reader = new StreamReader(response.Content.ReadAsStreamAsync().Result))
                    {
                        var contents = reader.ReadToEnd();
                        JObject jObj = JObject.Parse(contents);

                        var status = jObj["status"].ToString();

                        if (status.Equals("200"))
                        {
                            _loginModel = jObj["result"].ToObject<List<LoginModel>>();

                        }

                    }

                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                CommonHelpers.DismissLoader();   
            }
           
            return _loginModel;
        }

        public List<CircularModel> GetCircular()
        {
            CommonHelpers.ShowLoader();
            string url = URL.APIBaseAddress;
            HttpResponseMessage response = null;
            List<CircularModel> _circularModel = null;
            JObject j = new JObject();
            j.Add("method", URL.Circular);

            try
            {
                var json = JsonConvert.SerializeObject(j);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = client.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    using (StreamReader reader = new StreamReader(response.Content.ReadAsStreamAsync().Result))
                    {
                        var contents = reader.ReadToEnd();
                        JObject jObj = JObject.Parse(contents);

                        var status = jObj["status"].ToString();

                        if (status.Equals("200"))
                        {
                            _circularModel = jObj["result"].ToObject<List<CircularModel>>();

                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                CommonHelpers.DismissLoader(); 
            }
           

            return _circularModel;
        }

        public List<BearersModel> GetBearers()
        {
            CommonHelpers.ShowLoader();
            string url = URL.APIBaseAddress;
            HttpResponseMessage response = null;
            List<BearersModel> _bearersModel = null;
            JObject j = new JObject();
            j.Add("method", URL.GetBearers);

            try
            {
                var json = JsonConvert.SerializeObject(j);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = client.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    using (StreamReader reader = new StreamReader(response.Content.ReadAsStreamAsync().Result))
                    {
                        var contents = reader.ReadToEnd();
                        JObject jObj = JObject.Parse(contents);

                        var status = jObj["status"].ToString();

                        if (status.Equals("200"))
                        {
                            _bearersModel = jObj["result"].ToObject<List<BearersModel>>();

                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                CommonHelpers.DismissLoader(); 
            }
           

            return _bearersModel;
        }

        public BearersModel GetBearerDetails(string bearerId)
        {
            CommonHelpers.ShowLoader();
            string url = URL.APIBaseAddress;
            HttpResponseMessage response = null;
            BearersModel _bearersModel = null;
            JObject j = new JObject();
            j.Add("method", URL.GetBearersDetails);
            j.Add("id",bearerId);

            try
            {
                var json = JsonConvert.SerializeObject(j);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = client.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    using (StreamReader reader = new StreamReader(response.Content.ReadAsStreamAsync().Result))
                    {
                        var contents = reader.ReadToEnd();
                        JObject jObj = JObject.Parse(contents);

                        var status = jObj["status"].ToString();

                        if (status.Equals("200"))
                        {
                            _bearersModel = jObj["result"].ToObject<BearersModel>();

                        }
                    }

                }
                CommonHelpers.DismissLoader();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                CommonHelpers.DismissLoader();
            }

            return _bearersModel;
        }

        public List<GroupIntroModel> GetGroupIntro()
        {
            CommonHelpers.ShowLoader();
            string url = URL.APIBaseAddress;
            HttpResponseMessage response = null;
            List<GroupIntroModel> _groupIntro = null;
            JObject j = new JObject();
            j.Add("method", URL.GroupIntro);

            try
            {
                var json = JsonConvert.SerializeObject(j);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = client.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    using (StreamReader reader = new StreamReader(response.Content.ReadAsStreamAsync().Result))
                    {
                        var contents = reader.ReadToEnd();
                        JObject jObj = JObject.Parse(contents);

                        var status = jObj["status"].ToString();

                        if (status.Equals("200"))
                        {
                            _groupIntro = jObj["result"].ToObject<List<GroupIntroModel>>();

                        }
                    }

                }
                CommonHelpers.DismissLoader();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                CommonHelpers.DismissLoader();
            }
           
            return _groupIntro;
        }

        public List<MemberModel> GetMembers()
        {
            CommonHelpers.ShowLoader();
            string url = URL.APIBaseAddress;
            HttpResponseMessage response = null;
            List<MemberModel>  _member = null;
            JObject j = new JObject();
            j.Add("method", URL.Getmembers); 

            try
            {
                var json = JsonConvert.SerializeObject(j);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = client.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    using (StreamReader reader = new StreamReader(response.Content.ReadAsStreamAsync().Result))
                    {
                        var contents = reader.ReadToEnd();
                        JObject jObj = JObject.Parse(contents);

                        var status = jObj["status"].ToString();

                        if (status.Equals("200"))
                        {
                            _member = jObj["result"].ToObject<List<MemberModel>>();

                        }
                    }

                }
                CommonHelpers.DismissLoader();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                CommonHelpers.DismissLoader();
            }

            return _member;
        }

        public List<TirthModel> GetjainTirth()
        {
            CommonHelpers.ShowLoader();
            string url = URL.APIBaseAddress;
            HttpResponseMessage response = null;
            List<TirthModel> _tirth = null;
            JObject j = new JObject();
            j.Add("method", URL.GetTirth);

            try
            {
                var json = JsonConvert.SerializeObject(j);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = client.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    using (StreamReader reader = new StreamReader(response.Content.ReadAsStreamAsync().Result))
                    {
                        var contents = reader.ReadToEnd();
                        JObject jObj = JObject.Parse(contents);

                        var status = jObj["status"].ToString();

                        if (status.Equals("200"))
                        {
                            _tirth = jObj["result"].ToObject<List<TirthModel>>();

                        }
                    }

                }
                CommonHelpers.DismissLoader();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                CommonHelpers.DismissLoader();
            }

            return _tirth;
        }

        public List<ImportantModel> GetImpNumbers()
        {
            CommonHelpers.ShowLoader();
            string url = URL.APIBaseAddress;
            HttpResponseMessage response = null;
            List<ImportantModel> _numbers = null;
            JObject j = new JObject();
            j.Add("method", URL.GetImpNumber);
            try
            {
                var json = JsonConvert.SerializeObject(j);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = client.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    using (StreamReader reader = new StreamReader(response.Content.ReadAsStreamAsync().Result))
                    {
                        var contents = reader.ReadToEnd();
                        JObject jObj = JObject.Parse(contents);

                        var status = jObj["status"].ToString();

                        if (status.Equals("200"))
                        {
                            _numbers = jObj["result"].ToObject<List<ImportantModel>>();

                        }
                    }

                }
                CommonHelpers.DismissLoader();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                CommonHelpers.DismissLoader();
            }


            return _numbers;
        }

        public List<PanchangModel> GetPanchang()
        {
            CommonHelpers.ShowLoader();
            string url = URL.APIBaseAddress;
            HttpResponseMessage response = null;
            List<PanchangModel> _numbers = null;
            JObject j = new JObject();
            j.Add("method", URL.GetPanchang);

            try
            {
                var json = JsonConvert.SerializeObject(j);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = client.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    using (StreamReader reader = new StreamReader(response.Content.ReadAsStreamAsync().Result))
                    {
                        var contents = reader.ReadToEnd();
                        JObject jObj = JObject.Parse(contents);

                        var status = jObj["status"].ToString();

                        if (status.Equals("200"))
                        {
                            _numbers = jObj["result"].ToObject<List<PanchangModel>>();

                        }
                    }

                }
                CommonHelpers.DismissLoader();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                CommonHelpers.DismissLoader();
            }

            return _numbers;
        }

        public List<ChokadiyaModel> GetChoghadiya()
        {
            CommonHelpers.ShowLoader();
            string url = URL.APIBaseAddress;
            HttpResponseMessage response = null;
            List<ChokadiyaModel> _numbers = null;
            JObject j = new JObject();
            j.Add("method", URL.GetChokadiya);

            try
            {
                var json = JsonConvert.SerializeObject(j);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = client.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    using (StreamReader reader = new StreamReader(response.Content.ReadAsStreamAsync().Result))
                    {
                        var contents = reader.ReadToEnd();
                        JObject jObj = JObject.Parse(contents);

                        var status = jObj["status"].ToString();

                        if (status.Equals("200"))
                        {
                            _numbers = jObj["result"].ToObject<List<ChokadiyaModel>>();

                        }
                    }

                }
                CommonHelpers.DismissLoader();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                CommonHelpers.DismissLoader();
            }

            return _numbers;
        }

        public List<SliderModel> GetSliderImages()
        {
            CommonHelpers.ShowLoader();
            string url = URL.APIBaseAddress;
            HttpResponseMessage response = null;
            List<SliderModel> _numbers = null;
            JObject j = new JObject();
            j.Add("method", URL.GetSliderImages);

            try
            {
                var json = JsonConvert.SerializeObject(j);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = client.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    using (StreamReader reader = new StreamReader(response.Content.ReadAsStreamAsync().Result))
                    {
                        var contents = reader.ReadToEnd();
                        JObject jObj = JObject.Parse(contents);

                        var status = jObj["status"].ToString();

                        if (status.Equals("200"))
                        {
                            _numbers = jObj["result"].ToObject<List<SliderModel>>();

                        }
                    }

                }
                CommonHelpers.DismissLoader();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                CommonHelpers.DismissLoader();
            }


            return _numbers; 
        }

        public List<MembersDetailsModel> GetMemberDetails(string memberId)
        {
            CommonHelpers.ShowLoader();
            string url = URL.APIBaseAddress;
            HttpResponseMessage response = null;
            List<MembersDetailsModel> _bearersModel = null;
            JObject j = new JObject();
            j.Add("method", URL.GetMemberDetails);
            j.Add("id", memberId);

            try
            {
                var json = JsonConvert.SerializeObject(j);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = client.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    using (StreamReader reader = new StreamReader(response.Content.ReadAsStreamAsync().Result))
                    {
                        var contents = reader.ReadToEnd();
                        JObject jObj = JObject.Parse(contents);

                        var status = jObj["status"].ToString();

                        if (status.Equals("200"))
                        {
                            _bearersModel = jObj["result"].ToObject<List<MembersDetailsModel>>();

                        }
                    }

                }
                CommonHelpers.DismissLoader();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                CommonHelpers.DismissLoader();
            }

            return _bearersModel;
        }

        public List<SliderModel> GetFooterSliderImages()
        {
            CommonHelpers.ShowLoader();
            string url = URL.APIBaseAddress;
            HttpResponseMessage response = null;
            List<SliderModel> _numbers = null;
            JObject j = new JObject();
            j.Add("method", URL.GetFooterSliderImages);

            try
            {
                var json = JsonConvert.SerializeObject(j);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = client.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    using (StreamReader reader = new StreamReader(response.Content.ReadAsStreamAsync().Result))
                    {
                        var contents = reader.ReadToEnd();
                        JObject jObj = JObject.Parse(contents);

                        var status = jObj["status"].ToString();

                        if (status.Equals("200"))
                        {
                            _numbers = jObj["result"].ToObject<List<SliderModel>>();

                        }
                    }

                }
                CommonHelpers.DismissLoader();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                CommonHelpers.DismissLoader();
            }

            return _numbers; 
        }

        public List<GalleryModel> GetGallery()
        {
            CommonHelpers.ShowLoader();
            string url = URL.APIBaseAddress;
            HttpResponseMessage response = null;
            List<GalleryModel> _numbers = null;
            JObject j = new JObject();
            j.Add("method", URL.GetGallery);

            try
            {
                var json = JsonConvert.SerializeObject(j);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = client.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    using (StreamReader reader = new StreamReader(response.Content.ReadAsStreamAsync().Result))
                    {
                        var contents = reader.ReadToEnd();
                        JObject jObj = JObject.Parse(contents);

                        var status = jObj["status"].ToString();

                        if (status.Equals("200"))
                        {
                            _numbers = jObj["result"].ToObject<List<GalleryModel>>();

                        }
                    }

                }
                CommonHelpers.DismissLoader();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                CommonHelpers.DismissLoader();
            }

          
            return _numbers;  
        }

        public List<NewsModel> GetNews()
        {
            CommonHelpers.ShowLoader();
            string url = URL.APIBaseAddress;
            HttpResponseMessage response = null;
            List<NewsModel> _numbers = null;
            JObject j = new JObject();
            j.Add("method", URL.GetNews);

            try
            {
                var json = JsonConvert.SerializeObject(j);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = client.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    using (StreamReader reader = new StreamReader(response.Content.ReadAsStreamAsync().Result))
                    {
                        var contents = reader.ReadToEnd();
                        JObject jObj = JObject.Parse(contents);

                        var status = jObj["status"].ToString();

                        if (status.Equals("200"))
                        {
                            _numbers = jObj["result"].ToObject<List<NewsModel>>();

                        }
                    }

                }
                CommonHelpers.DismissLoader();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                CommonHelpers.DismissLoader();
            }


            return _numbers;  
        }

        public List<WeeklyUpdatesModel> GetWeeklyUpdates()
        {
            CommonHelpers.ShowLoader();
            string url = URL.APIBaseAddress;
            HttpResponseMessage response = null;
            List<WeeklyUpdatesModel> _numbers = null;
            JObject j = new JObject();
            j.Add("method", URL.GetWeeklyData);

            try
            {
                var json = JsonConvert.SerializeObject(j);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = client.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    using (StreamReader reader = new StreamReader(response.Content.ReadAsStreamAsync().Result))
                    {
                        var contents = reader.ReadToEnd();
                        JObject jObj = JObject.Parse(contents);

                        var status = jObj["status"].ToString();

                        if (status.Equals("200"))
                        {
                            _numbers = jObj["result"].ToObject<List<WeeklyUpdatesModel>>();

                        }
                    }

                }
                CommonHelpers.DismissLoader();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                CommonHelpers.DismissLoader();
            }
          
            return _numbers;  
        }

        public bool SendFeedback(string subj,string sugestion)
        {
            CommonHelpers.ShowLoader();
            string url = URL.APIBaseAddress;
            HttpResponseMessage response = null;
            bool ret=false;
            JObject j = new JObject();
            j.Add("method", URL.feedBack);
            j.Add("subject", subj);
            j.Add("suggestion", sugestion);
            j.Add("mobile", CommonHelpers.UserId);

            try
            {
                var json = JsonConvert.SerializeObject(j);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = client.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    using (StreamReader reader = new StreamReader(response.Content.ReadAsStreamAsync().Result))
                    {
                        var contents = reader.ReadToEnd();
                        JObject jObj = JObject.Parse(contents);

                        var status = jObj["status"].ToString();

                        if (status.Equals("200"))
                        {
                            ret = true;

                        }
                    }

                }
                CommonHelpers.DismissLoader();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                CommonHelpers.DismissLoader();
            }
           
            return ret;   
        }

        public List<ChangePasswordModel> ChangePassword(string oldPassword, string newPassword)
        {
            CommonHelpers.ShowLoader();
            List<ChangePasswordModel> model = null;
            string url = URL.APIBaseAddress;
            HttpResponseMessage response = null;
            string ret = string.Empty;
            JObject j = new JObject();
            j.Add("method", URL.changePassword);
            j.Add("oldPass", oldPassword);
            j.Add("newPass", newPassword);
            j.Add("mobile", CommonHelpers.UserId);

            try
            {
                var json = JsonConvert.SerializeObject(j);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = client.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    using (StreamReader reader = new StreamReader(response.Content.ReadAsStreamAsync().Result))
                    {
                        var contents = reader.ReadToEnd();
                        JObject jObj = JObject.Parse(contents);

                        var status = jObj["status"].ToString();

                        //if (status.Equals("200"))
                        //{
                        model = jObj["result"].ToObject<List<ChangePasswordModel>>();
                        if (status.Equals("200"))
                        {
                            CommonHelpers.IsGuest = false;
                            DependencyService.Get<IPersistStoreServices>().DeleteUserData();
                        }
                        //}
                        //else
                        //{

                        //}

                    }

                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                CommonHelpers.DismissLoader();
            }
           
            //CommonHelpers.DismissLoader();
            return model;
        }

        public List<BirthdayListModel> GetBirthdayList()
        {
            CommonHelpers.ShowLoader();
            string url = URL.APIBaseAddress;
            HttpResponseMessage response = null;
            List<BirthdayListModel> _numbers = null;
            JObject j = new JObject();
            j.Add("method", URL.GetBirthdayList);

            try
            {
                var json = JsonConvert.SerializeObject(j);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = client.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    using (StreamReader reader = new StreamReader(response.Content.ReadAsStreamAsync().Result))
                    {
                        var contents = reader.ReadToEnd();
                        JObject jObj = JObject.Parse(contents);

                        var status = jObj["status"].ToString();

                        if (status.Equals("200"))
                        {
                            _numbers = jObj["result"].ToObject<List<BirthdayListModel>>();

                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }

            finally
            {
                CommonHelpers.DismissLoader();
            }
            return _numbers;    
        }

        public List<AnniversaryModel> GetAnniversaryList()
        {
            CommonHelpers.ShowLoader();
            string url = URL.APIBaseAddress;
            HttpResponseMessage response = null;
            List<AnniversaryModel> _numbers = null;
            JObject j = new JObject();
            j.Add("method", URL.GetAnniversaryList);

            try
            {
                var json = JsonConvert.SerializeObject(j);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = client.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    using (StreamReader reader = new StreamReader(response.Content.ReadAsStreamAsync().Result))
                    {
                        var contents = reader.ReadToEnd();
                        JObject jObj = JObject.Parse(contents);
                        Debug.WriteLine(contents);
                        var status = jObj["status"].ToString();

                        if (status.Equals("200"))
                        {
                            _numbers = jObj["result"].ToObject<List<AnniversaryModel>>();

                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                CommonHelpers.DismissLoader();   
            }


            return _numbers;   
        }

        public List<GalleryModel> GetGalleryDetails(string galleryId)
        {
            CommonHelpers.ShowLoader();
            string url = URL.APIBaseAddress;
            HttpResponseMessage response = null;
            List<GalleryModel> _numbers = null;
            JObject j = new JObject();
            j.Add("method", URL.GetGalleryDetails);
            j.Add("galleryID", galleryId);

            try
            {
                var json = JsonConvert.SerializeObject(j);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = client.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    using (StreamReader reader = new StreamReader(response.Content.ReadAsStreamAsync().Result))
                    {
                        var contents = reader.ReadToEnd();
                        JObject jObj = JObject.Parse(contents);

                        var status = jObj["status"].ToString();

                        if (status.Equals("200"))
                        {
                            _numbers = jObj["result"].ToObject<List<GalleryModel>>();

                        }
                    }

                }
                //CommonHelpers.DismissLoader();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                CommonHelpers.DismissLoader();
            }
           
            return _numbers;  
        }

        public List<BloodGroupModel> GetBloodGroupList()
        {
            CommonHelpers.ShowLoader();
            string url = URL.APIBaseAddress;
            HttpResponseMessage response = null;
            List<BloodGroupModel> _numbers = null;
            JObject j = new JObject();
            j.Add("method", URL.getBloodGroup);

            try
            {
                var json = JsonConvert.SerializeObject(j);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = client.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    using (StreamReader reader = new StreamReader(response.Content.ReadAsStreamAsync().Result))
                    {
                        var contents = reader.ReadToEnd();
                        JObject jObj = JObject.Parse(contents);

                        var status = jObj["status"].ToString();

                        if (status.Equals("200"))
                        {
                            _numbers = jObj["result"].ToObject<List<BloodGroupModel>>();

                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                CommonHelpers.DismissLoader();
            }
           
           
            return _numbers;  
        }

        public bool ForgotPassword(string mobileNo)
        {
            CommonHelpers.ShowLoader();
            string url = URL.APIBaseAddress;
            HttpResponseMessage response = null;
            bool ret=false;
            JObject j = new JObject();
            j.Add("method", URL.forgotPassword);
           
            j.Add("mobile", mobileNo);

            try
            {
                var json = JsonConvert.SerializeObject(j);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = client.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    using (StreamReader reader = new StreamReader(response.Content.ReadAsStreamAsync().Result))
                    {
                        var contents = reader.ReadToEnd();
                        JObject jObj = JObject.Parse(contents);

                        var status = jObj["status"].ToString();

                        if (status.Equals("200"))
                        {
                            ret = true;

                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                CommonHelpers.DismissLoader();
            }
           
            return ret;   
        }
        public List<NotificationModel> GetAllNotification()
        {
            CommonHelpers.ShowLoader();
            string url = URL.APIBaseAddress;
            HttpResponseMessage response = null;
            List<NotificationModel> ret = null;
            JObject j = new JObject();
            j.Add("method", URL.getAllNotification);

            try
            {
                var json = JsonConvert.SerializeObject(j);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                response = client.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    using (StreamReader reader = new StreamReader(response.Content.ReadAsStreamAsync().Result))
                    {
                        var contents = reader.ReadToEnd();
                        JObject jObj = JObject.Parse(contents);

                        var status = jObj["status"].ToString();

                        if (status.Equals("200"))
                        {
                            ret = jObj["result"].ToObject<List<NotificationModel>>();

                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                CommonHelpers.DismissLoader();
            }

          
            return ret;
        }
    }
}
