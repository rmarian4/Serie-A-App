using SeriaAScoreApi.Models.StatsLeadersModels;

namespace SeriaAScoreApi.HelperClasses
{
    //helper class gets all the scraped stats leaders data and then transforms it into a form that can be returned by the api.
    public class ProcessStatsLeaders
    {
        public List<GoalLeadersPlayer> ProcessGoalLeaders(List<List<string>> goalLeaders)
        {
            var result = new List<GoalLeadersPlayer>();

            foreach (var item in goalLeaders)
            {
                GoalLeadersPlayer player = new()
                {
                    Spot = item.ElementAt(0),
                    ClubCrestUrl = item.ElementAt(1),
                    PlayerName = item.ElementAt(2),
                    GoalsScored = item.ElementAt(3),
                    GamesPlayed = item.ElementAt(4),
                    PenaltyGoals = item.ElementAt(5)
                };

                result.Add(player);
            }

            return result;
        }

        public List<AssistLeadersPlayer> ProcessAssistLeaders(List<List<string>> assistLeaders)
        {
            var result = new List<AssistLeadersPlayer>();

            foreach(var item in assistLeaders)
            {
                AssistLeadersPlayer player = new()
                {
                    Spot = item.ElementAt(0),
                    ClubCrestUrl = item.ElementAt(1),
                    PlayerName = item.ElementAt(2),
                    Assists = item.ElementAt(3)
                };

                result.Add(player);
            }

            return result;
        }

        public List<KeyPassLeadersPlayer> ProcessKeyPassLeaders(List<List<string>> keyPassLeaders)
        {
            var result = new List<KeyPassLeadersPlayer>();

            foreach (var item in keyPassLeaders)
            {
                KeyPassLeadersPlayer player = new()
                {
                    Spot = item.ElementAt(0),
                    ClubCrestUrl = item.ElementAt(1),
                    PlayerName = item.ElementAt(2),
                    KeyPasses = item.ElementAt(3)
                };

                result.Add(player);
            }

            return result;
        }

        public List<RecoveryLeadersPlayer> ProcessRecoveryLeaders(List<List<string>> recoveryLeaders)
        {
            var result = new List<RecoveryLeadersPlayer>();

            foreach (var item in recoveryLeaders)
            {
                RecoveryLeadersPlayer player = new()
                {
                    Spot = item.ElementAt(0),
                    ClubCrestUrl = item.ElementAt(1),
                    PlayerName = item.ElementAt(2),
                    Recoveries = item.ElementAt(3)
                };

                result.Add(player);
            }

            return result;
        }

        public List<KmRunLeadersPlayer> ProcessKmRunLeaders(List<List<string>> kmRunLeaders)
        {
            var result = new List<KmRunLeadersPlayer>();

            foreach (var item in kmRunLeaders)
            {
                KmRunLeadersPlayer player = new()
                {
                    Spot = item.ElementAt(0),
                    ClubCrestUrl = item.ElementAt(1),
                    PlayerName = item.ElementAt(2),
                    KmRun = item.ElementAt(3),
                    Minutes = item.ElementAt(4)
                };

                result.Add(player);
            }

            return result;
        }


        public List<SavesMadeLeadersPlayer> ProcessSavesMadeLeaders(List<List<string>> savesMadeLeaders)
        {
            var result = new List<SavesMadeLeadersPlayer>();

            foreach (var item in savesMadeLeaders)
            {
                SavesMadeLeadersPlayer player = new()
                {
                    Spot = item.ElementAt(0),
                    ClubCrestUrl = item.ElementAt(1),
                    PlayerName = item.ElementAt(2),
                    Saves = item.ElementAt(3)
                };

                result.Add(player);
            }

            return result;
        }
    }
}
