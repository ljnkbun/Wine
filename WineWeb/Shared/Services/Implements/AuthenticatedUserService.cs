using Microsoft.AspNetCore.Http;

namespace WineWeb.Shared.Services.Implements
{
    public class AuthenticatedUserService : IAuthenticatedUserService
    {
        public AuthenticatedUserService(IHttpContextAccessor httpContextAccessor)
        {
            var uid = httpContextAccessor.HttpContext?.User?.FindFirst("uid")?.Value;
            if (!string.IsNullOrEmpty(uid)) UserId = 1;
        }

        public int? UserId { get; }
    }
}
