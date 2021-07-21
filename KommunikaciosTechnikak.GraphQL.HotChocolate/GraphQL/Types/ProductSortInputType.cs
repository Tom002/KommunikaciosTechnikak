using HotChocolate.Data.Sorting;
using KommunikaciosTechnikak.GraphQL.HotChocolate.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.GraphQL.Types
{
    public class ProductSortInputType : SortInputType<ProductDto>
    {
        protected override void Configure(ISortInputTypeDescriptor<ProductDto> descriptor)
        {
            descriptor.Field(x => x.Name)
                .Name("productName")
                .Type<AscOnlySortEnumType>();
        }

    }

    public class AscOnlySortEnumType : DefaultSortEnumType
    {
        protected override void Configure(ISortEnumTypeDescriptor descriptor)
        {
            descriptor.Operation(DefaultSortOperations.Ascending);
        }
    }
}
