namespace candle_store_backend_app.Config
{
    public class Settings
    {
        public string BaseUrl { get; init; } = "";
        public ShopifySettings Shopify { get; init; } = new ShopifySettings();
    }
}
