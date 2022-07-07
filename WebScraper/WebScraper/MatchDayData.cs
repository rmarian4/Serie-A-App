using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper
{
    // gets the match day data like all the matchs on the match day, the match goal scorers, the date the match took place on, etc.
    public class MatchDayData
    {
        public string Url { get; set; }
        public HttpClient Client { get; set; }

        public MatchDayData(int matchDay, string year)
        {
            Url = $"https://www.legaseriea.it/en/serie-a/fixture-and-results/{year}/UNICO/UNI/{matchDay}";
            //Url = $"https://www.legaseriea.it/en/serie-a/fixture-and-results/2021-22/UNICO/UNI/{matchDay}";
            //Url = $"https://www.legaseriea.it/en/serie-a/fixture-and-results/2022-23/UNICO/UNI/{matchDay}";
            Client = new HttpClient();
        }

        public async Task<string> GetHtmlData()
        {
            var htmlData = await Client.GetStringAsync(Url);
            
            return htmlData;

        }

        public List<string> GetDates(string htmlData)
        {
            var result = new List<string>();

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(htmlData);

            var GameInfoContainer = doc.DocumentNode.SelectNodes("//div[contains(@class,'datipartita')]");

            foreach(var item in GameInfoContainer)
            {
                var date = item.SelectSingleNode("p").SelectSingleNode("span").InnerHtml;
                result.Add(date);
            }

            return result;
        }

        public List<HtmlAgilityPack.HtmlNode> GetHomeTeamMatchContainers(string htmlData)
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(htmlData);

            var homeTeamContainers = doc.DocumentNode.SelectNodes("//div[contains(@class,'risultatosx')]").ToList();

            return homeTeamContainers;
        }

        public List<HtmlAgilityPack.HtmlNode> GetAwayTeamMatchContainers(string htmlData)
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(htmlData);

            var awayTeamContainers = doc.DocumentNode.SelectNodes("//div[contains(@class, 'risultatodx')]").ToList();

            return awayTeamContainers;
        }

        public List<List<string>> GetTeamNameCrestUrlAndGoalsScored(List<HtmlAgilityPack.HtmlNode> teamContainers)
        {
            List<List<string>> result = new List<List<string>>();

            foreach (var team in teamContainers)
            {
                List<string> listItem = new List<string>();
                var homeTeam = team.SelectSingleNode("h4").InnerHtml;
                var crestUrl = $"https://www.legaseriea.it{team.SelectSingleNode("img").GetAttributeValue("src", null)}";
                var goals = team.SelectSingleNode("span").InnerHtml;

                listItem.Add(homeTeam);
                listItem.Add(crestUrl);
                listItem.Add(goals);
                
                result.Add(listItem);

            }

            return result;
        }

        public List<string[]> GetMatchGoalScorers(List<HtmlAgilityPack.HtmlNode> teamContainers)
        {
            var result = new List<string[]>();

            foreach(var team in teamContainers)
            {
                //var goals = team.SelectSingleNode("span").InnerHtml;

                var goalScorersString = team.SelectSingleNode("p").InnerHtml;
                string[] goalScorers = goalScorersString.Split("<br>");

                if (goalScorers.Length > 0)
                {
                    for (int i = 0; i < goalScorers.Length; i++)
                    {
                        goalScorers[i] = goalScorers[i].Trim();
                    }
                }

                result.Add(goalScorers[0..(goalScorers.Length-1)]);
            }

            return result;

        }
    }
}
