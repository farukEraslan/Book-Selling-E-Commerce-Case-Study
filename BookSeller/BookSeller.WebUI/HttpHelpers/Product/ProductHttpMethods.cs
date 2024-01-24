using BookSeller.WebUI.HttpHelpers.Abstract;
using Newtonsoft.Json;

namespace BookSeller.WebUI.HttpHelpers.Product
{
    public class ProductHttpMethods : IHttpMethods
    {
        private readonly HttpClient _httpClient;

        public ProductHttpMethods()
        {
            _httpClient = new HttpClient();
            
        }
        
        private const string BaseAddress = "https://localhost:7233/api/";

        public async Task<T> HttpGetAll<T>()
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{BaseAddress}Product/GetAll");
            string apiResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(apiResponse);
            return result;
        }
    }
}
