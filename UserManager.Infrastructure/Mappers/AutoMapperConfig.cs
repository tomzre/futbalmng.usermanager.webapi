using AutoMapper;
using UserManager.Core.Domain;
using UserManager.Infrastructure.DTO;

namespace UserManager.Infrastructure.Mappers
{
    public class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration( cfg =>
            {
                cfg.CreateMap<User, UserDto>().ReverseMap();
                cfg.CreateMap<Avatar, AvatarDto>().ReverseMap();
            })
            .CreateMapper();
        
    }
}