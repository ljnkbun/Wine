using Core.Models.Responses;
using MediatR;
using WineWeb.Shared.Services;

namespace WineWeb.Server.Commands.Userss
{
    public class DeleteUsersCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteUsersCommandHandler : IRequestHandler<DeleteUsersCommand, Response<int>>
    {
        private readonly IUsersRepository _repository;
        public DeleteUsersCommandHandler(IUsersRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteUsersCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"Users Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
