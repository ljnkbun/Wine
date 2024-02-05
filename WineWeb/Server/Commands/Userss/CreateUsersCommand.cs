using AutoMapper;
using Core.Models.Responses;
using MediatR;
using WineWeb.Shared.Entities;
using WineWeb.Shared.Services;

namespace WineWeb.Server.Commands.Userss
{
    public class CreateUsersCommand : IRequest<Response<int>>
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
    }
    public class CreateUsersCommandHandler : IRequestHandler<CreateUsersCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IUsersRepository _repository;
        public CreateUsersCommandHandler(IMapper mapper,
            IUsersRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateUsersCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Users>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
