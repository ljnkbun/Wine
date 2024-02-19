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
        private readonly DbSet<UserRole> _userRole;
        public UsersRepository(WineContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _user = dbContext.Set<Users>();
            _userRole = dbContext.Set<UserRole>();
        }

        public async Task<Users> Authen(string username, string password)
        {
#if DEBUG
            if (username == "admin" && password == "admin")
            {
                return new Users() { Username = username, Password = password };
            }
#endif
            var user = await _user.FirstOrDefaultAsync(x => x.Username == username && x.Password == password);
            if (user != null) return user;

            return null!;
        }

        public async Task<Users> GetDeepByIdAsync(int id)
        {
            return await _user.Include(x => x.UserRoles).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateUserAsync(Users entity)
        {
            var tran = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                _user.Update(entity);
                _userRole.AddRange(entity.UserRoles);

                await _dbContext.SaveChangesAsync();
                await tran.CommitAsync();
            }
            catch (Exception ex)
            {
                await tran.RollbackAsync();
            }
        }
    }
}
