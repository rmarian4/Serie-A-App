namespace SeriaAScoreApi.Models.MatchDataModels
{
    public class MatchStatistics
    {
        public Statistic Posession { get; set; }
        public Statistic ShotsOnTarget { get; set; }
        public Statistic TotalShots { get; set; }
        public Statistic PostCrossbar { get; set; }
        public Statistic OffSides { get; set; }
        public Statistic FoulsCommitted { get; set; }
        public Statistic YellowCards { get; set; }
        public Statistic RedCards { get; set; }
        public Statistic Corners { get; set; }

    }
}