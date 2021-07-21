using System;

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.GraphQL.Product
{
    public record UpdateProductInput(
        int ProductId,
        string Name,
        string ProductNumber,
        bool MakeFlag,
        bool FinishedGoodsFlag,
        short SafetyStockLevel,
        short ReorderPoint,
        decimal StandardCost,
        decimal ListPrice,
        int DaysToManufacture,
        DateTime SellStartDate);
}
