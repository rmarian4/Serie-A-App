namespace SeriaAScoreApi.Models.MatchDataModels
{
    public class Team
    {
        public string TeamName { get; set; }
        public string GoalsScored { get; set; }
        public string[]? GoalScorers { get; set; }
        public string ClubCrestUrl { get; set; }
    }
}