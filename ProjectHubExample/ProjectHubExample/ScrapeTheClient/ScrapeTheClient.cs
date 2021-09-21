using ScraperLibrary2;
using System;

namespace ScrapeTheClient
{
    public class ScrapeTheClient
    {
        ScrapeLibrary myScrapeLib = new ScrapeLibrary();
        string value = myScrapeLib.ScrapeWebPage("https://josephkeller.me");
    }
}
