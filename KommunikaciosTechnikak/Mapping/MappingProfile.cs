using AutoMapper;
using KommunikaciosTechnikak.Dal.Model;
using KommunikaciosTechnikak.OData.Dto;

namespace KommunikaciosTechnikak.OData.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>();
        }
    }
}
