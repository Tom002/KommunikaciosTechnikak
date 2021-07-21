using KommunikaciosTechnikak.Dal.Model;
using KommunikaciosTechnikak.GraphQL.Helper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KommunikaciosTechnikak.GraphQL.Services
{
    public interface IProductService
    {
        public Task<PaginationList<Product>> GetAllProducts(
            int pageSize,
            int pageNumber,
            ProductFilter filter);

        public Task<IEnumerable<ProductInventory>> GetAllProductInventories();

        public Task<Product> GetProductById(int id);

        public Task<ProductInventory> GetProductInventoryById(int productId, int locationId);

        public Task<ILookup<int, ProductInventory>> GetInventoryForProducts(IEnumerable<int> productIds);

        public Task<ProductInventory> AddProductInventory(ProductInventory productInventory);

        public Task<ProductInventory> UpdateProductInventory(
            ProductInventory dbProductInventory,
            ProductInventory productInventory);

        public Task DeleteProductInventory(ProductInventory productInventory);
    }
}
