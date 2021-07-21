using HotChocolate.Types.Relay;
using KommunikaciosTechnikak.GraphQL.HotChocolate.Dto;
using KommunikaciosTechnikak.GraphQL.HotChocolate.GraphQL.Dataloader;
using System.Threading;
using System.Threading.Tasks;

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.GraphQL.Product
{
    public class ProductUpdatedPayload
    {
        public ProductUpdatedPayload(int productId)
        {
            ProductId = productId;
        }

        [ID(nameof(ProductDto))]
        public int ProductId { get; }

        public Task<ProductDto> GetProductAsync(
            ProductByIdDataLoader productById,
            CancellationToken cancellationToken) 
                => productById.LoadAsync(ProductId, cancellationToken);
    }
}
