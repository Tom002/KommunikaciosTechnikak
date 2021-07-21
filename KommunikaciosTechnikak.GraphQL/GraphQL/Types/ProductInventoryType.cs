using GraphQL.Types;
using KommunikaciosTechnikak.GraphQL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KommunikaciosTechnikak.GraphQL.GraphQL.Types
{
    public class ProductInventoryType : ObjectGraphType<Dal.Model.ProductInventory>
    {
        public ProductInventoryType(IProductService productService)
        {
            Field(p => p.Bin);
            Field(p => p.LocationId);
            Field(p => p.ModifiedDate);
            FieldAsync<ProductType, Dal.Model.Product>(
                "product",
                resolve: context =>
                {
                    return productService.GetProductById(context.Source.ProductId);
                });
            Field(p => p.ProductId);
            Field(p => p.Quantity);
            Field(p => p.Shelf);
        }
    }
}
