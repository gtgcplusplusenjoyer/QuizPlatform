namespace QuizPlatform.Application.Dto.Quiz
{
    public record QuizSummaryDto(
        Guid Id,
        string Title,
        string Description,
        int Status,
        DateTime CreatedAt,
        DateTime? PublishedAt,
        int QuestionCount,
        int? AttemptsCount,
        int? AverageScore
        );
}
