using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using HtmlAgilityPack;
using System.Net.Http;

namespace _0528
{
    class Program
    {
        static void Main(string[] args)
        {
            startCrawlerasync();
            Console.ReadKey();
        }

        private static async Task startCrawlerasync()
        {
            //URL test
            var url = "https://bh3momeha.game-info.wiki/d/%bf%d8%cd%c6%cd%dc%c0%ae%2830%7e50%29";
            var httpClinet = new HttpClient();
            var html = await httpClinet.GetStringAsync(url);
            var htmlDocument = new HtmlDocument() ;
            htmlDocument.LoadHtml(html);
            var 
            html
            .Where(node => node.GetAttributeValue("class","")).Equals()

            

        }
    }
}

