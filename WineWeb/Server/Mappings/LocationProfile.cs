using AutoMapper;
using WineWeb.Server.Commands.Locations;
using WineWeb.Server.Queries.Locations;
using WineWeb.Shared.Entities;
using WineWeb.Shared.Models.Locations;
using WineWeb.Shared.Parameters.Locations;

namespace WineWeb.Server.Mappings
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<Locations, LocationModel>()
                .ReverseMap();
            CreateMap<CreateLocationCommand, Locations>().ReverseMap();
            CreateMap<GetLocationsQuery, LocationParameter>().ReverseMap();
        }

    }
}
