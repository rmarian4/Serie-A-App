using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper
{
    //part of webscraper that gets all the match statistics like possession, shots on target, offsides, etc.
    public class GetMatchStatistics
    {
        public string BaseUrl { get; set; }
        public HttpClient Client { get; set; }
        public int MatchDay { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public GetMatchStatistics(int matchDay, string homeTeam, string awayTeam, string year)
        {
            //BaseUrl = $"https://sport.sky.it/calcio/serie-a/partite/2021/giornata-{matchDay}/{homeTeam}-{awayTeam}/tabellino-statistiche";
            BaseUrl = $"https://sport.sky.it/calcio/serie-a/partite/{year}/giornata-{matchDay}/{homeTeam}-{awayTeam}/tabellino-statistiche";
            Client = new HttpClient();
            MatchDay = matchDay;
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
        }

       
        public async Task<List<List<string>>> ProcessMatchData()
        {
            
            var result = new List<List<string>>();

            
            var response = await Client.GetStringAsync(BaseUrl);
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(response);


            var table = doc.DocumentNode.SelectSingleNode("//table[contains(@class,'ftbl__match-statistics-table')]");
            var tableBody = table.SelectSingleNode("tbody");

            var homeTeamStats = this.GetHomeTeamData(tableBody);
            var awayTeamStats = this.GetAwayTeamData(tableBody);

            result.Add(homeTeamStats);
            result.Add(awayTeamStats);

            return result;
        }

        public List<string> GetHomeTeamData(HtmlAgilityPack.HtmlNode tableBody)
        {
            var result = new List<string>();
            var homeTeamStatsData = tableBody.SelectNodes("//td[contains(@class,'ftbl__match-statistics-row__home-cell')]").ToArray();

            var posession = homeTeamStatsData[0].SelectSingleNode("span").InnerHtml;
            var shotsOnTarget = homeTeamStatsData[1].SelectSingleNode("span").InnerHtml;
            var totalShots = homeTeamStatsData[2].SelectSingleNode("span").InnerHtml;
            var postCrossbar = homeTeamStatsData[3].SelectSingleNode("span").InnerHtml;
            var offSides = homeTeamStatsData[4].SelectSingleNode("span").InnerHtml;
            var foulsCommitted = homeTeamStatsData[5].SelectSingleNode("span").InnerHtml;
            var yellowCards = homeTeamStatsData[6].SelectSingleNode("span").InnerHtml;
            var redCards = homeTeamStatsData[7].SelectSingleNode("span").InnerHtml;
            var corners = homeTeamStatsData[8].SelectSingleNode("span").InnerHtml;

            result.Add(posession);
            result.Add(shotsOnTarget);
            result.Add(totalShots);
            result.Add(postCrossbar);
            result.Add(offSides);
            result.Add(foulsCommitted);
            result.Add(yellowCards);
            result.Add(redCards);
            result.Add(corners);

            return result;

        }



        public List<string> GetAwayTeamData(HtmlAgilityPack.HtmlNode tableBody)
        {
            var result = new List<string>();
            var awayTeamStatsData = tableBody.SelectNodes("//td[contains(@class,'ftbl__match-statistics-row__away-cell')]").ToArray();

            var posession = awayTeamStatsData[0].SelectSingleNode("span").InnerHtml;
            var shotsOnTarget = awayTeamStatsData[1].SelectSingleNode("span").InnerHtml;
            var totalShots = awayTeamStatsData[2].SelectSingleNode("span").InnerHtml;
            var postCrossbar = awayTeamStatsData[3].SelectSingleNode("span").InnerHtml;
            var offSides = awayTeamStatsData[4].SelectSingleNode("span").InnerHtml;
            var foulsCommitted = awayTeamStatsData[5].SelectSingleNode("span").InnerHtml;
            var yellowCards = awayTeamStatsData[6].SelectSingleNode("span").InnerHtml;
            var redCards = awayTeamStatsData[7].SelectSingleNode("span").InnerHtml;
            var corners = awayTeamStatsData[8].SelectSingleNode("span").InnerHtml;

            result.Add(posession);
            result.Add(shotsOnTarget);
            result.Add(totalShots);
            result.Add(postCrossbar);
            result.Add(offSides);
            result.Add(foulsCommitted);
            result.Add(yellowCards);
            result.Add(redCards);
            result.Add(corners);

            return result;


        }




    }
}
