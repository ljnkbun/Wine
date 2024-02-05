using AutoMapper;
using Core.Models.Responses;
using MediatR;
using WineWeb.Shared.Models.UserRoles;
using WineWeb.Shared.Parameters.UserRoles;
using WineWeb.Shared.Services;

namespace WineWeb.Server.Queries.UserRoles
{
    public class GetUserRolesQuery : IRequest<PagedResponse<IReadOnlyList<UserRoleModel>>>
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
    public class GetUserRolesQueryHandler : IRequestHandler<GetUserRolesQuery, PagedResponse<IReadOnlyList<UserRoleModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRoleRepository _repository;
        public GetUserRolesQueryHandler(IMapper mapper,
            IUserRoleRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<UserRoleModel>>> Handle(GetUserRolesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<UserRoleParameter>(request);
            return await _repository.GetCustomModelPagedReponseAsync<UserRoleParameter, UserRoleModel>(validFilter);
        }
    }
}
