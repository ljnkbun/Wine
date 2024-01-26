using AutoMapper;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using WineWeb.Shared.Contexts;
using WineWeb.Shared.Entities;

namespace WineWeb.Shared.Services.Implements
{
    public class RoleRepository : GenericRepositoryAsync<Role>, IRoleRepository
    {
        private readonly DbSet<Role> _user;
        public RoleRepository(WineContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _user = dbContext.Set<Role>();
        }

    }
}
