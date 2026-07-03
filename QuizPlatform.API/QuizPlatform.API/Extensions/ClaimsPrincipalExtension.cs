using QuizPlatform.Core.Entities;
using System.Security.Claims;

namespace QuizPlatform.API.Extensions
{
    public static class ClaimsPrincipalExtension
    {
        public static Guid? GetUserId(this ClaimsPrincipal user)
        {
            var UserIdClaim = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Guid.TryParse(UserIdClaim, out var userId) ? userId : null;
        }
    }
}
