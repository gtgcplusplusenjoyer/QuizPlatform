namespace QuizPlatform.Core.Entities
{
    public class AnswerOption : BaseEntity
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }
}
