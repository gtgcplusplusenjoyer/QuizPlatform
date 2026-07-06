using QuizPlatform.Application.Dto.Attempt;
using QuizPlatform.Application.Interfaces;
using QuizPlatform.Core.Repositories;

namespace QuizPlatform.Application.Services
{
    public class AttemptService : IAttemptService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAttemptRepository _attemptRepository;
        public AttemptService(IUserRepository userRepository, IAttemptRepository attemptRepository)
        {
            _attemptRepository = attemptRepository;
            _userRepository = userRepository;
        }

        public Task<AttemptResponseDto> CreateAttemptAsync(CreateAttemptRequestDto createAttemptRequestDto, Guid userId, CancellationToken cancellationToken)
        {
            
        }

        public Task<AttemptResultResponseDto> FinishAttemptAsync(Guid attemptId, CancellationToken cancellationToken)
        {
            
        }

        public Task<AttemptResultResponseDto> GetAttemptResultAsync(Guid attemptId, CancellationToken cancellationToken)
        {
            
        }

        public Task<List<AttemptResponseDto>> GetQuizAttemptsByIdAsync(Guid quizId, CancellationToken cancellationToken)
        {
            
        }

        public Task<List<AttemptResultResponseDto>> GetUserAttemptsByIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            
        }

        public Task<AttemptResponseDto> SaveAnswersAsync(Guid attemptId, SubmitAnswerRequestDto submitAnswerRequestDto, CancellationToken cancellationToken)
        {
            
        }
    }
}
