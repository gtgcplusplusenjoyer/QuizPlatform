namespace QuizPlatform.Application.Dto.Attempt
{
    public record SubmitAnswerRequestDto(Guid QuestionId, List<Guid> SelectedOptionIds);
}
