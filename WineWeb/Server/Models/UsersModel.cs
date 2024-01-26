using Core.Entities;

namespace WineWeb.Server.Models
{
    public class UsersModel : BaseModel
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
