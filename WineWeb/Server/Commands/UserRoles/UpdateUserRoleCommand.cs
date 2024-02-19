using AutoMapper;
using Core.Models.Responses;
using MediatR;
using WineWeb.Shared.Entities;
using WineWeb.Shared.Models.Roles;
using WineWeb.Shared.Models.Userss;
using WineWeb.Shared.Services;

namespace WineWeb.Server.Commands.UserRoles
{
    public class UpdateUserRoleCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public int? UsersId { get; set; }
        public int[]? RoleId { get; set; }
        public RoleModel[]? RoleModels { get; set; }
        public UsersModel? UsersModel { get; set; }
    }
    public class UpdateUserRoleCommandHandler : IRequestHandler<UpdateUserRoleCommand, Response<int>>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;

        public UpdateUserRoleCommandHandler(IUsersRepository usersRepository
            , IMapper mapper
            )
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(UpdateUserRoleCommand command, CancellationToken cancellationToken)
        {
            var entity = await _usersRepository.GetDeepByIdAsync(command.UsersId!.Value);
            if (entity == null) return new($"UserRole Not Found.");
            entity.Code = command.Code!;
            entity.Name = command.Name!;
            entity.UserRoles.Clear();
            foreach (var role in command.RoleModels!)
            {
                entity.UserRoles.Add(new()
                {
                    Code = new Guid().ToString(),
                    Name = new Guid().ToString(),
                    Users = _mapper.Map<Users>(command.UsersModel),
                    Role = _mapper.Map<Role>(role),
                });
            }
            await _usersRepository.UpdateUserAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
