using GraphQL.Types;

namespace KommunikaciosTechnikak.GraphQL.GraphQL.Types
{
    public class ProductFilterType : InputObjectGraphType
    {
        public ProductFilterType()
        {
            Name = "productFilter";
            Field<StringGraphType>("name");
            Field<StringGraphType>("productNumber");
            Field<DateGraphType>("sellStartDate");
            Field<DateGraphType>("sellEndDate");
        }
    }
}
