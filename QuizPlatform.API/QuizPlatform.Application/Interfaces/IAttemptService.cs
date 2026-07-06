using QuizPlatform.Application.Dto.Attempt;

namespace QuizPlatform.Application.Interfaces
{
    public interface IAttemptService
    {
        Task<AttemptResponseDto> CreateAttemptAsync(CreateAttemptRequestDto createAttemptRequestDto, Guid userId, CancellationToken cancellationToken);
        Task<AttemptResponseDto> SaveAnswersAsync(Guid attemptId, SubmitAnswerRequestDto submitAnswerRequestDto, CancellationToken cancellationToken);
        Task<AttemptResultResponseDto> FinishAttemptAsync(Guid attemptId, CancellationToken cancellationToken);
        Task<AttemptResultResponseDto> GetAttemptResultAsync(Guid attemptId, CancellationToken cancellationToken);
        Task<List<AttemptResultResponseDto>> GetUserAttemptsByIdAsync(Guid userId, CancellationToken cancellationToken);
        Task<List<AttemptResponseDto>> GetQuizAttemptsByIdAsync(Guid quizId, CancellationToken cancellationToken);
    }
}
