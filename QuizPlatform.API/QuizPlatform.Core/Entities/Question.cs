using QuizPlatform.Core.Enums;

namespace QuizPlatform.Core.Entities
{
    public class Question : BaseEntity
    {
        public Guid QuizId { get; set; }
        public Quiz Quiz { get; set; }
        public string Text { get; set; }
        public QuestionType QuestionType { get; set; }
        public List<AnswerOption> AnswerOptions { get; set; }
    }
}
