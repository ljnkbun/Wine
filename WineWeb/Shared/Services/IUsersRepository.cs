using WineWeb.Shared.Entities;

namespace WineWeb.Shared.Services
{
    public interface IUsersRepository
    {
        Task<Users> Authen(string username, string password);
    }
}
