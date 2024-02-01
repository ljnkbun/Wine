using AutoMapper;
using Core.Models.Responses;
using MediatR;
using WineWeb.Shared.Models.Locations;
using WineWeb.Shared.Parameters.Locations;
using WineWeb.Shared.Services;

namespace WineWeb.Server.Queries.Locations
{
    public class GetLocationsQuery : IRequest<PagedResponse<IReadOnlyList<LocationModel>>>
    {
        public int? PageNumber { get; set; } = 1;
        public int? PageSize { get; set; } = 10;

        public string? Code { get; set; }
        public string? Name { get; set; }

        public string? OrderBy { get; set; } = "Id DESC";
        public string? SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
    }
    public class GetLocationsQueryHandler : IRequestHandler<GetLocationsQuery, PagedResponse<IReadOnlyList<LocationModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ILocationRepository _repository;
        public GetLocationsQueryHandler(IMapper mapper,
            ILocationRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<LocationModel>>> Handle(GetLocationsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<LocationParameter>(request);
            return await _repository.GetModelPagedReponseAsync<LocationParameter, LocationModel>(validFilter);
        }
    }
}
