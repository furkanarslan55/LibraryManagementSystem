using System.Security.Claims;
using LibraryProject.DataAccess.Abstract;

namespace LibraryProject.API.Services
{
    // Bu sınıf API katmanında olduğu için HttpContext'e erişebilir!
    public class AuthenticatedUserService : IAuthenticatedUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthenticatedUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int? UserId
        {
            get
            {
                // Kullanıcı giriş yapmış mı? Token var mı?
                var userIdString = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (!string.IsNullOrEmpty(userIdString) && int.TryParse(userIdString, out int userId))
                {
                    return userId;
                }

                return null; // Giriş yapmamış veya sistem işlemi
            }
        }
    }
}