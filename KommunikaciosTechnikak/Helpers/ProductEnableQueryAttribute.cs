using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Http;

namespace KommunikaciosTechnikak.OData.Helpers
{
    public class ProductEnableQueryAttribute : EnableQueryAttribute
    {
        public override void ValidateQuery(HttpRequest request, ODataQueryOptions queryOptions)
        {
            if (queryOptions.Filter != null)
            {
                queryOptions.Filter.Validator = new ProductFilterQueryValidator(new DefaultQuerySettings());
            }

            base.ValidateQuery(request, queryOptions);
        }
    }
}
