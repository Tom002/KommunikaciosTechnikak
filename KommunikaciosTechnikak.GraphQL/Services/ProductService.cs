using KommunikaciosTechnikak.Dal.Model;
using KommunikaciosTechnikak.GraphQL.Helper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KommunikaciosTechnikak.GraphQL.Services
{
    public class ProductService : IProductService
    {
        private readonly AdventureWorks2019Context _context;

        public ProductService(AdventureWorks2019Context context)
        {
            _context = context;
        }

        public async Task<PaginationList<Product>> GetAllProducts(
            int pageSize,
            int pageNumber,
            ProductFilter filter)
        {
            var query = _context.Products.AsQueryable();

            if(!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(q => q.Name.Contains(filter.Name));
            }
            if (!string.IsNullOrEmpty(filter.ProductNumber))
            {
                query = query.Where(q => q.ProductNumber.Contains(filter.ProductNumber));
            }
            if (filter.SellStartDate.HasValue)
            {
                query = query.Where(q => q.SellStartDate.Date == filter.SellStartDate.Value.Date);
            }
            if (filter.SellEndDate.HasValue)
            {
                query = query.Where(q => q.SellEndDate.HasValue &&
                                         q.SellEndDate.Value.Date == filter.SellEndDate.Value.Date);
            }
            return await PaginationList<Product>.CreateAsync(query, pageNumber, pageSize);
        }

        public async Task<IEnumerable<ProductInventory>> GetAllProductInventories()
        {
            return await _context.ProductInventories.ToListAsync();
        }

        public async Task<ILookup<int, ProductInventory>> GetInventoryForProducts(IEnumerable<int> productIds)
        {
            var inventory = await _context.ProductInventories
                .Where(p => productIds.Contains(p.ProductId))
                .ToListAsync();
            return inventory.ToLookup(r => r.ProductId);
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.Products.SingleAsync(p => p.ProductId == id);
        }

        public async Task<ProductInventory> GetProductInventoryById(int productId, int locationId)
        {
            return await _context.ProductInventories
                .SingleAsync(p => p.ProductId == productId &&
                                  p.LocationId == locationId);
        }

        public async Task<ProductInventory> AddProductInventory(ProductInventory productInventory)
        {
            _context.ProductInventories.Add(productInventory);
            await _context.SaveChangesAsync();
            return productInventory;
        }

        public async Task<ProductInventory> UpdateProductInventory(
            ProductInventory dbProductInventory,
            ProductInventory productInventory)
        {
            dbProductInventory.Bin = productInventory.Bin;
            dbProductInventory.Quantity = productInventory.Quantity;
            dbProductInventory.Shelf = productInventory.Shelf;

            await _context.SaveChangesAsync();
            return productInventory;
        }

        public async Task DeleteProductInventory(ProductInventory productInventory)
        {
            _context.ProductInventories.Remove(productInventory);
            await _context.SaveChangesAsync();
        }
    }
}
