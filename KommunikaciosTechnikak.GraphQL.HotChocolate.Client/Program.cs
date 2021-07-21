using Microsoft.Extensions.DependencyInjection;
using StrawberryShake;
using StrawberryShake.Extensions;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Client
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddWebSocketClient(
                "AdventureWorksClient",
                c => c.Uri = new Uri("ws://localhost:5000/graphql"));

            serviceCollection.AddHttpClient(
                "AdventureWorksClient",
                c =>
                {
                    c.BaseAddress = new Uri("http://localhost:5000/graphql");
                    c.DefaultRequestHeaders.Authorization
                        = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJuYmYiOjE2MTkwOTAwNTksImV4cCI6MTY1MDYyNjA1OX0.o2-P4rHvB5buoKriRonWCYByoHxvsAnRTPmuMofxtQgvSv2zAdPXlr5PKDHk94JVLl7wD-Ln2S7aTwvzYw1DXg");
                });

            //serviceCollection.AddAdventureWorksClient();

            //IServiceProvider services = serviceCollection.BuildServiceProvider();
            //IAdventureWorksClient client = services.GetRequiredService<IAdventureWorksClient>();

            //// Termék listázás
            //var result = await client.GetProductsWithWorkOrders.ExecuteAsync();
            //result.EnsureNoErrors();
            //foreach (var product in result.Data.Products.Edges)
            //{
            //    Console.WriteLine(product.Node.Name);
            //}

            //// Termék hozzáadás
            //var addResult = await client.AddProduct.ExecuteAsync(
            //    "Teszt termék",
            //    "12121212",
            //    false,
            //    false,
            //    100,
            //    200,
            //    1000,
            //    750,
            //    10,
            //    new DateTimeOffset(2020, 10, 10, 0, 0, 0, TimeSpan.FromHours(1)));

            //Console.WriteLine($"Added product: {addResult.Data.AddProduct.Product.Name}");

            //// Termék update
            //var updateResult = await client.UpdateProduct.ExecuteAsync(
            //    1,
            //    "Teszt termék 2",
            //    "1231ASDA",
            //    false,
            //    false,
            //    100,
            //    200,
            //    1000,
            //    750,
            //    10,
            //    new DateTimeOffset(2020, 10, 10, 0, 0, 0, TimeSpan.FromHours(1)));

            //Console.WriteLine($"Updated product: {addResult.Data.AddProduct.Product.Name}");

            //var session = client
            //        .OnProductAdded
            //        .Watch()
            //        .Subscribe(result =>
            //        {
            //            Console.WriteLine($"New product added with name: {result.Data.OnProductAdded.Name}");
            //        });

            //Console.WriteLine("asda");
        }
    }
}
