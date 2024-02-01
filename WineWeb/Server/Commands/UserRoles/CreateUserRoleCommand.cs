using AutoMapper;
using Core.Models.Responses;
using MediatR;
using WineWeb.Shared.Entities;
using WineWeb.Shared.Services;

namespace WineWeb.Server.Commands.UserRoles
{
    public class CreateUserRoleCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class CreateUserRoleCommandHandler : IRequestHandler<CreateUserRoleCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRoleRepository _repository;
        public CreateUserRoleCommandHandler(IMapper mapper,
            IUserRoleRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<UserRole>(request);
            await _repository.AddAsync(entity);
            return new Response<int>(entity.Id);
        }
    }
}
