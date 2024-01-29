using AutoMapper;
using Core.Models.Responses;
using MediatR;
using WineWeb.Shared.Entities;
using WineWeb.Shared.Services;

namespace WineWeb.Server.Queries.Userss
{
    public class GetUsersQuery : IRequest<Response<Users>>
    {
        public int Id { get; set; }
    }
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, Response<Users>>
    {
        private readonly IUsersRepository _repository;
        private readonly IMapper _mapper;

        public GetUsersQueryHandler(
            IUsersRepository repository
            , IMapper mapper
            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<Users>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.Id);
            return new Response<Users>(user ?? new());
        }
    }
}
