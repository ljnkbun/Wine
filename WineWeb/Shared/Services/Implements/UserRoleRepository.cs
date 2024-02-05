using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Extensions.Objects;
using Core.Models.Parameters;
using Core.Models.Responses;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using WineWeb.Shared.Contexts;
using WineWeb.Shared.Entities;
using WineWeb.Shared.Models.UserRoles;

namespace WineWeb.Shared.Services.Implements
{
    public class UserRoleRepository : GenericRepositoryAsync<UserRole>, IUserRoleRepository
    {
        private readonly DbSet<UserRole> _userRole;
        public UserRoleRepository(WineContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _userRole = dbContext.Set<UserRole>();
        }

        public async Task<PagedResponse<IReadOnlyList<TModel>>> GetCustomModelPagedReponseAsync<TParam, TModel>(TParam parameter)
            where TParam : RequestParameter
            where TModel : UserRoleModel
        {
            var response = new PagedResponse<IReadOnlyList<TModel>>(parameter.PageNumber, parameter.PageSize);
            var query = _dbContext.Set<UserRole>().Filter(parameter);
            response.TotalCount = await query.GroupBy(x => x.UsersId).CountAsync();

            var datas = await query.AsNoTracking()
                    .OrderBy(parameter.OrderBy)
                    .SearchTerm(parameter.SearchTerm, parameter.GetSearchProps())
                    .Paged(parameter.PageSize, parameter.PageNumber)
                    .ProjectTo<TModel>(_mapper.ConfigurationProvider)
                    .ToListAsync();

            var rs = new List<UserRoleModel>();

            var users = datas.GroupBy(x => x.UsersModel);
            foreach (var user in users)
            {
                rs.Add(new()
                {
                    UsersModel = user.Key,
                    RoleModels = user.SelectMany(x => x.RoleModels ?? default!).ToList()
                });
            }

            response.Data = (IReadOnlyList<TModel>)rs;
            return response;
        }

        public async Task<ICollection<UserRole>> GetDeepByIdAsync(int userId)
        {
            return await _userRole.Include(x => x.Users).Include(x => x.Role).Where(x => x.UsersId == userId).ToListAsync() ?? new();
        }
    }
}
