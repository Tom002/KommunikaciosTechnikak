using HotChocolate.Data.Filters;
using HotChocolate.Data;
using KommunikaciosTechnikak.GraphQL.HotChocolate.Dto;

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.GraphQL.Types
{
    public class ProductFilterInputType : FilterInputType<ProductDto>
    {
        protected override void Configure(IFilterInputTypeDescriptor<ProductDto> descriptor)
        {
            descriptor.Ignore(t => t.ProductInventories);
            descriptor.Ignore(t => t.Rowguid);
            descriptor.Ignore(t => t.WorkOrders);
            descriptor.Ignore(t => t.ProductId);

            // Lekorlátozhatóak a lehetséges szűrési műveletek
            //descriptor.Field(t => t.Name)
            //    .Type<ProductNameFilterInput>()
                
        }
    }

    public class ProductNameFilterInput : StringOperationFilterInputType
    {
        protected override void Configure(IFilterInputTypeDescriptor descriptor)
        {
            descriptor.Operation(DefaultFilterOperations.Equals);
            descriptor.Operation(DefaultFilterOperations.NotEquals);
        }
    }
}
