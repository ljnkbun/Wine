using Core.Entities;
using WineWeb.Shared.Models.Roles;
using WineWeb.Shared.Models.Userss;

namespace WineWeb.Shared.Models.UserRoles
{
    public class UserRoleModel : BaseModel
    {
        public UsersModel? UsersModel { get; set; }
        public int? UsersId { get; set; }
        public int[]? RoleIds { get; set; }
        public ICollection<RoleModel>? RoleModels { get; set; }
    }
}
