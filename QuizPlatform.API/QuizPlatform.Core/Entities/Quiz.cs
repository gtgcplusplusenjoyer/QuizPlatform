using QuizPlatform.Core.Enums;
using System.Net;

namespace QuizPlatform.Core.Entities
{
    public class Quiz : BaseEntity
    {
        public Guid UserId { get; set; }
        public User Author {  get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public QuizStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? PublishedAt { get; set; }
        public IList<Question> Questions { get; set; }


    }
}
