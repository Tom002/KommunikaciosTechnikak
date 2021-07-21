using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using KommunikaciosTechnikak.Dal.Model;
using KommunikaciosTechnikak.gRPC.Protos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static KommunikaciosTechnikak.gRPC.Protos.ProductProtoService;

namespace KommunikaciosTechnikak.gRPC.Web.Services
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
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.ProductId == request.ProductId);

            if (product == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Product with ID={request.ProductId} was not found"));
            }

            var response = _mapper.Map<Protos.ProductModel>(product);
            return response;
        }

        public override async Task GetAllProductsStream(
            GetAllProductsRequest request,
            IServerStreamWriter<Protos.ProductModel> responseStream,
            ServerCallContext context)
        {
            var products = await _context.Products
                .Take(10)
                .ToListAsync();

            foreach (var product in products)
            {
                var productModel = _mapper.Map<Protos.ProductModel>(product);
                await responseStream.WriteAsync(productModel);
            }
        }

        public override async Task<GetAllProductsResponse> GetAllProducts(
            GetAllProductsRequest request,
            ServerCallContext context)
        {
            var products = await _context.Products.Take(10).ToListAsync();
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
    }
}
