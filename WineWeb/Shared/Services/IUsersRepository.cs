using Core.Repositories;
using WineWeb.Shared.Entities;

namespace WineWeb.Shared.Services
{
    public interface IUsersRepository : IGenericRepositoryAsync<Users>
    {
        Task<Users> Authen(string username, string password);
        Task<Users> GetDeepByIdAsync(int id);
        Task UpdateUserAsync(Users entity);
    }
}
