using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Project.core.Services.ContentStorage
{
    public interface IUserInfo
    {
        string GetUserId();

    }

    public class UserInfo : IUserInfo
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserInfo(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }
        public string GetUserId()
        {
            var userIdClaim = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null)
            {
                return userIdClaim.Value;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
