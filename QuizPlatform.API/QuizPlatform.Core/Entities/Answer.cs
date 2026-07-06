namespace QuizPlatform.Core.Entities
{
    public class Answer : BaseEntity
    {
        public Guid AttemptId { get; set; }
        public Guid QuestionId { get; set; }
        public List<Guid> SelectedOptionIds { get; set; } 
        public bool? IsCorrect {  get; set; }
        public DateTime AnsweredAt { get; set; }
    }
}
