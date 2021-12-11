using System.Collections.Concurrent;
using System.Text;

namespace HWShop_ASP.net.Product
{
    public interface IBasket
    {
        void Buy(HW2OnlineShop.Product product, int count);
        ConcurrentDictionary<HW2OnlineShop.Product, int> ShowBusket();
        void Clear();
    }
}