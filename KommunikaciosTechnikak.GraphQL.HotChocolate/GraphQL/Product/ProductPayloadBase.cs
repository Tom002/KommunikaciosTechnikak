using KommunikaciosTechnikak.GraphQL.HotChocolate.Dto;
using KommunikaciosTechnikak.GraphQL.HotChocolate.GraphQL.Common;
using System.Collections.Generic;

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.GraphQL.Product
{
    public class ProductPayloadBase : Payload
    {
        protected ProductPayloadBase(ProductDto productDto)
        {
            Product = productDto;
        }

        protected ProductPayloadBase(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }

        public ProductDto? Product { get; }
    }
}
