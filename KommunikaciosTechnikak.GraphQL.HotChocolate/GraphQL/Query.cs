using AutoMapper;
using AutoMapper.QueryableExtensions;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using KommunikaciosTechnikak.Dal.Model;
using KommunikaciosTechnikak.GraphQL.HotChocolate.Auth;
using KommunikaciosTechnikak.GraphQL.HotChocolate.Dto;
using KommunikaciosTechnikak.GraphQL.HotChocolate.Extensions;
using KommunikaciosTechnikak.GraphQL.HotChocolate.GraphQL.Types;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using UseFilteringAttribute = HotChocolate.Data.UseFilteringAttribute;
using UseSortingAttribute = HotChocolate.Data.UseSortingAttribute;

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.GraphQL
{
    public class Query
    {       
        [UseApplicationDbContext]
        [UsePaging(typeof(NonNullType<ProductType>))]
        [UseProjection]
        [UseFiltering(typeof(ProductFilterInputType))]
        [UseSorting]
        public IQueryable<ProductDto> GetProducts(
            [ScopedService] AdventureWorks2019Context context,
            [Service] IMapper mapper)
        {
            return context.Products.ProjectTo<ProductDto>(mapper.ConfigurationProvider);
        }

        [UseApplicationDbContext]
        [UseFirstOrDefault]
        [UseProjection]
        [UseFiltering(typeof(ProductFilterInputType))]
        public IQueryable<ProductDto> GetProduct(
            [ScopedService] AdventureWorks2019Context context,
            [Service] IMapper mapper)
        {
            return context.Products.ProjectTo<ProductDto>(mapper.ConfigurationProvider);
        }

        [Authorize]
        [UseApplicationDbContext]
        public IQueryable<WorkOrderDto> GetWorkOrders(
            [ScopedService] AdventureWorks2019Context context,
            [Service] IMapper mapper)
        {
            return context.WorkOrders.ProjectTo<WorkOrderDto>(mapper.ConfigurationProvider);
        }

        //public Task<ProductDto> GetProductAsync(
        //    int id,
        //    ProductByIdDataLoader dataLoader,
        //    CancellationToken cancellationToken) =>
        //    dataLoader.LoadAsync(id, cancellationToken);

        public string GetToken()
        {
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(Token.TokenSecret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var expires = DateTime.Now.AddYears(1);
            var notBefore = DateTime.Now;
            var token = new JwtSecurityToken(null, null, null, notBefore, expires, creds);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}
