using AutoMapper;
using DocumentService.Dto;
using DocumentService.Model;

namespace DocumentService.Mapper
{
    public class DocumentMapper:Profile
    {
        public DocumentMapper() {
            CreateMap<DocumentFileVM, Documents>()
            .ForMember(dest => dest.NameDoc, act => act.MapFrom(src => src.NameDoc))
            .ForMember(dest => dest.Note, act => act.MapFrom(src => src.Note))
            .ForMember(dest => dest.IdType, act => act.MapFrom(src => src.IdType));
        }
    }
}
