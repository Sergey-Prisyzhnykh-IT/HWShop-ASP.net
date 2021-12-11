
namespace HW2OnlineShop
{
    public interface IProductCatalog
    {
        IReadOnlyCollection<Product> GetProductCatalog();
        public Product GetProduct(string productName);

    }
}