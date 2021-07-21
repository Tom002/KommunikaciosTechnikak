using KommunikaciosTechnikak.GraphQL.HotChocolate.Dto;
using KommunikaciosTechnikak.GraphQL.HotChocolate.GraphQL.Common;
using System.Collections.Generic;

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.GraphQL.Product
{
    public class UpdateProductPayload : ProductPayloadBase
    {
        public UpdateProductPayload(ProductDto product)
            : base(product)
        {

        }

        public UpdateProductPayload(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }
    }
}
