using candle_store_backend_app.Models;
using Newtonsoft.Json;
using System.Text;

namespace candle_store_backend_app.Services
{
    public class FakeStoreProductService
    {
        private readonly HttpClient _httpClient;

        public FakeStoreProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Product>> GetProductsFromFakeStoreApi()
        {
            var response = await _httpClient.GetStringAsync("https://fakestoreapi.com/products");
            return JsonConvert.DeserializeObject<List<Product>>(response);
        }

        public async Task<Product> AddProductToFakeStoreApi(Product newProduct)
        {
            var jsonProduct = JsonConvert.SerializeObject(newProduct);
            var content = new StringContent(jsonProduct, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://fakestoreapi.com/products", content);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Product>(responseString);
        }
    }
}
