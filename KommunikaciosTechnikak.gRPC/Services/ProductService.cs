using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using KommunikaciosTechnikak.Dal.Model;
using KommunikaciosTechnikak.gRPC.Auth;
using KommunikaciosTechnikak.gRPC.Protos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using static KommunikaciosTechnikak.gRPC.Protos.ProductProtoService;

namespace KommunikaciosTechnikak.gRPC.Services
{
    public class ProductService : ProductProtoServiceBase
    {
        private readonly AdventureWorks2019Context _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public ProductService(
            AdventureWorks2019Context context,
            IMapper mapper,
            ILogger<ProductService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public override Task<Empty> Test(Empty request, ServerCallContext context)
        {
            return base.Test(request, context);
        }

        public override async Task<Protos.ProductModel> GetProduct(
            GetProductRequest request,
            ServerCallContext context)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == request.ProductId);
            if(product == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Product with ID={request.ProductId} was not found"));
            }

            var response = _mapper.Map<Protos.ProductModel>(product);            
            return response;
        }

        public override async Task<GetAllProductsResponse> GetAllProducts(
            GetAllProductsRequest request,
            ServerCallContext context)
        {
            var products = await _context.Products.ToListAsync();
            var productModels = _mapper.Map<List<Protos.ProductModel>>(products);

            return new GetAllProductsResponse
            {
                Products = { productModels }
            };
        }

        public override async Task<Protos.ProductModel> AddProduct(AddProductRequest request, ServerCallContext context)
        {
            try
            {
                var productToAdd = _mapper.Map<Product>(request.Product);

                _context.Products.Add(productToAdd);

                await _context.SaveChangesAsync();

                return _mapper.Map<Protos.ProductModel>(productToAdd);
            }
            catch (Exception e)
            {
                throw new RpcException(new Status(StatusCode.Internal, e.Message));
            }
        }

        public override async Task<Protos.ProductModel> UpdateProduct(UpdateProductRequest request, ServerCallContext context)
        {
            try
            {
                var productToUpdate = await _context.Products.SingleOrDefaultAsync(p => p.ProductId == request.Product.ProductId);
                if (productToUpdate == null)
                {
                    throw new RpcException(new Status(StatusCode.NotFound, $"Product with ID={request.Product.ProductId} was not found"));
                }

                _mapper.Map(request.Product, productToUpdate);
                await _context.SaveChangesAsync();

                return _mapper.Map<Protos.ProductModel>(productToUpdate);
            }
            catch (Exception e)
            {
                throw new RpcException(new Status(StatusCode.Internal, e.Message));
            }
        }

        public override async Task<DeleteProductResponse> DeleteProduct(DeleteProductRequest request, ServerCallContext context)
        {
            try
            {
                var productToDelete = await _context.Products.SingleOrDefaultAsync(p => p.ProductId == request.ProductId);
                if (productToDelete == null)
                {
                    throw new RpcException(new Status(StatusCode.NotFound, $"Product with ID={request.ProductId} was not found"));
                }

                _context.Products.Remove(productToDelete);
                var deleteCount = await _context.SaveChangesAsync();

                return new DeleteProductResponse
                {
                    Success = deleteCount > 0
                };
            }
            catch (Exception e)
            {
                throw new RpcException(new Status(StatusCode.Internal, e.Message));
            }
        }

        public override async Task<InsertBulkProductResponse> InsertBulkProduct(IAsyncStreamReader<Protos.ProductModel> requestStream, ServerCallContext context)
        {
            try
            {
                while (await requestStream.MoveNext())
                {
                    var product = _mapper.Map<Product>(requestStream.Current);
                    _context.Products.Add(product);
                }

                var insertCount = await _context.SaveChangesAsync();
                var response = new InsertBulkProductResponse
                {
                    Success = insertCount > 0,
                    InsertCount = insertCount
                };

                return response;
            }
            catch (Exception e)
            {
                throw new RpcException(new Status(StatusCode.Internal, e.Message));
            }
        }

        public override Task<GetTokenResponse> GetToken(GetTokenRequest request, ServerCallContext context)
        {
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(Token.TokenSecret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var expires = DateTime.Now.AddYears(1);
            var notBefore = DateTime.Now;
            var token = new JwtSecurityToken(null, null, null, notBefore, expires, creds);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(token);

            var tcs = new TaskCompletionSource<GetTokenResponse>();

            var response = new GetTokenResponse
            {
                Token = tokenString
            };

            tcs.SetResult(response);
            return tcs.Task;
        }

        public override async Task BiDirectionalInsert(IAsyncStreamReader<Protos.ProductModel> requestStream, IServerStreamWriter<BiDirectionalInsertResponse> responseStream, ServerCallContext context)
        {
            while (await requestStream.MoveNext())
            {
                var productToInsert = requestStream.Current;
                try
                {
                    var product = _mapper.Map<Product>(productToInsert);

                    _context.Products.Add(product);
                    await _context.SaveChangesAsync();

                    var response = new BiDirectionalInsertResponse
                    {
                        Success = true,
                        InsertedProductId = product.ProductId,
                        InsertedProductNumber = product.ProductNumber
                    };

                    await responseStream.WriteAsync(response);
                }
                catch (Exception e)
                {
                    var response = new BiDirectionalInsertResponse
                    {
                        Success = false,
                        Error = e.Message,
                        InsertedProductNumber = productToInsert.ProductNumber
                    };

                    await responseStream.WriteAsync(response);
                }
            }
        }
    }
}
