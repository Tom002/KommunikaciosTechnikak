using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using KommunikaciosTechnikak.GraphQL.HotChocolate.Dto;
using KommunikaciosTechnikak.GraphQL.HotChocolate.GraphQL.Dataloader;
using KommunikaciosTechnikak.GraphQL.HotChocolate.GraphQL.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.GraphQL.Subscriptions
{
    [ExtendObjectType(Name = "Subscription")]
    public class ProductSubscriptions
    {
        [Subscribe]
        [Topic]
        public Task<ProductDto> OnProductAddedAsync(
            [EventMessage] int productId,
            ProductByIdDataLoader productById,
            CancellationToken cancellationToken) 
                => productById.LoadAsync(productId, cancellationToken);

        [Subscribe(With = nameof(SubscribeToOnProductUpdatedAsync))]
        public ProductUpdatedPayload OnProductUpdatedAsync(
            [EventMessage] int productId,
            ProductByIdDataLoader productById,
            CancellationToken cancellationToken) 
                => new ProductUpdatedPayload(productId);

        public async ValueTask<ISourceStream<int>> SubscribeToOnProductUpdatedAsync(
            int productId,
            [Service] ITopicEventReceiver eventReceiver,
            CancellationToken cancellationToken) =>
            await eventReceiver.SubscribeAsync<string, int>(
                "OnProductUpdated_" + productId, cancellationToken);

    }
}
