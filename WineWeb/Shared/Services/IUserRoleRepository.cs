using Core.Models.Parameters;
using Core.Models.Responses;
using Core.Repositories;
using WineWeb.Shared.Entities;
using WineWeb.Shared.Models.UserRoles;

namespace WineWeb.Shared.Services
{
    public interface IUserRoleRepository : IGenericRepositoryAsync<UserRole>
    {
        Task<PagedResponse<IReadOnlyList<TModel>>> GetCustomModelPagedReponseAsync<TParam, TModel>(TParam parameter)
            where TModel : UserRoleModel
            where TParam : RequestParameter;
        Task<ICollection<UserRole>> GetDeepByIdAsync(int userId);
    }
}
