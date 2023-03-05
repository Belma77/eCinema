using eCinema.WinUI.Properties;
using eCInema.Models;
using eCInema.Models.Dtos;
using Flurl.Http;
using MediaBrowser.Model.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace eCinema.WinUI
{
    public class APIservice
    {
        private string _resource = null;
        public string _endpoint = Settings.Default.ApiURL;    //"https://localhost:7239/";

        public static string Username = null;
        public static string Password = null;
        public List<int> ItemsPerPage = new List<int>{ 5, 10, 20, 50 };
        public APIservice(string resource)
        {
            _resource = resource;
        }


        public async Task<T> Get<T>(object search = null)
        {
            try
            {
                var query = "";
                if (search != null)
                {
                    query = await search.ToQueryString();
                }
                var list = await $"{_endpoint}{_resource}?{query}".WithBasicAuth(Username, Password).GetJsonAsync<T>();

                return list;
            }

            catch (FlurlHttpException ex)
            {

                if (ex.Call.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    MessageBox.Show("Unauthorized", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (ex.Call.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    MessageBox.Show("Forbidden", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (ex.Call.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    MessageBox.Show("User not found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (ex.Call.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    MessageBox.Show("Something went wrong", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                throw;
            }
        }
        
        public async Task<T> GetById<T>(object id)
        {
            var result = await $"{_endpoint}{_resource}/{id}".WithBasicAuth(Username, Password).GetJsonAsync<T>();

            return result;
        }
        public async Task<T> Post<T>(object request)
        {
            try
            {
                var result = await $"{_endpoint}{_resource}".WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
                return result;
            }

            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    MessageBox.Show("Unauthorized", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (ex.Call.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    MessageBox.Show("Forbidden", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (ex.Call.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    MessageBox.Show("User not found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (ex.Call.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    MessageBox.Show("Something went wrong", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                throw;

            }
        }

            public async Task Delete(int id)
            {
            try
            {
                await $"{_endpoint}{_resource}/{id}".WithBasicAuth(Username, Password).DeleteAsync();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    MessageBox.Show("Unauthorized", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (ex.Call.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    MessageBox.Show("Forbidden", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (ex.Call.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    MessageBox.Show("User not found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (ex.Call.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    MessageBox.Show("Something went wrong", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                throw;
            
        }
        }

        public async Task<T> Put<T>(object id, object request)
        {
            try
            {
                var result = await $"{_endpoint}{_resource}/{id}".WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();
                return result;
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    MessageBox.Show("Unauthorized", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (ex.Call.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    MessageBox.Show("Forbidden", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (ex.Call.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    MessageBox.Show("User not found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (ex.Call.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    MessageBox.Show("Something went wrong", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                throw;

            }
        }

        public async Task DeleteFromMovie<T>(List<T> delete)
        {
            try
            {
               await $"{_endpoint}{_resource}/{"FromMovie"}".WithBasicAuth(Username, Password).SendJsonAsync(HttpMethod.Delete, delete);
            }

            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    MessageBox.Show("Unauthorized", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (ex.Call.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    MessageBox.Show("Forbidden", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (ex.Call.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    MessageBox.Show("User not found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (ex.Call.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    MessageBox.Show("Something went wrong", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                throw;
            
        }
     }
      

        public async Task<T> AddToMovie<T>(object id, List<T> request)
        {
            try
            {
                var result = await $"{_endpoint}{_resource}/{"AddToMovie"}/{id}".WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
                return result;
            }

            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    MessageBox.Show("Unauthorized", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (ex.Call.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    MessageBox.Show("Forbidden", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (ex.Call.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    MessageBox.Show("User not found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (ex.Call.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    MessageBox.Show("Something went wrong", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                throw;

            }
        }
        public async Task<T> GetSales<T>(string path)
        {
            try
            {
               
                var list = await $"{_endpoint}{_resource}/{path}".WithBasicAuth(Username, Password).GetJsonAsync<T>();

                return list;
            }

            catch (FlurlHttpException ex)
            {

                if (ex.Call.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    MessageBox.Show("Unauthorized", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (ex.Call.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    MessageBox.Show("Forbidden", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (ex.Call.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    MessageBox.Show("User not found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (ex.Call.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    MessageBox.Show("Something went wrong", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                throw;
            }
        }

    }
    }

