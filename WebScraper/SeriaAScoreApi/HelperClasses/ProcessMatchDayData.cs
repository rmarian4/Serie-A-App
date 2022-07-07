using SeriaAScoreApi.Models.MatchDataModels;
using WebScraper;

namespace SeriaAScoreApi.HelperClasses
{
    // helper class gets all the scraped match data and then transforms it into a form that can be returned by the api
    public class ProcessMatchDayData
    {
        //get all the match day data for a particular match day.
        public async Task<List<Match>> ProcessMatchData(int matchDay)
        {
            var matchDataYearUrlScraper = new GetUrlDate();
            var matchesHtmlData = await matchDataYearUrlScraper.getHtmlData();
            var matchDataYearUrl = matchDataYearUrlScraper.getMatchesUrlYear(matchesHtmlData);

            List<Match> result = new();
            MatchDayData matchDataScraper = new(matchDay, matchDataYearUrl);


            var htmlData = await matchDataScraper.GetHtmlData();

            var dates = matchDataScraper.GetDates(htmlData);

            var homeTeamMatchContainers = matchDataScraper.GetHomeTeamMatchContainers(htmlData);
            var homeTeamNamesCrestsAndGoalsScored = matchDataScraper.GetTeamNameCrestUrlAndGoalsScored(homeTeamMatchContainers);
            var homeTeamScorers = matchDataScraper.GetMatchGoalScorers(homeTeamMatchContainers);

            var awayTeamMatchContainers = matchDataScraper.GetAwayTeamMatchContainers(htmlData);
            var awayTeamNamesCrestsAndGoalsScored = matchDataScraper.GetTeamNameCrestUrlAndGoalsScored(awayTeamMatchContainers);
            var awayTeamScorers = matchDataScraper.GetMatchGoalScorers(awayTeamMatchContainers);

            

            for (int i=0; i< homeTeamNamesCrestsAndGoalsScored.Count; i++)
            {

                Match match = new()
                {
                    Hometeam = new()
                    {
                        TeamName = homeTeamNamesCrestsAndGoalsScored.ElementAt(i).ElementAt(0),
                        ClubCrestUrl = homeTeamNamesCrestsAndGoalsScored.ElementAt(i).ElementAt(1),
                        GoalsScored = homeTeamNamesCrestsAndGoalsScored.ElementAt(i).ElementAt(2),
                        GoalScorers = homeTeamScorers.ElementAt(i),
                    },
                    Awayteam = new()
                    {
                        TeamName = awayTeamNamesCrestsAndGoalsScored.ElementAt(i).ElementAt(0),
                        ClubCrestUrl = awayTeamNamesCrestsAndGoalsScored.ElementAt(i).ElementAt(1),
                        GoalsScored = awayTeamNamesCrestsAndGoalsScored.ElementAt(i).ElementAt(2),
                        GoalScorers = awayTeamScorers.ElementAt(i)
                    },
                    MatchStats = null,
                    Date = dates.ElementAt(i)
                };

                result.Add(match);
            }

            return result;

        }
        
        //get match stats for a particular game
        public async Task<MatchStatistics> SetMatchStatistics(int matchDay, string homeTeam, string awayTeam)
        {

            var matchStatsYearUrlScraper = new GetUrlDate();
            var matchesHtmlData = await matchStatsYearUrlScraper.getHtmlData();
            var matchStatsUrlYear = matchStatsYearUrlScraper.getMatchStatsUrlYear(matchesHtmlData);

            var matchStatsScraper = new GetMatchStatistics(matchDay, homeTeam, awayTeam, matchStatsUrlYear);

            var matchStats = await matchStatsScraper.ProcessMatchData();

            MatchStatistics result = new()
            {
                Posession = new()
                {
                    Hometeam = matchStats.ElementAt(0).ElementAt(0),
                    Awayteam = matchStats.ElementAt(1).ElementAt(0)
                },
                ShotsOnTarget = new()
                {
                    Hometeam = matchStats.ElementAt(0).ElementAt(1),
                    Awayteam = matchStats.ElementAt(1).ElementAt(1)
                },
                TotalShots = new()
                {
                    Hometeam = matchStats.ElementAt(0).ElementAt(2),
                    Awayteam = matchStats.ElementAt(1).ElementAt(2)
                },
                PostCrossbar = new()
                {
                    Hometeam = matchStats.ElementAt(0).ElementAt(3),
                    Awayteam = matchStats.ElementAt(1).ElementAt(3)
                },
                OffSides = new()
                {
                    Hometeam = matchStats.ElementAt(0).ElementAt(4),
                    Awayteam = matchStats.ElementAt(1).ElementAt(4)
                },
                FoulsCommitted = new()
                {
                    Hometeam = matchStats.ElementAt(0).ElementAt(5),
                    Awayteam = matchStats.ElementAt(1).ElementAt(5)
                },
                YellowCards = new()
                {
                    Hometeam = matchStats.ElementAt(0).ElementAt(6),
                    Awayteam = matchStats.ElementAt(1).ElementAt(6)
                },
                RedCards = new()
                {
                    Hometeam = matchStats.ElementAt(0).ElementAt(7),
                    Awayteam = matchStats.ElementAt(1).ElementAt(7)
                },
                Corners = new()
                {
                    Hometeam = matchStats.ElementAt(0).ElementAt(8),
                    Awayteam = matchStats.ElementAt(1).ElementAt(8)
                }
            };

            return result;
        }
    }
}
