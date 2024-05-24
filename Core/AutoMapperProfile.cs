using AutoMapper;
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
                .ReverseMap();

            CreateMap<BarCloudUserEntity, NewUserDTO>()
              .ReverseMap();

            CreateMap<StockEntity, StockDTO>()
           .ReverseMap();

            CreateMap<StockEntity, NewStockDTO>()
           .ReverseMap();
        }
    }
}
