using Microsoft.AspNetCore.Mvc;
using QuizPlatform.API.Extensions;

namespace QuizPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private Guid? _userId;
        public Guid UserId
        {
            get
            {
                if (_userId == null)
                {
                    _userId = User.GetUserId();
                }

                if (_userId == null)
                {
                    throw new UnauthorizedAccessException("User id not found in token");
                }

                return _userId.Value;
            }
        }
    }
}
