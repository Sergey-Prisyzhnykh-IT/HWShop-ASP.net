using System.Collections.Concurrent;
using System.Text;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace HWShop_ASP.net.Product
{
    public class Basket : IBasket
    {
        ProtectedLocalStorage _localStorage;
        public ConcurrentDictionary<HW2OnlineShop.Product, int> _products = new ConcurrentDictionary<HW2OnlineShop.Product, int>();

        public void Buy(HW2OnlineShop.Product product, int count)
        {
            _products.TryAdd(product, count);
        }

        public ConcurrentDictionary<HW2OnlineShop.Product, int> ShowBusket()
        {
            return _products;
        }

        public void Clear()
        {
            _products.Clear();
        }


        public int GetProductCount(string productName)
        {
            foreach (var product in _products)
                if (product.Key.Name == productName)
                    return product.Value;
            return 0;
        }

        public void AddProduct(string productName)
        {
            foreach (var product in _products)
                if (product.Key.Name == productName) 
                {
                    var tempCountProduct = product.Value;
                    tempCountProduct++;
                    _products.TryUpdate(product.Key, tempCountProduct, product.Value);
                }                  
        }

        public void DeleteProduct(string productName)
        {
            foreach (var product in _products)
                if (product.Key.Name == productName)
                {
                    var tempCountProduct = product.Value;
                    tempCountProduct--;
                    _products.TryUpdate(product.Key, tempCountProduct, product.Value);
                }
        }
    }
}
