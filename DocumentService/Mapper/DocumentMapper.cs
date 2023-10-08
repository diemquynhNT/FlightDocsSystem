using AutoMapper;
using DocumentService.Dto;
using DocumentService.Model;

namespace DocumentService.Mapper
{
    public class DocumentMapper:Profile
    {
        public DocumentMapper() {
            CreateMap<DocumentFileVM, DocumentsFlight>()
            .ForMember(dest => dest.NameDoc, act => act.MapFrom(src => src.NameDoc))
            .ForMember(dest => dest.Note, act => act.MapFrom(src => src.Note))
            .ForMember(dest => dest.IdType, act => act.MapFrom(src => src.IdType));

            CreateMap<DocumentsFlight, DocumentVM>()
            .ForMember(dest => dest.NameDoc, act => act.MapFrom(src => src.NameDoc))
            .ForMember(dest => dest.Note, act => act.MapFrom(src => src.Note))
            .ForMember(dest => dest.IdDocument, act => act.MapFrom(src => src.IdDocument))
            .ForMember(dest => dest.CreateDate, act => act.MapFrom(src => src.CreateDate))
            .ForMember(dest => dest.version, act => act.MapFrom(src => src.version));
        }
    }
}
