using GraphQL;
using GraphQL.Types;
using KommunikaciosTechnikak.Dal.Model;
using KommunikaciosTechnikak.GraphQL.GraphQL.Types;
using KommunikaciosTechnikak.GraphQL.Services;

namespace KommunikaciosTechnikak.GraphQL.GraphQL
{
    public class AdventureWorksMutation : ObjectGraphType
    {
        public AdventureWorksMutation(IProductService productService)
        {
            FieldAsync<ProductInventoryType>(
                "createProductInventory",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ProductInventoryInputType>> { Name = "inventory" }),
                resolve: async context => 
                {
                    var productInventory = context.GetArgument<ProductInventory>("inventory");
                    return await productService.AddProductInventory(productInventory);
                });

            FieldAsync<ProductInventoryType>(
                "updateProductInventory",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "productId" },
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "locationId" },
                    new QueryArgument<NonNullGraphType<ProductInventoryInputType>> { Name = "inventory" }),
                resolve: async context =>
                {
                    var productId = context.GetArgument<int>("productId");
                    var locationId = context.GetArgument<int>("locationId");
                    var productInventory = context.GetArgument<ProductInventory>("inventory");

                    var productInventoryToUpdate = await productService
                        .GetProductInventoryById(productId, locationId);

                    if(productInventoryToUpdate is ProductInventory)
                    {
                        var updatedInventory = await productService
                            .UpdateProductInventory(productInventoryToUpdate, productInventory);
                        return updatedInventory;
                    }
                    context.Errors.Add(new ExecutionError("Couldn't find product inventory in db."));
                    return null;
                });

            FieldAsync<StringGraphType>(
                "deleteProductInventory",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "productId" },
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "locationId" }),
                resolve: async context =>
                {
                    var productId = context.GetArgument<int>("productId");
                    var locationId = context.GetArgument<int>("locationId");
                   
                    var productInventoryToDelete = await productService
                        .GetProductInventoryById(productId, locationId);

                    if (productInventoryToDelete is ProductInventory)
                    {
                        await productService.DeleteProductInventory(productInventoryToDelete);
                        return $"The product inventory has been successfully deleted from db.";
                    }
                    context.Errors.Add(new ExecutionError("Couldn't find product inventory in db."));
                    return null;
                });
        }
    }
}
