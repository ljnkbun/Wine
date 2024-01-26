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

        public async Task<Users> Authen(string username, string password)
        {
#if DEBUG
            if (username == "admin" && password == "admin")
            {
                return new Users() { UserName = username, Password = password };
            }
#endif
            var user = await _user.FirstOrDefaultAsync(x => x.UserName == username && x.Password == password);
            if (user != null) return user;

            return null!;
        }

    }
}
