using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace LibraryManagement.Web.Services
{
    public class ApiService
    {
        private readonly HttpClient _client;

        public ApiService()
        {
            var url = ConfigurationManager.AppSettings["ApiBaseUrl"];
            _client = new HttpClient();
            _client.BaseAddress = new Uri(url);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            return await _client.GetAsync(url);
        }

        public async Task<HttpResponseMessage> PostAsync<T>(string url, T data)
        {
            return await _client.PostAsJsonAsync(url, data);
        }

        public async Task<HttpResponseMessage> PutAsync<T>(string url, T data)
        {
            return await _client.PutAsJsonAsync(url, data);
        }

        public async Task<HttpResponseMessage> DeleteAsync(string url)
        {
            return await _client.DeleteAsync(url);
        }
    }
}