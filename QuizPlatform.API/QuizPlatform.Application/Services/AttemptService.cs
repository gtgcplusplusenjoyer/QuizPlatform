using QuizPlatform.Core.Repositories;

namespace QuizPlatform.Application.Services
{
    public class AttemptService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAttemptRepository _attemptRepository;
        public AttemptService(IUserRepository userRepository, IAttemptRepository attemptRepository)
        {
            _attemptRepository = attemptRepository;
            _userRepository = userRepository;
        }


    }
}
