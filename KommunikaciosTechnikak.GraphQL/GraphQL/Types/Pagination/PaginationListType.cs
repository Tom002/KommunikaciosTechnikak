using GraphQL.Types;
using KommunikaciosTechnikak.GraphQL.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KommunikaciosTechnikak.GraphQL.GraphQL.Types.Pagination
{
    public class PaginationListType<T, U> : ObjectGraphType<PaginationList<U>> where T : IGraphType
    {
        public PaginationListType()
        {
            Name = String.Format("PaginationList{0}", typeof(U).Name);

            Field(x => x.Total).Description("Total");
            Field(x => x.Size).Description("Size");
            Field(x => x.Index).Description("Index");
            Field(x => x.Pages).Description("Pages");
            Field<ListGraphType<T>>(
                name: "Data",
                description: "Data",
                resolve: context => context.Source.Data
            );
        }
    }
}
