using AutoMapper;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using WineWeb.Shared.Contexts;
using WineWeb.Shared.Entities;

namespace WineWeb.Shared.Services.Implements
{
    public class LocationRepository : GenericRepositoryAsync<Locations>, ILocationRepository
    {
        private readonly DbSet<Locations> _user;
        public LocationRepository(WineContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _user = dbContext.Set<Locations>();
        }

    }
}
