using Core.Entities;

namespace WineWeb.Shared.Models.Userss
{
    public class UsersModel : BaseModel
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
    }
}
