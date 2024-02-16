using AutoMapper;
using Core.Models.Responses;
using MediatR;
using WineWeb.Shared.Entities;
using WineWeb.Shared.Models.Roles;
using WineWeb.Shared.Models.Userss;
using WineWeb.Shared.Services;

namespace WineWeb.Server.Commands.UserRoles
{
    public class CreateUserRoleCommand : IRequest<Response<int>>
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public int? UsersId { get; set; }
        public int[]? RoleId { get; set; }
        public RoleModel[]? RoleModels { get; set; }
        public UsersModel? UsersModel { get; set; }
    }
    public class CreateUserRoleCommandHandler : IRequestHandler<CreateUserRoleCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRoleRepository _repository;
        public CreateUserRoleCommandHandler(IMapper mapper,
            IUserRoleRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
        {
            var entities = new List<UserRole>();
            foreach (var role in request.RoleModels)
            {
                var entity = _mapper.Map<UserRole>(request);
                //entity.Role = _mapper.Map<Role>(role);
                entity.Users = null;
                entity.Role = null;
                entities.Add(entity);
            }
            await _repository.AddRangeAsync(entities);
            return new Response<int>(entities.FirstOrDefault()!.UsersId);
        }
    }
}
