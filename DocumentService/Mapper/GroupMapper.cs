using AutoMapper;
using DocumentService.Dto;
using DocumentService.Model;

namespace DocumentService.Mapper
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
