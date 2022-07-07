using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper
{
    //gets the stats leaders like top goal scorers, assists leaders, goalkeepers with the most saves made, etc.
    public class StatsLeaders
    {
        public string Url { get; set; }
        public HttpClient Client { get; set; }

        public StatsLeaders()
        {
            Url = "https://www.legaseriea.it/en/serie-a/statistics";
            //Url = "https://web.archive.org/web/20220525161756/https://www.legaseriea.it/en/serie-a/statistics";
            Client = new HttpClient();
        }

        public async Task<List<List<List<string>>>> getLeaderTables()
        {
            var htmlData = await Client.GetStringAsync(Url);

            var goalLeaders = this.getGoalLeaders(htmlData);
            var assistLeaders = this.getAssistLeaders(htmlData);
            var keyPassLeaders = this.getKeyPassLeaders(htmlData);
            var recoveryLeaders = this.getRecoveryLeaders(htmlData);
            var kmRunLeaders = this.getKmRunLeaders(htmlData);
            var savesMadeLeaders = this.savesMadeLeaders(htmlData);

            var result = new List<List<List<string>>>
            {
                goalLeaders,
                assistLeaders,
                keyPassLeaders,
                recoveryLeaders,
                kmRunLeaders,
                savesMadeLeaders
            };

            return result;

        }

        public List<List<string>> getGoalLeaders(string htmlData)
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(htmlData);

            var goalLeadersTable = doc.DocumentNode.SelectNodes("//table[contains(@class,'tabella')]").ToArray()[0];
            var tableBody = goalLeadersTable.SelectSingleNode("tbody");

            List<List<string>> result = new List<List<string>>();

            foreach(var row in tableBody.SelectNodes("tr"))
            {
                List<string> player = new List<string>(); 
                var rowItems = row.SelectNodes("td").ToArray();
                var spot = rowItems[0].InnerHtml;
                var clubCrestUrl = $"https://www.legaseriea.it{rowItems[1].SelectSingleNode("img").GetAttributeValue("src", null)}";
                var playerName = rowItems[2].SelectSingleNode("a").InnerHtml;
                var goalsScored = rowItems[3].InnerHtml;
                var gamesPlayed = rowItems[4].InnerHtml;
                var penaltyGoals = rowItems[5].InnerHtml;

                player.Add(spot);
                player.Add(clubCrestUrl);
                player.Add(playerName);
                player.Add(goalsScored);
                player.Add(gamesPlayed);
                player.Add(penaltyGoals);

                result.Add(player);
            }

            return result;
            
        }

        public List<List<string>> getAssistLeaders(string htmlData)
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(htmlData);

            var assistLeadersTable = doc.DocumentNode.SelectNodes("//table[contains(@class,'tabella')]").ToArray()[1];
            var tableBody = assistLeadersTable.SelectSingleNode("tbody");

            List<List<string>> result = new List<List<string>>();

            foreach (var row in tableBody.SelectNodes("tr"))
            {
                List<string> player = new List<string>();
                var rowItems = row.SelectNodes("td").ToArray();
                var spot = rowItems[0].InnerHtml;
                var clubCrestUrl = $"https://www.legaseriea.it{rowItems[1].SelectSingleNode("img").GetAttributeValue("src", null)}";
                var playerName = rowItems[2].SelectSingleNode("a").InnerHtml;
                var assists= rowItems[3].InnerHtml;

                player.Add(spot);
                player.Add(clubCrestUrl);
                player.Add(playerName);
                player.Add(assists);

                result.Add(player);
            }

            return result;
        }

        public List<List<string>> getKeyPassLeaders(string htmlData)
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(htmlData);

            var keyPassLeadersTable = doc.DocumentNode.SelectNodes("//table[contains(@class,'tabella')]").ToArray()[3];
            var tableBody = keyPassLeadersTable.SelectSingleNode("tbody");

            List<List<string>> result = new List<List<string>>();

            foreach (var row in tableBody.SelectNodes("tr"))
            {
                List<string> player = new List<string>();
                var rowItems = row.SelectNodes("td").ToArray();
                var spot = rowItems[0].InnerHtml;
                var clubCrestUrl = $"https://www.legaseriea.it{rowItems[1].SelectSingleNode("img").GetAttributeValue("src", null)}";
                var playerName = rowItems[2].SelectSingleNode("a").InnerHtml;
                var keyPasses = rowItems[3].InnerHtml;

                player.Add(spot);
                player.Add(clubCrestUrl);
                player.Add(playerName);
                player.Add(keyPasses);

                result.Add(player);
            }

            return result;
        }


        public List<List<string>> getRecoveryLeaders(string htmlData)
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(htmlData);

            var recoveryLeadersTable = doc.DocumentNode.SelectNodes("//table[contains(@class,'tabella')]").ToArray()[4];
            var tableBody = recoveryLeadersTable.SelectSingleNode("tbody");

            List<List<string>> result = new List<List<string>>();

            foreach (var row in tableBody.SelectNodes("tr"))
            {
                List<string> player = new List<string>();
                var rowItems = row.SelectNodes("td").ToArray();
                var spot = rowItems[0].InnerHtml;
                var clubCrestUrl = $"https://www.legaseriea.it{rowItems[1].SelectSingleNode("img").GetAttributeValue("src", null)}";
                var playerName = rowItems[2].SelectSingleNode("a").InnerHtml;
                var recoveries = rowItems[3].InnerHtml;

                player.Add(spot);
                player.Add(clubCrestUrl);
                player.Add(playerName);
                player.Add(recoveries);

                result.Add(player);
            }

            return result;
        }

        public List<List<string>> getKmRunLeaders(string htmlData)
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(htmlData);

            var kmRunLeadersTable = doc.DocumentNode.SelectNodes("//table[contains(@class,'tabella')]").ToArray()[5];
            var tableBody = kmRunLeadersTable.SelectSingleNode("tbody");

            List<List<string>> result = new List<List<string>>();

            foreach (var row in tableBody.SelectNodes("tr"))
            {
                List<string> player = new List<string>();
                var rowItems = row.SelectNodes("td").ToArray();
                var spot = rowItems[0].InnerHtml;
                var clubCrestUrl = $"https://www.legaseriea.it{rowItems[1].SelectSingleNode("img").GetAttributeValue("src", null)}";
                var playerName = rowItems[2].SelectSingleNode("a").InnerHtml;
                var kmRun = rowItems[3].InnerHtml;
                var minutes = rowItems[4].InnerHtml;

                player.Add(spot);
                player.Add(clubCrestUrl);
                player.Add(playerName);
                player.Add(kmRun);
                player.Add(minutes);

                result.Add(player);
            }

            return result;
        }

        public List<List<string>> savesMadeLeaders(string htmlData)
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(htmlData);

            var kmRunLeadersTable = doc.DocumentNode.SelectNodes("//table[contains(@class,'tabella')]").ToArray()[8];
            var tableBody = kmRunLeadersTable.SelectSingleNode("tbody");

            List<List<string>> result = new List<List<string>>();

            foreach (var row in tableBody.SelectNodes("tr"))
            {
                List<string> player = new List<string>();
                var rowItems = row.SelectNodes("td").ToArray();
                var spot = rowItems[0].InnerHtml;
                var clubCrestUrl = $"https://www.legaseriea.it{rowItems[1].SelectSingleNode("img").GetAttributeValue("src", null)}";
                var playerName = rowItems[2].SelectSingleNode("a").InnerHtml;
                var saves = rowItems[3].InnerHtml;

                player.Add(spot);
                player.Add(clubCrestUrl);
                player.Add(playerName);
                player.Add(saves);

                result.Add(player);
            }

            return result;
        }

    }
}
