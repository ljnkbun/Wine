using Core.Models.Responses;
using MediatR;
using WineWeb.Shared.Services;

namespace WineWeb.Server.Commands.Roles
{
    public class DeleteRoleCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, Response<int>>
    {
        private readonly IRoleRepository _repository;
        public DeleteRoleCommandHandler(IRoleRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteRoleCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"Role Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
