using Core.Models.Responses;
using MediatR;
using WineWeb.Shared.Services;

namespace WineWeb.Server.Commands.Roles
{
    public class UpdateRoleCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, Response<int>>
    {
        private readonly IRoleRepository _repository;
        public UpdateRoleCommandHandler(IRoleRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateRoleCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"Role Not Found.");
            entity.Code = command.Code;
            entity.Name = command.Name;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
