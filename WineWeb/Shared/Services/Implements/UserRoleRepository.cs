using AutoMapper;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using WineWeb.Shared.Contexts;
using WineWeb.Shared.Entities;

namespace WineWeb.Shared.Services.Implements
{
    public class UserRoleRepository : GenericRepositoryAsync<UserRole>, IUserRoleRepository
    {
        private readonly DbSet<UserRole> _user;
        public UserRoleRepository(WineContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _user = dbContext.Set<UserRole>();
        }

    }
}
