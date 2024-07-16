using candle_store_backend_app.Services;
using Microsoft.AspNetCore.Mvc;

namespace candle_store_backend_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IShopifyService _shopifyService;

        public ProductsController(IShopifyService shopifyService)
        {
            _shopifyService = shopifyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _shopifyService.GetProductsAsync();
            return Ok(products);
        }
    }
}
