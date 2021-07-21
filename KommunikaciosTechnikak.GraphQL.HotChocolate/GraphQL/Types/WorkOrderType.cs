using HotChocolate;
using HotChocolate.Types;
using KommunikaciosTechnikak.Dal.Model;
using KommunikaciosTechnikak.GraphQL.HotChocolate.Dto;
using System.Threading;
using System.Threading.Tasks;

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.GraphQL.Types
{
    public class WorkOrderType : ObjectType<WorkOrderDto>
    {
        //private class WorkOrderResolvers
        //{
        //    public async Task<ProductDto> GetProductForWorkOrderAsync(
        //        WorkOrderDto workOrder,
        //        [ScopedService] AdventureWorks2019Context dbContext,
        //        CancellationToken cancellationToken)
        //    {
        //        return await dbContext.WorkOrders
        //    }
        //}
    }
}
