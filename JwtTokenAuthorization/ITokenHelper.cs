using Microsoft.AspNetCore.Http;
using Repository.Models;
namespace JwtTokenAuthorization
{
    public interface ITokenHelper
    {
        public string GenerateToken(Admin user);
        public string GetUserIdFromToken(HttpContext httpContext);
    }
}
