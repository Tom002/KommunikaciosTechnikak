using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using KommunikaciosTechnikak.Dal.Model;

namespace KommunikaciosTechnikak.gRPC.Mapping
{
    public class MappingProfile : Profile 
    {
        public MappingProfile()
        {
            CreateMap<Product, Protos.ProductModel>()
                .ForMember(dest => dest.DiscontinuedDate, opt =>
                    opt.MapFrom(src => src.DiscontinuedDate.HasValue
                        ? Timestamp.FromDateTime(src.DiscontinuedDate.Value.ToUniversalTime())
                        : default))
                .ForMember(dest => dest.SellEndDate, opt =>
                    opt.MapFrom(src => src.SellEndDate.HasValue
                        ? Timestamp.FromDateTime(src.SellEndDate.Value.ToUniversalTime())
                        : default))
                .ForMember(dest => dest.SellStartDate, opt =>
                    opt.MapFrom(src => Timestamp.FromDateTime(src.SellStartDate.ToUniversalTime())));

            CreateMap<Protos.ProductModel, Product>()
                 .ForMember(dest => dest.DiscontinuedDate, opt =>
                    opt.MapFrom(src => src.DiscontinuedDate != null
                        ? src.DiscontinuedDate.ToDateTime()
                        : default))
                 .ForMember(dest => dest.SellEndDate, opt =>
                    opt.MapFrom(src => src.SellEndDate != null
                        ? src.SellEndDate.ToDateTime()
                        : default))
                 .ForMember(dest => dest.SellStartDate, opt =>
                    opt.MapFrom(src => src.SellStartDate != null
                        ? src.SellStartDate.ToDateTime()
                        : default))
                 .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
