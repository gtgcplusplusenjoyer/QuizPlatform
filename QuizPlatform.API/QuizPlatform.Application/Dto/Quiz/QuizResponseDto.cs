namespace QuizPlatform.Application.Dto.Quiz
{
    public record QuizResponseDto(
        Guid Id,
        Guid UserId,
        string AuthorName,
        string Title,
        string Description,
        int Status,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        DateTime? PublishedAt,
        int QuestionCount
        );
}
