using System;
using ScrapeLibrary;

namespace ScrapeClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Scrape myScrape = new Scrape();
            string value = myScrape.ScrapeWebPage("https://josephkeller.me");
            Console.WriteLine(value);
        }
    }
}
