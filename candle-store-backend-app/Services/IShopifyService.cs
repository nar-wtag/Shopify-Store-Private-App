using candle_store_backend_app.Models;

namespace candle_store_backend_app.Services
{
    public interface IShopifyService
    {
        Task<List<Product>> GetProductsAsync();
    }
}
