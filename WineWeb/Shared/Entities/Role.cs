using Core.Entities;

namespace WineWeb.Shared.Entities
{
    public class Role : BaseEntity
    {
        public virtual ICollection<UserRole>? UserRoles { get; set; }
    }
}
