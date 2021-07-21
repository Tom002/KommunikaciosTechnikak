using AutoMapper;
using HotChocolate;
using HotChocolate.Subscriptions;
using KommunikaciosTechnikak.Dal.Model;
using KommunikaciosTechnikak.GraphQL.HotChocolate.Dto;
using KommunikaciosTechnikak.GraphQL.HotChocolate.Extensions;
using KommunikaciosTechnikak.GraphQL.HotChocolate.GraphQL.Common;
using KommunikaciosTechnikak.GraphQL.HotChocolate.GraphQL.Product;
using KommunikaciosTechnikak.GraphQL.HotChocolate.GraphQL.Subscriptions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.GraphQL
{
    public class Mutation
    {
        [UseApplicationDbContext]
        public async Task<AddProductPayload> AddProductAsync(
            AddProductInput input,
            [ScopedService] AdventureWorks2019Context context,
            [Service] IMapper mapper,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
        {
            var product = mapper.Map<Dal.Model.Product>(input);

            context.Products.Add(product);
            await context.SaveChangesAsync(cancellationToken);

            var productDto = mapper.Map<ProductDto>(product);

            await eventSender.SendAsync(
                nameof(ProductSubscriptions.OnProductAddedAsync),
                productDto.ProductId);

            return new AddProductPayload(productDto);
        }

        [UseApplicationDbContext]
        public async Task<UpdateProductPayload> UpdateProductAsync(
            UpdateProductInput input,
            [ScopedService] AdventureWorks2019Context context,
            [Service] IMapper mapper,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
        {
            var productToUpdate = await context.Products
                .FirstOrDefaultAsync(p => p.ProductId == input.ProductId);

            if(productToUpdate == null)
            {
                return new UpdateProductPayload(
                    new List<UserError> { new UserError($"Product with id: {input.ProductId} was not found","PRODUCT_NOT_FOUND") });
            }

            mapper.Map(input, productToUpdate);
            await context.SaveChangesAsync(cancellationToken);

            var productDto = mapper.Map<ProductDto>(productToUpdate);

            await eventSender.SendAsync(
                $"OnProductUpdated_{productDto.ProductId}",
                productDto,
                cancellationToken);

            return new UpdateProductPayload(productDto);
        }
    }
}
