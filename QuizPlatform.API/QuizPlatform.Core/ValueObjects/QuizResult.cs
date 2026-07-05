namespace QuizPlatform.Core.ValueObjects
{
    public class QuizResult
    {
        public int Score { get; set; }
        public int MaxScore { get; set; }
        public double Percentage { get; set; }
        public QuizResult(int score, int maxScore)
        {
            Score = score;
            MaxScore = maxScore;
            Percentage = MaxScore > 0 ? Math.Round((double)Score / MaxScore * 100, 2) : 0;
        }
    }
}
