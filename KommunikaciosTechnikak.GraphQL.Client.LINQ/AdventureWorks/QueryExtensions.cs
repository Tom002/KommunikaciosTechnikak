namespace AdventureWorks
{
    using System;
    using System.Collections.Generic;

    public static class QueryExtensions
    {
        public static List<ProductInventoryDto> ProductInventories(this ProductDto productDto, ProductInventoryDtoFilterInput where, List<ProductInventoryDtoSortInput> order)
        {
            throw new NotImplementedException("This method is not implemented. It exists solely for query purposes.");
        }

        public static List<WorkOrderDto> WorkOrders(this ProductDto productDto, WorkOrderDtoFilterInput where, List<WorkOrderDtoSortInput> order)
        {
            throw new NotImplementedException("This method is not implemented. It exists solely for query purposes.");
        }
    }
}