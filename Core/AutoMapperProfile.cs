using AutoMapper;
using BarCLoudTaskBackEnd.DTOs;
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
        }
    }
}
