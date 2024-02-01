using Core.Models.Responses;
using MediatR;
using WineWeb.Shared.Services;

namespace WineWeb.Server.Commands.UserRoles
{
    public class UpdateUserRoleCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class UpdateUserRoleCommandHandler : IRequestHandler<UpdateUserRoleCommand, Response<int>>
    {
        private readonly IUserRoleRepository _repository;
        public UpdateUserRoleCommandHandler(IUserRoleRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateUserRoleCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"UserRole Not Found.");
            entity.Code = command.Code;
            entity.Name = command.Name;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
