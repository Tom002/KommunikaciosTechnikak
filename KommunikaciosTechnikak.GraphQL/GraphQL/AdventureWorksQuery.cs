using GraphQL;
using GraphQL.Builders;
using GraphQL.Types;
using KommunikaciosTechnikak.Dal.Model;
using KommunikaciosTechnikak.GraphQL.GraphQL.Types;
using KommunikaciosTechnikak.GraphQL.GraphQL.Types.Pagination;
using KommunikaciosTechnikak.GraphQL.Helper;
using KommunikaciosTechnikak.GraphQL.Services;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KommunikaciosTechnikak.GraphQL.GraphQL
{

    [Authorize]
    public class AdventureWorksQuery : ObjectGraphType
    {
        private static int DefaultPageSize = 10;

        public AdventureWorksQuery(IProductService productService)
        {

            FieldAsync<PaginationListType<ProductType, Product>>(
                "products",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "pageSize", Description = "Number of elements to display in one page" },
                    new QueryArgument<IntGraphType> { Name = "pageNumber", Description = "Page number" },
                    new QueryArgument<ProductFilterType> { Name = "filter", Description = "Product filter values" }
                ),
                resolve: async context =>
                {
                    var pageSize = context.GetArgument<int>("pageSize", DefaultPageSize);
                    var pageNumber = context.GetArgument<int>("pageNumber", 1);
                    var filter = context.GetArgument<ProductFilter>("filter");
                    if(filter == null)
                    {
                        filter = new ProductFilter();
                    }
                    return await productService.GetAllProducts(pageSize, pageNumber, filter);
                }
            );

            Field<ListGraphType<ProductInventoryType>>(
                "productInventories",
                resolve: context => productService.GetAllProductInventories()
            );

            Field<ProductType>(
                "product",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>>
                { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return productService.GetProductById(id);
                }
            );

            Field<ProductInventoryType>(
                "productInventory",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "productId" },
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "locationId" }
                ),
                resolve: context =>
                {
                    var productId = context.GetArgument<int>("productId");
                    var locationId = context.GetArgument<int>("locationId");
                    return productService.GetProductInventoryById(productId, locationId);
                }
            );
        }
    }
}
