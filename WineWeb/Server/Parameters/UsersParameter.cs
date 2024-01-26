using Core.Models.Parameters;

namespace WineWeb.Server.Parameters
{
    public class UsersParameter : RequestParameter
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
