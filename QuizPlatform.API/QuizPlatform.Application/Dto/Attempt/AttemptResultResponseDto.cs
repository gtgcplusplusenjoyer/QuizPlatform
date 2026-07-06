namespace QuizPlatform.Application.Dto.Attempt
{
    public record AttemptResultResponseDto(
        Guid AttemptId,
        Guid QuizId,
        string Title,
        int Score,
        int MaxScore,
        double Percentage,
        DateTime CompletedAt
        );
}
