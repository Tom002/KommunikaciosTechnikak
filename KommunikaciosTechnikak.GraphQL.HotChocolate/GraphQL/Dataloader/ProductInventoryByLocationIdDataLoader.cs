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
    public class ProductInventoryByLocationIdDataLoader : BatchDataLoader<short, ProductInventoryDto>
    {
        private IDbContextFactory<AdventureWorks2019Context> _dbContextFactory;
        private IMapper _mapper;

        public ProductInventoryByLocationIdDataLoader(
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

        protected override async Task<IReadOnlyDictionary<short, ProductInventoryDto>> LoadBatchAsync(
            IReadOnlyList<short> keys,
            CancellationToken cancellationToken)
        {
            await using AdventureWorks2019Context dbContext =
                _dbContextFactory.CreateDbContext();

            return await dbContext.ProductInventories
                .Where(p => keys.Contains(p.LocationId))
                .ProjectTo<ProductInventoryDto>(_mapper.ConfigurationProvider)
                .ToDictionaryAsync(p => p.LocationId, cancellationToken);
        }
    }
}
