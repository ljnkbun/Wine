using Core.Models.Responses;
using MediatR;
using WineWeb.Shared.Services;

namespace WineWeb.Server.Commands.Userss
{
    public class UpdateUsersCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
    }
    public class UpdateUsersCommandHandler : IRequestHandler<UpdateUsersCommand, Response<int>>
    {
        private readonly IUsersRepository _repository;
        public UpdateUsersCommandHandler(IUsersRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateUsersCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"Users Not Found.");
            entity.Code = command.Code!;
            entity.Name = command.Name!;
            entity.UserName = command.Username!;
            entity.Password = command.Password!;
            entity.Email = command.Email!;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
