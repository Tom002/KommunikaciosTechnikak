using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KommunikaciosTechnikak.GraphQL.GraphQL.Types
{
    public class ProductInventoryInputType : InputObjectGraphType
    {
        public ProductInventoryInputType()
        {
            Name = "productInventoryInput";
            Field<NonNullGraphType<IntGraphType>>("locationId");
            Field<NonNullGraphType<IntGraphType>>("productId");
            Field<StringGraphType>("shelf");
            Field<ByteGraphType>("bin");
            Field<ShortGraphType>("quantity");
        }
    }
}
