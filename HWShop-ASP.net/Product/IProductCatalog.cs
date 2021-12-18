
namespace HW2OnlineShop
{
    public interface IProductCatalog
    {
        void AddDBProduct(Product products);
        Product GetProduct(string productName);
        IReadOnlyCollection<Product> GetProductCatalog();
    }
}