using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebScraper;
using SeriaAScoreApi.HelperClasses;
using SeriaAScoreApi.Models.StandingsModels;
using SeriaAScoreApi.Models.StatsLeadersModels;
using SeriaAScoreApi.Models.MatchDataModels;

namespace SeriaAScoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriaAScoreAppController : ControllerBase
    {

        [HttpGet("standings")]
        public async Task<ActionResult<List<TeamStats>>> FetchStandings()
        {
            Standings standingsObject = new Standings();
            var standings = await standingsObject.GetStandings();

            List<TeamStats> result = new List<TeamStats>();

            foreach(var item in standings)
            {
                TeamStats team = new()
                {
                    TeamName = item.ElementAt(0),
                    CrestUrl = item.ElementAt(1),
                    Position = item.ElementAt(2),
                    Points = item.ElementAt(3),
                    GamesPlayed = item.ElementAt(4),
                    Wins = item.ElementAt(5),
                    Draws = item.ElementAt(6),
                    Losses = item.ElementAt(7),
                    HomeMatchesPlayed = item.ElementAt(8),
                    HomeWins = item.ElementAt(9),
                    HomeDraws = item.ElementAt(10),
                    HomeLosses = item.ElementAt(11),
                    AwayMatchesPlayed = item.ElementAt(12),
                    AwayWins = item.ElementAt(13),
                    AwayDraws = item.ElementAt(14),
                    AwayLosses = item.ElementAt(15),
                    GoalsFor = item.ElementAt(16),
                    GoalsAgainst = item.ElementAt(17),
                    GoalDifference = item.ElementAt(18)
                };

                result.Add(team);
            }

            return Ok(result);
        }

        [HttpGet("statsLeaders")]
        public async Task<ActionResult<StatsLeaderLists>> FetchStatsLeaders()
        {
            //if the season has not started yet then the stats leaders page will be empty
            //Use try catch block so that if the stats leaders page is empty due to season not starting then return the appropriate message
            try
            {
                StatsLeaders statLeadersObject = new StatsLeaders();
                var leaderTables = await statLeadersObject.getLeaderTables();

                var goalLeaders = leaderTables.ElementAt(0);
                var assistLeaders = leaderTables.ElementAt(1);
                var keypassLeaders = leaderTables.ElementAt(2);
                var recoveryLeaders = leaderTables.ElementAt(3);
                var kmRunLeaders = leaderTables.ElementAt(4);
                var savesMadeLeaders = leaderTables.ElementAt(5);

                ProcessStatsLeaders helper = new ProcessStatsLeaders();

                StatsLeaderLists result = new()
                {
                    GoalLeaders = helper.ProcessGoalLeaders(goalLeaders),
                    AssistLeaders = helper.ProcessAssistLeaders(assistLeaders),
                    KeyPassLeaders = helper.ProcessKeyPassLeaders(keypassLeaders),
                    RecoveryLeaders = helper.ProcessRecoveryLeaders(recoveryLeaders),
                    KmRunLeaders = helper.ProcessKmRunLeaders(kmRunLeaders),
                    SavesMadeLeaders = helper.ProcessSavesMadeLeaders(savesMadeLeaders)
                };

                return result;

            }

            catch(Exception e)
            {
                return Ok("No stats available since season has not begun.");
            }

        }

        [HttpGet("matches/{matchDay}")]
        public async Task<ActionResult<List<Match>>> FetchMatches(int matchDay)
        {
            if(matchDay < 0 || matchDay > 38)
            {
                return BadRequest("Not a valid match day");
            }

            var helper = new ProcessMatchDayData();
            var result = await helper.ProcessMatchData(matchDay);
            
            return Ok(result);
        }

        [HttpGet("matches/{matchDay}/{homeTeam}/{awayTeam}")]
        public async Task<ActionResult<MatchStatistics>> FetchMatchStatistics(int matchDay, string homeTeam, string awayTeam)
        {
            string urlHomeTeam;
            string urlAwayTeam;

            if(homeTeam.Equals("Hellas Verona"))
            {
                urlHomeTeam = "verona";
                urlAwayTeam = awayTeam.ToLower().Replace(' ', '-');
            } else if (awayTeam.Equals("Hellas Verona"))
            {
                urlAwayTeam = "verona";
                urlHomeTeam = homeTeam.ToLower().Replace(' ', '-');
            } else
            {
                urlHomeTeam = homeTeam.ToLower().Replace(' ', '-');
                urlAwayTeam = awayTeam.ToLower().Replace(' ', '-');
            }
            

            var helper = new ProcessMatchDayData();
            var matchStats = await helper.SetMatchStatistics(matchDay, urlHomeTeam, urlAwayTeam);

            return Ok(matchStats);
        }

        
    }
}
