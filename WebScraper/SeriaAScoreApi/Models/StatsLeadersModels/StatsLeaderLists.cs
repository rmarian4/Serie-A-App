namespace SeriaAScoreApi.Models.StatsLeadersModels
{
    public class StatsLeaderLists
    {
        public List<GoalLeadersPlayer> GoalLeaders { get; set; }
        public List<AssistLeadersPlayer> AssistLeaders { get; set; }
        public List<KeyPassLeadersPlayer> KeyPassLeaders { get; set; }
        public List<RecoveryLeadersPlayer> RecoveryLeaders { get; set; }
        public List<KmRunLeadersPlayer> KmRunLeaders { get; set; }
        public List<SavesMadeLeadersPlayer> SavesMadeLeaders { get; set; }

    }
}
