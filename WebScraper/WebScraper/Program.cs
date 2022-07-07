// See https://aka.ms/new-console-template for more 

using System.Text.Json.Serialization;

namespace WebScraper
{
    public class MainMethod
    {
        public static async Task Main(string[] args)
        {
            //var test = new Standings();
            //var response = await test.GetStandings();
            //Console.WriteLine(response.Count);
            //Console.WriteLine(response.ElementAt(0).Count);
            //var test = new StatsLeaders();
            //var response = await test.getLeaderTables();
            //test.savesMadeLeaders(response);

            //var test = new MatchDayData(1);
            //var htmlData = await test.GetHtmlData();

            //var dates = test.GetDates(htmlData);


            //foreach(var item in dates)
            //{
            //    Console.WriteLine(item);
            //}



            //var homeTeamContainer = test.GetHomeTeamMatchContainers(htmlData);
            //var awayTeamContainer = test.GetAwayTeamMatchContainers(htmlData);

            //var homeTeamNameCrestUrlAndGoalsScored = test.GetTeamNameCrestUrlAndGoalsScored(homeTeamContainer);
            //var homeTeamGoalScorers = test.GetMatchGoalScorers(homeTeamContainer);

            //var awayTeamNameAndCrestUrl = test.GetTeamNameCrestUrlAndGoalsScored(awayTeamContainer);
            //var awayTeamGoalScorers = test.GetMatchGoalScorers(awayTeamContainer);

            //foreach(var item in awayTeamGoalScorers)
            //{
            //    Console.WriteLine(item);
            //}




            //var test = new GetMatchStatistics(1, "inter", "genoa");
            //var matchStats = await test.ProcessMatchData();
            //var links = await test.GetStatisticUrls();
            //var output = await test.ProcessMatchData(links);

            //Console.WriteLine(matchStats.Count);

            var test = new GetUrlDate();

           var htmlData = await test.getHtmlData();

            var matchesDate = test.getMatchesUrlYear(htmlData);

            var matchStatsDate = test.getMatchStatsUrlYear(htmlData);


            Console.WriteLine(matchesDate);

            Console.WriteLine(matchStatsDate);



        }

    }
    
    
}











