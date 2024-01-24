using Domain.Entities;

namespace Domain.Services
{
    public interface IUsersRepository
    {
        Task<Users> Authen(string username, string password);
    }
}
