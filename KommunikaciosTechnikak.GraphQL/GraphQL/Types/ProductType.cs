using GraphQL.DataLoader;
using GraphQL.Types;
using KommunikaciosTechnikak.Dal.Model;
using KommunikaciosTechnikak.GraphQL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KommunikaciosTechnikak.GraphQL.GraphQL.Types
{
    public class ProductType : ObjectGraphType<Dal.Model.Product>
    {
        public ProductType(
            IProductService productService,
            IDataLoaderContextAccessor dataLoaderAccessor)
        {
            Field(p => p.Class);
            Field(p => p.Color);
            Field(p => p.DaysToManufacture);
            Field(p => p.DiscontinuedDate, nullable: true);
            Field(p => p.FinishedGoodsFlag, nullable: true);
            Field(p => p.ListPrice);
            Field(p => p.MakeFlag, nullable: true);
            Field(p => p.ModifiedDate);
            Field(p => p.Name);
            Field(p => p.ProductId);
            Field(p => p.ProductLine);
            Field(p => p.ProductModelId, nullable: true);
            Field(p => p.ProductNumber);
            Field(p => p.ReorderPoint);
            Field(p => p.SafetyStockLevel);
            Field(p => p.SellEndDate, nullable: true);
            Field(p => p.SellStartDate, nullable: true);
            Field(p => p.Size);
            Field(p => p.SizeUnitMeasureCode);
            Field(p => p.StandardCost);
            Field(p => p.Style);
            Field(p => p.Weight, nullable: true);
            Field(p => p.WeightUnitMeasureCode);


            Field<ListGraphType<ProductInventoryType>>(
                "inventories",
                resolve: context =>
                {
                    var loader =
                        dataLoaderAccessor.Context.GetOrAddCollectionBatchLoader<int, ProductInventory>(
                            "GetInventoriesByProductId", productService.GetInventoryForProducts);
                    return loader.LoadAsync(context.Source.ProductId);
                });

        }
    }
}
