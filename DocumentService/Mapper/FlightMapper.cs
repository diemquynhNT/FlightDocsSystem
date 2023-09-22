using AutoMapper;
using DocumentService.Dto;
using DocumentService.Model;

namespace DocumentService.Mapper
{
    public class FlightMapper:Profile
    {
        public FlightMapper() {

            CreateMap<FlightModel, Flight>()
            .ForMember(dest => dest.AirplaneNo, act => act.MapFrom(src => src.AirplaneNo))
            .ForMember(dest => dest.DepartureDate, act => act.MapFrom(src => src.DepartureDate))
            .ForMember(dest => dest.PointOfLoading, act => act.MapFrom(src => src.PointOfLoading))
            .ForMember(dest => dest.PointOfUnloading, act => act.MapFrom(src => src.PointOfUnloading));

        }
    }
}
