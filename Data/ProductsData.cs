using System.Text.Json;
using ProductsRedisAPI.Models;
using StackExchange.Redis;

namespace ProductsRedisAPI.Data
{
    public class ProductsData : IProductsData
    {
        private readonly IDatabase _db;
        public ProductsData(IConnectionMultiplexer connection)
        {
            _db = connection.GetDatabase();
        }
        public Product? CreateProduct(Product product)
        {
            product.ID = $"product:{Guid.NewGuid().ToString()}";
            _db.HashSet("productdb",new HashEntry[]{
               new HashEntry(product.ID,JsonSerializer.Serialize(product)) 
            });

            return product;
        }

        public bool DeleteProductById(string id)
        {
            return _db.HashDelete("productdb",$"product:{id}");
        }

        public IEnumerable<Product?>? GetAllProducts()
        {
            return Array.ConvertAll(
                _db.HashGetAll("productdb"),
                products=> JsonSerializer.Deserialize<Product>(products.Value.ToString())
            ).ToList();
            
        }

        public Product? GetProductById(string id)
        {
            return JsonSerializer.Deserialize<Product>(_db.HashGet("productdb",$"product:{id}").ToString());
        }

        public Product? UpdateProduct(Product product)
        {
             product.ID = $"product:{product.ID}";
            _db.HashSet("productdb",new HashEntry[]{
               new HashEntry(product.ID,JsonSerializer.Serialize(product)) 
            });

            return product;
        }
    }
}