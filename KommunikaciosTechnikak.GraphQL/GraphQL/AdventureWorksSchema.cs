using GraphQL.Types;
using GraphQL.Utilities;
using Microsoft.AspNetCore.Authorization;
using System;

namespace KommunikaciosTechnikak.GraphQL.GraphQL
{
    [Authorize]
    public class AdventureWorksSchema : Schema
    {
        public AdventureWorksSchema(IServiceProvider provider)
            : base(provider)
        {
            Query = provider.GetRequiredService<AdventureWorksQuery>();
            Mutation = provider.GetRequiredService<AdventureWorksMutation>();
        }
    }
}
