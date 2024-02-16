using Core.Repositories;
using WineWeb.Shared.Entities;

namespace WineWeb.Shared.Services
{
    public interface IUsersRepository : IGenericRepositoryAsync<Users>
    {
        Task<Users> Authen(string Username, string password);
    }
}
