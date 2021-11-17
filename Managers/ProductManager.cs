using System.Collections.Generic;
using BFYOC.Function.Data;
using BFYOC.Function.Providers;

namespace BFYOC.Function.Managers
{
    public sealed class ProductManager 
    {
        private static ProductRestProvider productProvider = new ProductRestProvider();

        public List<Product> GetProducts()
        {
            return productProvider.GetProducts();
        }

        public Product GetProduct(string productId)
        {
            return productProvider.GetProduct(productId);
        }
    }
}