using QuizPlatform.Application.Dto.Quiz;
using QuizPlatform.Application.Interfaces;
using QuizPlatform.Core.Repositories;

namespace QuizPlatform.Application.Services
{
    public class QuizService : IQuizService
    {
        private readonly IUserRepository _userRepository;
        private readonly IQuizRepository _quizRepository;
        public QuizService(IUserRepository userRepository, IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
            _userRepository = userRepository;
        }

        public Task<QuizResponseDto> CreateQuizAsync(CreateQuizRequestDto createQuizRequestDto, Guid userId, CancellationToken cancellationToken)
        {
            
        }

        public Task DeleteQuizAsync(Guid quizId, Guid userId, CancellationToken cancellationToken)
        {
            
        }

        public Task<QuizResponseDto> GetQuizByIdAsync(Guid quizId, CancellationToken cancellationToken)
        {
            
        }

        public Task<List<QuizSummaryDto>> GetQuizzesByAuthorIdAsync(Guid authorId, CancellationToken cancellationToken)
        {
            
        }

        public Task PublishQuizAsync(Guid quizId, CancellationToken cancellationToken)
        {
            
        }

        public Task UpdateQuizAsync(Guid quizId, UpdateQuizRequestDto updateQuizRequestDto, Guid userId, CancellationToken cancellationToken)
        {
            
        }
    }
}
