using AutoMapper;
using Core.Models.Responses;
using MediatR;
using WineWeb.Shared.Entities;
using WineWeb.Shared.Services;

namespace WineWeb.Server.Queries.Roles
{
    public class GetRoleQuery : IRequest<Response<Role>>
    {
        public int Id { get; set; }
    }
    public class GetRoleQueryHandler : IRequestHandler<GetRoleQuery, Response<Role>>
    {
        private readonly IRoleRepository _repository;
        private readonly IMapper _mapper;

        public GetRoleQueryHandler(
            IRoleRepository repository
            , IMapper mapper
            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<Role>> Handle(GetRoleQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.Id);
            return new Response<Role>(user ?? new());
        }
    }
}
