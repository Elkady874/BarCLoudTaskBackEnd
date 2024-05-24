using AutoMapper;
using BarCLoudTaskBackEnd.DTOs.Polygon;
using BarCLoudTaskBackEnd.DTOs.Stock;
using BarCLoudTaskBackEnd.DTOs.User;
using BarCLoudTaskBackEnd.Entities;

namespace BarCLoudTaskBackEnd.Core
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BarCloudUserEntity, UserDTO>()
                    //.ForMember(dest => dest.RegisteredStock, opt => opt.MapFrom((src, dest, srcMember, context) => srcMember))
            .ReverseMap();
 
            CreateMap<BarCloudUserEntity, NewUserDTO>()
               // .ForMember(dest => dest.RegisteredStock, opt => opt.MapFrom((src, dest, srcMember, context) => srcMember))
              .ReverseMap();
            //            CreateMap<StockEntity, StockDTO>()
            //.ConstructUsing(ct => Mapper.Map<ICollection<BarCloudUserEntity>, List<UserDTO>>(ct.SubscribedUsers))
            //.ForAllMembers(opt => opt.Ignore());

            CreateMap<StockEntity, StockDTO>()
                    .ForMember(dest => dest.SubscribedUsers, opt => opt.MapFrom((src, dest, srcMember, context) =>srcMember))
            .ReverseMap();

        

            CreateMap<StockEntity, NewStockDTO>()
                     .ForMember(dest => dest.SubscribedUsers, opt => opt.MapFrom((src, dest, srcMember, context) => srcMember))

           .ReverseMap();



            CreateMap<PolygonTicker, NewStockDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
                .ForMember(dest => dest.Ticker, opt => opt.MapFrom(src => src.ticker))
                .ReverseMap();


        }
    }
}
