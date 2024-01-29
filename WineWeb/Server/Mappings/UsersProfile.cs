using AutoMapper;
using WineWeb.Server.Commands.Userss;
using WineWeb.Server.Models;
using WineWeb.Server.Parameters;
using WineWeb.Server.Queries.Userss;
using WineWeb.Shared.Entities;

namespace WineWeb.Server.Mappings
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<Users, UsersModel>()
                .ReverseMap();
            CreateMap<CreateUsersCommand, Users>().ReverseMap();
            CreateMap<GetUserssQuery, UsersParameter>().ReverseMap();
        }

    }
}
