
namespace HW2OnlineShop
{
    public interface IProductCatalog
    {
        IReadOnlyCollection<Product> GetProductCatalog();
    }
}