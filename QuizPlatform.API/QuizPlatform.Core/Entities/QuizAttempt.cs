using QuizPlatform.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizPlatform.Core.Entities
{
    public class QuizAttempt : BaseEntity
    {
        public Guid QuizId { get; set; }
        public Quiz Quiz { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public AttemptStatus Status { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime FinishedAt { get; set; }
        public int? Score { get; set; }
        public int? MaxScore { get; set; }
        public List<Answer> Answers { get; set; }

    }
}
