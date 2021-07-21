using AutoMapper;
using KommunikaciosTechnikak.Dal.Model;
using KommunikaciosTechnikak.GraphQL.HotChocolate.Dto;
using KommunikaciosTechnikak.GraphQL.HotChocolate.GraphQL.Product;

namespace KommunikaciosTechnikak.GraphQL.HotChocolate.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>();

            CreateMap<ProductInventory, ProductInventoryDto>();

            CreateMap<AddProductInput, Product>();
            CreateMap<UpdateProductInput, Product>();

            CreateMap<Location, LocationDto>();

            CreateMap<WorkOrder, WorkOrderDto>();
        }
    }
}
