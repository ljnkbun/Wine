using AutoMapper;
using WineWeb.Server.Commands.Roles;
using WineWeb.Server.Queries.Roles;
using WineWeb.Shared.Entities;
using WineWeb.Shared.Models.Roles;
using WineWeb.Shared.Parameters.Roles;

namespace WineWeb.Server.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleModel>()
                .ReverseMap();
            CreateMap<CreateRoleCommand, Role>().ReverseMap();
            CreateMap<GetRolesQuery, RoleParameter>().ReverseMap();
        }

    }
}
