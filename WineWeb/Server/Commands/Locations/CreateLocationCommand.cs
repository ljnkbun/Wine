using AutoMapper;
using Core.Models.Responses;
using MediatR;
using WineWeb.Shared.Entities;
using WineWeb.Shared.Services;

namespace WineWeb.Server.Commands.Locations
{
    public class CreateLocationCommand : IRequest<Response<int>>
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
    }
    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly ILocationRepository _repository;
        public CreateLocationCommandHandler(IMapper mapper,
            ILocationRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Shared.Entities.Locations>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
