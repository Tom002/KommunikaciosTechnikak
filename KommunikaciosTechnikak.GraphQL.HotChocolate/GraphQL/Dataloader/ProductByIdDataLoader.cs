using AutoMapper;
using AutoMapper.QueryableExtensions;
using GreenDonut;
using HotChocolate.DataLoader;
using KommunikaciosTechnikak.Dal.Model;
using KommunikaciosTechnikak.GraphQL.HotChocolate.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.GraphQL.Dataloader
{
    public class ProductByIdDataLoader : BatchDataLoader<int, ProductDto>
    {
        private IDbContextFactory<AdventureWorks2019Context> _dbContextFactory;
        private IMapper _mapper;

        public ProductByIdDataLoader(
            IBatchScheduler batchScheduler,
            IDbContextFactory<AdventureWorks2019Context> dbContextFactory,
            IMapper mapper)
            : base(batchScheduler)
        {
            _dbContextFactory = dbContextFactory ??
                throw new ArgumentNullException(nameof(dbContextFactory));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        protected override async Task<IReadOnlyDictionary<int, ProductDto>> LoadBatchAsync(
            IReadOnlyList<int> keys,
            CancellationToken cancellationToken)
        {
            await using AdventureWorks2019Context dbContext =
                _dbContextFactory.CreateDbContext();

            return await dbContext.Products
                .Where(p => keys.Contains(p.ProductId))
                .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                .ToDictionaryAsync(p => p.ProductId, cancellationToken);
        }
    }
}
