using System.Collections.Concurrent;
using System.Text;

namespace HWShop_ASP.net.Product
{
    public class Basket : IBasket
    {
        public ConcurrentDictionary<string, int> _products = new ConcurrentDictionary<string, int>();

        public void Buy(string product, int count)
        {
            _products.TryAdd(product, count);
        }

        public ConcurrentDictionary<string, int> ShowBusket()
        {
            return _products;
        }

        public void Clear()
        {
            _products.Clear();
        }
    }
}
