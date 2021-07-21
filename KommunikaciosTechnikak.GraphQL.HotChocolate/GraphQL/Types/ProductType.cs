using HotChocolate;
using HotChocolate.Types;
using KommunikaciosTechnikak.Dal.Model;
using KommunikaciosTechnikak.GraphQL.HotChocolate.Dto;
using KommunikaciosTechnikak.GraphQL.HotChocolate.GraphQL.Dataloader;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.GraphQL.Types
{
    public class ProductType : ObjectType<ProductDto>
    {
        protected override void Configure(IObjectTypeDescriptor<ProductDto> descriptor)
        {
            descriptor.Field(t => t.Class).Ignore();
            descriptor.Field(t => t.Color).Name("Colour");
            //descriptor.Field(t => t.ProductNumber).Authorize("AdminAuthPolicy");
        }

        private class ProductResolvers
        {
            public async Task<IEnumerable<WorkOrderDto>> GetWorkOrdersAsync(
                ProductDto product,
                [ScopedService] AdventureWorks2019Context dbContext,
                WorkOrderByIdDataLoader workOrderById,
                CancellationToken cancellationToken)
            {
                int[] workOrderIds = await dbContext.WorkOrders
                    .Where(w => w.ProductId == product.ProductId)
                    .Select(w => w.WorkOrderId)
                    .ToArrayAsync();

                return await workOrderById.LoadAsync(workOrderIds, cancellationToken);
            }

            public async Task<IEnumerable<ProductInventoryDto>> GetProductInventoriesAsync(
                ProductDto product,
                [ScopedService] AdventureWorks2019Context dbContext,
                ProductInventoryByProductIdDataLoader productInventoryByProductId,
                CancellationToken cancellationToken)
            {
                return await productInventoryByProductId.LoadAsync(cancellationToken, product.ProductId);
            }
        }
    }
}
