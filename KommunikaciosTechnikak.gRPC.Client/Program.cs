using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using KommunikaciosTechnikak.gRPC.Client.Core;
using KommunikaciosTechnikak.gRPC.Client.Observers;
using System;
using System.Threading;
using System.Threading.Tasks;
using static KommunikaciosTechnikak.gRPC.Protos.ProductProtoService;

namespace KommunikaciosTechnikak.gRPC.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Thread.Sleep(10000);

            using var channel = GrpcChannel.ForAddress("https://localhost:5701");
            var client = new ProductProtoServiceClient(channel);

            var token = GetToken(client);

            await GetProductAsync(client, token);

            await GetAllProductsAsyncStream(client);

            // GetAllProductsObservable(client);

            // await AddProductAsync(client);

            // await UpdateProductAsync(client);

            // await DeleteProductAsync(client);

            // await InsertBulkProductAsync(client);

            await BiDirectionalInsertAsync(client);

            Console.ReadKey();
        }

        public static async Task GetProductAsync(ProductProtoServiceClient client, string token)
        {
            Console.WriteLine("GetProductAsync started...");

            var headers = new Metadata();
            headers.Add("Authorization", $"Bearer {token}");
            
            var response = await client.GetProductAsync(
                new Protos.GetProductRequest
                {
                    ProductId = 1
                },
                headers);

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
                // Feldolgozás...
            }
        }

        public static void GetAllProductsObservable(ProductProtoServiceClient client)
        {
            using var clientData = client.GetAllProductsStream(new Protos.GetAllProductsRequest());
            var observer = new GetAllProductsObserver();
            observer.Subscribe(clientData.ResponseStream.AsObservable());

            Thread.Sleep(5000);

            Console.WriteLine();
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
                        ProductNumber = "ABC-123",
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

        public static async Task InsertBulkProductAsync(ProductProtoServiceClient client)
        {
            Console.WriteLine("InsertBulkProductAsync started...");
            using var clientBulk = client.InsertBulkProduct();

            for (int i = 0; i < 5; i++)
            {
                var productModel = new Protos.ProductModel
                {
                    Name = $"Bulk Product {Guid.NewGuid()}",
                    ProductNumber = $"Bulk Product-2 {Guid.NewGuid()}",
                    SafetyStockLevel = 100,
                    ReorderPoint = 200,
                    DaysToManufacture = 10,
                    SellEndDate = Timestamp.FromDateTime(DateTime.UtcNow),
                    SellStartDate = Timestamp.FromDateTime(DateTime.UtcNow.AddYears(-1)),
                    DiscontinuedDate = Timestamp.FromDateTime(DateTime.UtcNow)
                };

                await clientBulk.RequestStream.WriteAsync(productModel);
            }

            await clientBulk.RequestStream.CompleteAsync();

            var responseBulk = await clientBulk;

            Console.WriteLine(responseBulk);
        }

        public static async Task BiDirectionalInsertAsync(ProductProtoServiceClient client)
        {
            using var streaming = client.BiDirectionalInsert();

            var readResponses = Task.Run(async () =>
            {
                while (await streaming.ResponseStream.MoveNext())
                {
                    var response = streaming.ResponseStream.Current;

                    if (response.Success)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;

                        Console.WriteLine($"Product with productNumber: {response.InsertedProductNumber} was inserted successfully," +
                            $" the generated ID is {response.InsertedProductId.Value}");

                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine($"Unexpected error while inserting product with productNumber: {response.InsertedProductNumber}" +
                            $",error message:{response.Error}");

                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            });

            for (int i = 0; i < 5; i++)
            {
                var productModel = new Protos.ProductModel
                {
                    Name = $"Bidirectional Product-4{i}",
                    ProductNumber = $"Bidirectional Product-4{i}",
                    SafetyStockLevel = 100,
                    ReorderPoint = 200,
                    DaysToManufacture = 10,
                    SellEndDate = Timestamp.FromDateTime(DateTime.UtcNow),
                    SellStartDate = Timestamp.FromDateTime(DateTime.UtcNow.AddYears(-1)),
                    DiscontinuedDate = Timestamp.FromDateTime(DateTime.UtcNow)
                };

                await streaming.RequestStream.WriteAsync(productModel);

                Console.WriteLine($"Insert request sent for product with productNumber: {productModel.ProductNumber}");
            }

            Thread.Sleep(20000);

            await streaming.RequestStream.CompleteAsync();
        }

        public static string GetToken(ProductProtoServiceClient client)
        {
            var response = client.GetToken(new Protos.GetTokenRequest());
            return response.Token;
        }
    }
}
