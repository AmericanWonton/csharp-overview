using Library_Example;
using System;

namespace MyClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Scrape myScrape = new Scrape();
            string theReply = myScrape.ScrapeWebPage("https://josephkeller.me");
            Console.WriteLine("Here is the reply: /n/n{0}\n\n", theReply);
        }
    }
}
