using Core.Models.Responses;
using MediatR;
using WineWeb.Shared.Services;

namespace WineWeb.Server.Commands.UserRoles
{
    public class DeleteUserRoleCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteUserRoleCommandHandler : IRequestHandler<DeleteUserRoleCommand, Response<int>>
    {
        private readonly IUserRoleRepository _repository;
        public DeleteUserRoleCommandHandler(IUserRoleRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteUserRoleCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"UserRole Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
