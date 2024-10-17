using ProductsRedisAPI.Models;

namespace ProductsRedisAPI.Data
{
    public interface IProductsData
    {
        Product? CreateProduct(Product product);
        IEnumerable<Product?>? GetAllProducts();
        Product? GetProductById(string id);
        Product? UpdateProduct(Product product);
        bool DeleteProductById(string id);
    }
}