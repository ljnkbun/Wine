using AutoMapper;
using Core.Models.Responses;
using MediatR;
using WineWeb.Server.Models;
using WineWeb.Server.Parameters;
using WineWeb.Shared.Services;

namespace WineWeb.Server.Queries
{
    public class GetUserssQuery : IRequest<PagedResponse<IReadOnlyList<UsersModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public string? Username { get; set; }
        public string? Password { get; set; }

        public string? OrderBy { get; set; }
        public string? SearchTerm { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedUserId { get; set; }
        public Guid? ModifiedUserId { get; set; }
        public bool? IsActive { get; set; }
    }
    public class GetUserssQueryHandler : IRequestHandler<GetUserssQuery, PagedResponse<IReadOnlyList<UsersModel>>>
    {
        private readonly IMapper _mapper;
        private readonly IUsersRepository _repository;
        public GetUserssQueryHandler(IMapper mapper,
            IUsersRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<IReadOnlyList<UsersModel>>> Handle(GetUserssQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<UsersParameter>(request);
            return await _repository.GetModelPagedReponseAsync<UsersParameter, UsersModel>(validFilter);
        }
    }
}
