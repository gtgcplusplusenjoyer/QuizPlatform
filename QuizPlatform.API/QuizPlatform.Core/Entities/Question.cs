using QuizPlatform.Core.Enums;

namespace QuizPlatform.Core.Entities
{
    public class Question : BaseEntity
    {
        public string Text { get; set; }
        public QuestionType QuestionType { get; set; }
        public List<AnswerOption> AnswerOptions { get; set; }
    }
}
