using System.Collections.Concurrent;
using System.Text;

namespace HWShop_ASP.net.Product
{
    public interface IBasket
    {
        void Buy(HW2OnlineShop.Product product, int count);
        ConcurrentDictionary<HW2OnlineShop.Product, int> ShowBusket();
        void Clear();
        public int GetProductCount(string productName);
        public void AddProduct(string productName);
        public void DeleteProduct(string productName);
    }
}