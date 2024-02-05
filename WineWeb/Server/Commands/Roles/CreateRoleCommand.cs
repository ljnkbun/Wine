using AutoMapper;
using Core.Models.Responses;
using MediatR;
using WineWeb.Shared.Entities;
using WineWeb.Shared.Services;

namespace WineWeb.Server.Commands.Roles
{
    public class CreateRoleCommand : IRequest<Response<int>>
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
    }
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IRoleRepository _repository;
        public CreateRoleCommandHandler(IMapper mapper,
            IRoleRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Role>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
