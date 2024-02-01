using Core.Models.Responses;
using MediatR;
using WineWeb.Shared.Services;

namespace WineWeb.Server.Commands.Locations
{
    public class UpdateLocationCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand, Response<int>>
    {
        private readonly ILocationRepository _repository;
        public UpdateLocationCommandHandler(ILocationRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<int>> Handle(UpdateLocationCommand command, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(command.Id);
            if (entity == null) return new($"Location Not Found.");
            entity.Code = command.Code;
            entity.Name = command.Name;

            await _repository.UpdateAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
