using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text;

namespace candle_store_backend_app.Services
{
    public class ShopifyService : IShopifyService
    {
        private readonly HttpClient _httpClient;

        public ShopifyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        
        public async Task<List<Models.Product>> GetProductsAsync()
        {
            var query = @"
                        {
                            products(first: 20) {
                                edges {
                                    node {
                                        id
                                        title
                                        description
                                        featuredImage {
                                            id
                                            url
                                        }
                                        variants(first: 3) {
                                            edges {
                                                node {
                                                    price {
                                                        amount
                                                        currencyCode
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }";

            var requestBody = new { query };
            var options = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented
            };

            var content = new StringContent(JsonConvert.SerializeObject(requestBody, options), Encoding.UTF8, "application/json");


            var response = await _httpClient.PostAsync("https://mock.shop/api", content);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var productResponse = JsonConvert.DeserializeObject<ProductsResponse>(jsonResponse, options);
            return productResponse.Products.Edges.Select(edge => edge.Node).ToList();

        }
    }

    public class ProductsResponse
    {
        public ProductConnection Products { get; set; }
    }

    public class ProductConnection
    {
        public List<ProductEdge> Edges { get; set; }
    }

    public class ProductEdge
    {
        public Models.Product Node { get; set; }
    }
}
