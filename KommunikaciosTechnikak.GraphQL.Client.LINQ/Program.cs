using AdventureWorks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KommunikaciosTechnikak.GraphQL.Client.LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var queryContext = new QueryContext();

            // Összes termék listázás
            //var products = queryContext.Products(null, null);

            // Projekció
            //var projectedProducts = queryContext.Products(null, null)
            //   .Select(p => new { p.ProductId, p.Name });

            //var productsWithInclude = queryContext.Products(null, null)
            //    .Include(p => p.ProductInventories)
            //    .Include(p => p.WorkOrders).ToList();

            //var multilevelInclude = queryContext.Products(null, null)
            //    .Include(p => p.ProductInventories)
            //    .Include(p => p.ProductInventories.Select(i => i.Location))
            //    .Include(p => p.WorkOrders).ToList();

            var searchQuery = queryContext.Products(new
                ProductDtoFilterInput
            {
                DaysToManufacture = new ComparableInt32OperationFilterInput { Lte = 10 },
                Name = new StringOperationFilterInput { Contains = "Product" },
                FinishedGoodsFlag = new BooleanOperationFilterInput { Eq = false },
                DiscontinuedDate = new ComparableNullableOfDateTimeOperationFilterInput
                {
                    Eq = new DateTimeOffset(2008, 4, 30, 12, 0, 0, TimeSpan.FromHours(0)).ToString()
                },
                ListPrice = new ComparableDecimalOperationFilterInput
                {
                    Lt = "1000",
                    Gt = "500"
                },
                Or = new List<ProductDtoFilterInput>
                {
                    new ProductDtoFilterInput
                    {
                        ProductNumber = new StringOperationFilterInput
                        {
                            Contains = "aa"
                        }
                    },
                    new ProductDtoFilterInput
                    {
                        MakeFlag = new BooleanOperationFilterInput
                        {
                            Eq = false
                        }
                    }
                },
                ReorderPoint = new ComparableInt16OperationFilterInput
                {
                    Gte = "10",
                    Lte = "5"
                }
            },
            new List<ProductDtoSortInput>
            {
                new ProductDtoSortInput
                {
                   ListPrice = SortEnumType.ASC
                },
                new ProductDtoSortInput
                {
                    Name = SortEnumType.DESC
                }
            });

            var queryString = searchQuery.ToString();

            var cucc = searchQuery.QueryVariables.Values;

            var searchResultProducts = searchQuery.ToList();

            //foreach (var product in searchQuery)
            //{
            //    Console.WriteLine(product.Name);
            //}


            Console.ReadKey();
        }
    }
}
