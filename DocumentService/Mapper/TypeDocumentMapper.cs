using AutoMapper;
using DocumentService.Dto;
using DocumentService.Model;

namespace DocumentService.Mapper
{
    public class TypeDocumentMapper : Profile
    {
        public TypeDocumentMapper()
        {

            CreateMap<TypeDocumentModel, TypeDocument>()
            .ForMember(dest => dest.TypeName, act => act.MapFrom(src => src.TypeName))
            .ForMember(dest => dest.Note, act => act.MapFrom(src => src.Note));
            
        }
    }
}
