using Core.Entities;

namespace WineWeb.Shared.Entities
{
    public class UserRole : BaseEntity
    {
        public int UsersId { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public virtual Users Users { get; set; }
    }
}
