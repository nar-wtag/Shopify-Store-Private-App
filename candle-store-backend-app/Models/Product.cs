namespace candle_store_backend_app.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public FeaturedImage FeaturedImage { get; set; }
        public List<VariantEdge> Variants { get; set; }
    }

    public class FeaturedImage
    {
        public string Id { get; set; }
        public string Url { get; set; }
    }

    public class VariantEdge
    {
        public Variant Node { get; set; }
    }

    public class Variant
    {
        public Price Price { get; set; }
    }

    public class Price
    {
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
    }

}
