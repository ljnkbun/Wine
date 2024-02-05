using AutoMapper;
using Core.Models.Responses;
using MediatR;
using WineWeb.Shared.Models.Roles;
using WineWeb.Shared.Models.UserRoles;
using WineWeb.Shared.Models.Userss;
using WineWeb.Shared.Services;

namespace WineWeb.Server.Queries.UserRoles
{
    public class GetUserRoleQuery : IRequest<Response<UserRoleModel>>
    {
        public int UserId { get; set; }
    }
    public class GetUserRoleQueryHandler : IRequestHandler<GetUserRoleQuery, Response<UserRoleModel>>
    {
        private readonly IUserRoleRepository _repository;
        private readonly IMapper _mapper;

        public GetUserRoleQueryHandler(
            IUserRoleRepository repository
            , IMapper mapper
            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<UserRoleModel>> Handle(GetUserRoleQuery request, CancellationToken cancellationToken)
        {
            var userRoles = await _repository.GetDeepByIdAsync(request.UserId);
            if (userRoles.Any()) return new Response<UserRoleModel>(new UserRoleModel());

            var rs = new UserRoleModel()
            {
                UsersModel = _mapper.Map<UsersModel>(userRoles.FirstOrDefault()?.Users ?? new()),
                RoleModels = _mapper.Map<ICollection<RoleModel>>(userRoles.Select(x => x.Role))
            };

            return new Response<UserRoleModel>(rs);
        }
    }
}
