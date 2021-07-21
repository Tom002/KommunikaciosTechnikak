using KommunikaciosTechnikak.GraphQL.HotChocolate.Dto;
using KommunikaciosTechnikak.GraphQL.HotChocolate.GraphQL.Common;
using System.Collections.Generic;

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.GraphQL.Product
{
    public class AddProductPayload : ProductPayloadBase
    {
        public AddProductPayload(ProductDto product)
            : base(product)
        {

        }

        public AddProductPayload(IReadOnlyList<UserError> errors)
            : base(errors)
        {
        }
    }
}
