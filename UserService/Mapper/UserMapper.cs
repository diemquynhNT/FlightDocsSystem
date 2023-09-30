using AutoMapper;
using UserService.Dto;
using UserService.Model;

namespace UserService.Mapper
{
    public class UserMapper :Profile
    {
        public UserMapper() {
            CreateMap<UserModel, User>()
              .ForMember(dest => dest.nameUser, act => act.MapFrom(src => src.nameUser))
              .ForMember(dest => dest.phone, act => act.MapFrom(src => src.phone))
              .ForMember(dest => dest.emailAddress, act => act.MapFrom(src => src.emailAddress))
              .ForMember(dest => dest.userName, act => act.MapFrom(src => src.uerName))
              .ForMember(dest => dest.passWord, act => act.MapFrom(src => src.passWord))
              .ForMember(dest => dest.idGroup, act => act.MapFrom(src => src.idGroup));

        }
    }
}
