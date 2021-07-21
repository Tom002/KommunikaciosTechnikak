using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using static KommunikaciosTechnikak.gRPC.Protos.ProductProtoService;

namespace KommunikaciosTechnikak.gRPC.Web.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Thread.Sleep(10000);

            var channel = GrpcChannel.ForAddress("https://localhost:5701", new GrpcChannelOptions
            {
                HttpHandler = new GrpcWebHandler(new HttpClientHandler())
            });
            var client = new ProductProtoServiceClient(channel);

            await GetProductAsync(client);

            // await GetAllProductsAsyncStream(client);

            // GetAllProductsObservable(client);

            // await AddProductAsync(client);

            // await UpdateProductAsync(client);

            // await DeleteProductAsync(client);

            // await InsertBulkProductAsync(client);

            Console.ReadKey();
        }

        public static async Task GetProductAsync(ProductProtoServiceClient client)
        {
            Console.WriteLine("GetProductAsync started...");

            var response = await client.GetProductAsync(
                new Protos.GetProductRequest
                {
                    ProductId = 1
                });

            Console.WriteLine($"GetProductAsync response: {response}");
        }

        public static async Task GetAllProductsRepeatedFieldAsync(ProductProtoServiceClient client)
        {
            Console.WriteLine("GetAllProducts started...");

            var products = await client.GetAllProductsAsync(new Protos.GetAllProductsRequest());
            Console.WriteLine(products);

            Console.WriteLine("GetAllProducts finished");
        }

        public static async Task GetAllProductsStreamAsync(ProductProtoServiceClient client)
        {
            Console.WriteLine("GetAllProductsStream started...");
            using (var clientData = client.GetAllProductsStream(new Protos.GetAllProductsRequest()))
            {
                while (await clientData.ResponseStream.MoveNext(new CancellationToken()))
                {
                    var currentProduct = clientData.ResponseStream.Current;
                    Console.WriteLine(currentProduct);
                }
            }
            Console.WriteLine("GetAllProductsStream finished");
        }

        public static async Task GetAllProductsAsyncStream(ProductProtoServiceClient client)
        {
            using var clientData = client.GetAllProductsStream(new Protos.GetAllProductsRequest());
            await foreach (var responseData in clientData.ResponseStream.ReadAllAsync())
            {
                Console.WriteLine(responseData);
            }
        }


        public static async Task AddProductAsync(ProductProtoServiceClient client)
        {
            Console.WriteLine("AddProductAsync started...");

            var addProductResponse = await client.AddProductAsync(
                new Protos.AddProductRequest
                {
                    Product = new Protos.ProductModel
                    {
                        Name = "New Product",
                        ProductNumber = "ASDAFA-12121",
                        SafetyStockLevel = 100,
                        ReorderPoint = 200,
                        DaysToManufacture = 10,
                        SellEndDate = Timestamp.FromDateTime(DateTime.UtcNow),
                        SellStartDate = Timestamp.FromDateTime(DateTime.UtcNow.AddYears(-1)),
                        DiscontinuedDate = Timestamp.FromDateTime(DateTime.UtcNow)
                    }
                });

            Console.WriteLine($"AddProductAsync response: {addProductResponse}");
        }

        public static async Task UpdateProductAsync(ProductProtoServiceClient client)
        {
            Console.WriteLine("UpdateProductAsync started...");

            var updateProductResponse = await client.UpdateProductAsync(
                new Protos.UpdateProductRequest
                {
                    Product = new Protos.ProductModel
                    {
                        ProductId = 1,
                        Name = "Updated Product",
                        ProductNumber = "asdadas-12121",
                        SafetyStockLevel = 100,
                        ReorderPoint = 200,
                        DaysToManufacture = 10,
                        SellEndDate = Timestamp.FromDateTime(DateTime.UtcNow),
                        SellStartDate = Timestamp.FromDateTime(DateTime.UtcNow.AddYears(-1)),
                        DiscontinuedDate = Timestamp.FromDateTime(DateTime.UtcNow),
                        FinishedGoodsFlag = false
                    }
                });

            Console.WriteLine(updateProductResponse);
        }

        public static async Task DeleteProductAsync(ProductProtoServiceClient client)
        {
            Console.WriteLine("DeleteProductAsync started...");

            var deleteProductResponse = await client.DeleteProductAsync(
                new Protos.DeleteProductRequest
                {
                    ProductId = 2
                });

            Console.WriteLine($"DeleteProductAsync response: {deleteProductResponse}");
        }

    }
}
