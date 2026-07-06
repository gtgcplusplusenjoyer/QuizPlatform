namespace QuizPlatform.Application.Dto.Attempt
{
    public record AttemptResponseDto(
        Guid Id,
        Guid QuizId,
        string QuizTitle,
        Guid UserId,
        string UserName,
        int Status,
        DateTime StartedAt,
        DateTime? FinishedAt,
        int? Score,
        int? MaxScore,
        double? Percentage
            );
}