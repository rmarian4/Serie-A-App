namespace SeriaAScoreApi.Models.MatchDataModels
{
    public class Match
    {
        public Team Hometeam { get; set; }
        public Team Awayteam {get; set;}
        public MatchStatistics? MatchStats { get; set; } 
        public string Date { get; set; }
    }
}
