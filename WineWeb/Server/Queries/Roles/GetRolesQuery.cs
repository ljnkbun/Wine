using AutoMapper;
using Core.Models.Responses;
using MediatR;
using WineWeb.Shared.Models.Roles;
using WineWeb.Shared.Parameters.Roles;
using WineWeb.Shared.Services;

namespace WineWeb.Server.Queries.Roles
{
    public class GetRolesQuery : IRequest<PagedResponse<IReadOnlyList<RoleModel>>>
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
    public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, PagedResponse<IReadOnlyList<RoleModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IRoleRepository _repository;
        public GetRolesQueryHandler(IMapper mapper,
            IRoleRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<RoleModel>>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<RoleParameter>(request);
            return await _repository.GetModelPagedReponseAsync<RoleParameter, RoleModel>(validFilter);
        }
    }
}
