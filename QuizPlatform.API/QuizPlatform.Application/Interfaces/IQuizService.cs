using QuizPlatform.Application.Dto.Quiz;

namespace QuizPlatform.Application.Interfaces
{
    public interface IQuizService
    {
        Task<QuizResponseDto> GetQuizByIdAsync(Guid quizId, CancellationToken cancellationToken);
        Task<List<QuizSummaryDto>> GetQuizzesByAuthorIdAsync(Guid authorId, CancellationToken cancellationToken);
        Task<QuizResponseDto> CreateQuizAsync(CreateQuizRequestDto createQuizRequestDto, Guid userId, CancellationToken cancellationToken);
        Task DeleteQuizAsync(Guid quizId, Guid userId, CancellationToken cancellationToken);
        Task UpdateQuizAsync(Guid quizId, UpdateQuizRequestDto updateQuizRequestDto, Guid userId, CancellationToken cancellationToken);
        Task PublishQuizAsync(Guid quizId, CancellationToken cancellationToken);
    }
}
