namespace AdventureWorks
{
    using GraphQLinq;
    using System;
    using System.Collections.Generic;

    public class QueryContext : GraphContext
    {
        public QueryContext() : this("http://localhost:5000/graphql")
        {
        }

        public QueryContext(string baseUrl) : base(baseUrl, "")
        {
        }

        public GraphCollectionQuery<ProductDto> Products(ProductDtoFilterInput where, List<ProductDtoSortInput> order)
        {
            var parameterValues = new object[] { where, order };
            return BuildCollectionQuery<ProductDto>(parameterValues);
        }

        public GraphItemQuery<ProductDto> Product(ProductDtoFilterInput where, List<ProductDtoSortInput> order)
        {
            var parameterValues = new object[] { where, order };
            return BuildItemQuery<ProductDto>(parameterValues);
        }

        public GraphCollectionQuery<WorkOrderDto> WorkOrders()
        {
            var parameterValues = new object[] { };
            return BuildCollectionQuery<WorkOrderDto>(parameterValues);
        }

        public GraphItemQuery<string> Token()
        {
            var parameterValues = new object[] { };
            return BuildItemQuery<string>(parameterValues);
        }
    }
}