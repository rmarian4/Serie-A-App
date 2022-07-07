using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper
{
    //url for match stats and info contains the year of the current season. This class gets the year of the current season so it can be added
    // to the url used to get the match stats and match info
    public class GetUrlDate
    {
        public string Url { get; set; }
        public HttpClient Client { get; set; }
        public GetUrlDate()
        {
            Url = "https://www.legaseriea.it/en/serie-a/fixture-and-results";
            Client = new HttpClient();
        }

        public async Task<string> getHtmlData()
        {
            var htmlData = await Client.GetStringAsync(Url);
            return htmlData;
        }

        public string getMatchesUrlYear(string htmlData)
        {
            
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(htmlData);

            var GameInfoContainer = doc.DocumentNode.SelectNodes("//div[contains(@class,'datipartita')]");

            var year = GameInfoContainer[0].SelectSingleNode("p").SelectSingleNode("span").InnerHtml.Substring(6,4);
            var proceedingYear = Int32.Parse(year.Substring(2, 2)) + 1;

            return year + "-" + proceedingYear.ToString();
        }

        public string getMatchStatsUrlYear(string htmlData)
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(htmlData);

            var GameInfoContainer = doc.DocumentNode.SelectNodes("//div[contains(@class,'datipartita')]");

            var year = GameInfoContainer[0].SelectSingleNode("p").SelectSingleNode("span").InnerHtml.Substring(6, 4);

            return year;

        }
    }
}
