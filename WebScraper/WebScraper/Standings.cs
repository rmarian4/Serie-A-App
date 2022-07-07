using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace WebScraper
{
    //class gets the league standings 
    public class Standings
    {
        public string Url { get; set; }
        public HttpClient Client { get; set; }
        public Standings()
        {
            Url = "https://www.legaseriea.it/en/serie-a/league-table";
            Client = new HttpClient();
        }

        public async Task<List<List<string>>> GetStandings()
        {
            var response = await Client.GetStringAsync(Url);

            return this.ParseHtml(response);
        }

        private List<List<string>> ParseHtml(string htmlData)
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(htmlData);

            var table = doc.DocumentNode.SelectSingleNode("//table[contains(@class,'classifica')]");
            var tableBody = table.SelectSingleNode("tbody");

            var tableRows = tableBody.SelectNodes("tr");

            List<List<string>> standings = new List<List<string>>();

            foreach (var row in tableRows)
            {
                List<string> teamStatsList = new List<string>();

                var rowItems = row.SelectNodes("td").ToArray();

                var teamContainer = rowItems[0].DescendantsAndSelf().ToArray();
                var team = teamContainer[teamContainer.Length - 1].InnerHtml.Trim();

                //var team = rowItems[0].DescendantsAndSelf().ToArray()[5].InnerHtml.Trim();
                var crestUrl = $"https://www.legaseriea.it{rowItems[0].SelectSingleNode("img").GetAttributeValue("src", null)}";
                var position = rowItems[0].SelectSingleNode("span").InnerHtml;
                var points = rowItems[1].InnerHtml;
                var gamesPlayed = rowItems[2].InnerHtml;
                var wins = rowItems[3].InnerHtml;
                var draws = rowItems[4].InnerHtml;
                var losses = rowItems[5].InnerHtml;
                var homeMatchesPlayed = rowItems[6].InnerHtml;
                var homeWins = rowItems[7].InnerHtml;
                var homeDraws = rowItems[8].InnerHtml;
                var homeLosses = rowItems[9].InnerHtml;
                var awayMatchesPlayed = rowItems[10].InnerHtml;
                var awayWins = rowItems[11].InnerHtml;
                var awayDraws = rowItems[12].InnerHtml;
                var awayLosses = rowItems[13].InnerHtml;
                var goalsFor = rowItems[14].InnerHtml;
                var goalsAgainst = rowItems[15].InnerHtml;
                var goalDifference = Convert.ToString(Int32.Parse(goalsFor) - Int32.Parse(goalsAgainst));

                teamStatsList.Add(team);
                teamStatsList.Add(crestUrl);
                teamStatsList.Add(position);
                teamStatsList.Add(points);
                teamStatsList.Add(gamesPlayed);
                teamStatsList.Add(wins);
                teamStatsList.Add(draws);
                teamStatsList.Add(losses);
                teamStatsList.Add(homeMatchesPlayed);
                teamStatsList.Add(homeWins);
                teamStatsList.Add(homeDraws);
                teamStatsList.Add(homeLosses);
                teamStatsList.Add(awayMatchesPlayed);
                teamStatsList.Add(awayWins);
                teamStatsList.Add(awayDraws);
                teamStatsList.Add(awayLosses);
                teamStatsList.Add(goalsFor);
                teamStatsList.Add(goalsAgainst);
                teamStatsList.Add(goalDifference);

                standings.Add(teamStatsList);


            }

            return standings;


        }
    }
}
