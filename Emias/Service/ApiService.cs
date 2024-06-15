using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Emias.Service
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7187/");
        }

        public async Task<List<T>> GetDataAsync<T>(string endpoint)
        {
            var response = await _httpClient.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<T>>(jsonString);
                return data;
            }
            else
            {
                throw new Exception($"Failed to get data. Status code: {response.StatusCode}");
            }
        }
        public async Task AddDataAsync<T>(string endpoint, T data)
        {
            var jsonData = JsonConvert.SerializeObject(data);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(endpoint, content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to add data. Status code: {response.StatusCode}");
            }
        }

        public async Task UpdateDataAsync<T>(string endpoint,  T data)
        {
            var jsonData = JsonConvert.SerializeObject(data);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(endpoint, content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to update data. Status code: {response.StatusCode}");
            }
        }

        public async Task DeleteDataAsync<T>(string url, int id)
        {
            var response = await _httpClient.DeleteAsync($"{url}/{id}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to delete data. Status code: {response.StatusCode}");
            }
        }
    }
}
