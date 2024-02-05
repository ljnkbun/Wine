using AutoMapper;
using WineWeb.Server.Commands.UserRoles;
using WineWeb.Server.Queries.UserRoles;
using WineWeb.Shared.Entities;
using WineWeb.Shared.Models.UserRoles;
using WineWeb.Shared.Parameters.UserRoles;

namespace WineWeb.Server.Mappings
{
    public class UserRoleProfile : Profile
    {
        public UserRoleProfile()
        {
            CreateMap<UserRole, UserRoleModel>()
                .ReverseMap();
            CreateMap<CreateUserRoleCommand, UserRole>().ReverseMap();
            CreateMap<GetUserRolesQuery, UserRoleParameter>().ReverseMap();
        }

    }
}
