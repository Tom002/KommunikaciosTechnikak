using Default;
using KommunikaciosTechnikak.Dal.Model;
using Microsoft.OData.Client;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace KommunikaciosTechnikak.OData.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceRoot = "http://localhost:5800/odata/";
            var context = new Container(new Uri(serviceRoot));

            // Get all products
            var products = await context.Products.ExecuteAsync();
            Console.WriteLine("Listing products");
            Console.WriteLine("Products: ");
            foreach (var product in products)
            {
                Console.WriteLine(product.Name);
            }

            // Complex query
            var filteredProducts = context.Products
                .Where(p => p.SafetyStockLevel > 999)
                .Where(p => p.ProductId < 100)
                .Skip(3)
                .Take(5)
                .OrderBy(p => p.Name)
                .Select(p => new { p.Name, p.ListPrice })
                .ToList();
            Console.WriteLine("Listing filtered products");
            Console.WriteLine("Products: ");
            foreach (var product in filteredProducts)
            {
                Console.WriteLine(product.Name);
            }

            // Adding new product
            var newProduct = Product.CreateProduct(
                productId: 0,
                name: "Test product 1299",
                productNumber: "TS-1288",
                makeFlag: false,
                finishedGoodsFlag: false,
                safetyStockLevel: 1000,
                reorderPoint: 750,
                100,
                75,
                10,
                new DateTimeOffset(2020, 11, 10, 0, 0, 0, TimeSpan.FromHours(1)));

            context.AddToProducts(newProduct);
            var responses = await context.SaveChangesAsync();

            foreach (OperationResponse response in responses)
            {
                var changeResponse = (ChangeOperationResponse)response;
                var entityDescriptor = (EntityDescriptor)changeResponse.Descriptor;
                var productCreated = (Product)entityDescriptor.Entity;
            }

            // Updating product
            var productToUpdate = context.Products
                .Where(p => p.ProductId == 2)
                .SingleOrDefault();

            productToUpdate.Name = "Updated name";
            context.UpdateObject(productToUpdate);
            await context.SaveChangesAsync();

            // Deleting product
            var productToDelete = context.Products
                .Where(p => p.ProductId == 2002)
                .SingleOrDefault();

            context.DeleteObject(productToDelete);
            await context.SaveChangesAsync();


            // Batch query
            var productQuery = context.Products;
            var productInventoryQuery = context.ProductInventory;

            var batchResponse = await context.ExecuteBatchAsync(productQuery, productInventoryQuery);
            foreach (OperationResponse r in batchResponse)
            {
                QueryOperationResponse<Product> productResponse = r as QueryOperationResponse<Product>;
                if (productResponse != null)
                {
                    foreach (Product product in productResponse)
                    {
                        Console.WriteLine($"Product Name: {product.Name}");
                    }
                }

                QueryOperationResponse<ProductInventory> productInventoryResponse =
                    r as QueryOperationResponse<ProductInventory>;
                if (productInventoryResponse != null)
                {
                    foreach (ProductInventory productInventory in productInventoryResponse)
                    {
                        Console.WriteLine($"Product Inventory quantity: {productInventory.Quantity}");
                    }
                }
            }

            // Batch Update
            var productToUpdate1 = context.Products
                .Where(p => p.ProductId == 1)
                .SingleOrDefault();

            var productToUpdate2 = context.Products
                .Where(p => p.ProductId == 2)
                .SingleOrDefault();

            productToUpdate1.Name = "Update 1";
            productToUpdate2.Name = "Update 2";

            context.UpdateObject(productToUpdate1);
            context.UpdateObject(productToUpdate2);

            // BatchWithSingleChangeset => Ha egy művelet el failol akkor a többi is
            // BatchWithIndependentOperations => Műveletek egymástól függetlenül sikeresek/sikertelenek
            await context.SaveChangesAsync(SaveChangesOptions.BatchWithSingleChangeset);

            Console.ReadLine();
        }
    }
}
