using AutoMapper;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using WineWeb.Shared.Contexts;
using WineWeb.Shared.Entities;

namespace WineWeb.Shared.Services.Implements
{
    public class LocationRepository : GenericRepositoryAsync<Location>, ILocationRepository
    {
        private readonly DbSet<Location> _user;
        public LocationRepository(WineContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _user = dbContext.Set<Location>();
        }

    }
}
