using AutoMapper;
using Core.Models.Responses;
using MediatR;
using WineWeb.Shared.Entities;
using WineWeb.Shared.Services;

namespace WineWeb.Server.Queries.Locations
{
    public class GetLocationQuery : IRequest<Response<Shared.Entities.Locations>>
    {
        public int Id { get; set; }
    }
    public class GetLocationQueryHandler : IRequestHandler<GetLocationQuery, Response<Shared.Entities.Locations>>
    {
        private readonly ILocationRepository _repository;
        private readonly IMapper _mapper;

        public GetLocationQueryHandler(
            ILocationRepository repository
            , IMapper mapper
            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<Shared.Entities.Locations>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.Id);
            return new Response<Shared.Entities.Locations>(user ?? new());
        }
    }
}
