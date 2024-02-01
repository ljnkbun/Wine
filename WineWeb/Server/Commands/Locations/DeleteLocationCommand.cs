using Core.Models.Responses;
using MediatR;
using WineWeb.Shared.Services;

namespace WineWeb.Server.Commands.Locations
{
    public class DeleteLocationCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand, Response<int>>
    {
        private readonly ILocationRepository _repository;
        public DeleteLocationCommandHandler(ILocationRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(DeleteLocationCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"Location Not Found (Id:{command.Id}).");
            await _repository.DeleteAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
