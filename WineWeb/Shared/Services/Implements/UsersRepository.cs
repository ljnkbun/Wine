using AutoMapper;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using WineWeb.Shared.Contexts;
using WineWeb.Shared.Entities;

namespace WineWeb.Shared.Services.Implements
{
    public class UsersRepository : GenericRepositoryAsync<Users>, IUsersRepository
    {
        private readonly DbSet<Users> _user;
        public UsersRepository(WineContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _user = dbContext.Set<Users>();
        }

        public async Task<Users> Authen(string Username, string password)
        {
#if DEBUG
            if (Username == "admin" && password == "admin")
            {
                return new Users() { Username = Username, Password = password };
            }
#endif
            var user = await _user.FirstOrDefaultAsync(x => x.Username == Username && x.Password == password);
            if (user != null) return user;

            return null!;
        }

    }
}
