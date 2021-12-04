using System.Collections.Concurrent;
using System.Text;

namespace HWShop_ASP.net.Product
{
    public interface IBasket
    {
        void Buy(string product, int count);
        ConcurrentDictionary<string, int> ShowBusket();
        void Clear();
    }
}