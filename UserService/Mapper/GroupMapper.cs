using AutoMapper;
using UserService.Dto;
using UserService.Model;

namespace UserService.Mapper
{
    public class GroupMapper:Profile
    {
        public GroupMapper() {
            CreateMap<GroupsModel, Groups>()
               .ForMember(dest => dest.nameGroup, act => act.MapFrom(src => src.nameGroup))
               .ForMember(dest => dest.note, act => act.MapFrom(src => src.note));
        }
    }
}
