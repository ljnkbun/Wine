using Core.Entities;

namespace WineWeb.Shared.Entities
{
    public class Users : BaseEntity
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public virtual ICollection<UserRole>? UserRoles { get; set; }
    }
}
