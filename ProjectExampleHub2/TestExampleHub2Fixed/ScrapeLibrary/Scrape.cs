using System;
using System.IO;
using System.Net;
using System.Text;

namespace ScrapeLibrary
{
    public class Scrape
    {
        public string ScrapeWebPage(string url)
        {
            return GetWebpage(url);
        }

        public string ScrapeWebPage(string url, string filepath)
        {
            WebClient client = new WebClient();
            string reply = client.DownloadString(url);

            Console.WriteLine(reply);
            /* Write to file */
            string filePlacement2 = Path.Combine(Directory.GetCurrentDirectory(), "testFolder", "testFile.txt");
            if (File.Exists(filePlacement2))
            {
                File.WriteAllText(filePlacement2, reply);
            }
            else
            {
                Console.WriteLine("File does not exist, not cool man...making it now.");
                string filePath = @filePlacement2;
                try
                {
                    // Create the file, or overwrite if the file exists.
                    using (FileStream fs = File.Create(filePath))
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes(reply);
                        // Add some information to the file.
                        fs.Write(info, 0, info.Length);
                    }

                    // Open the stream and read it back.
                    /*
                    using (StreamReader sr = File.OpenText(filePath))
                    {
                        string s = "";
                        while ((s = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(s);
                        }
                    }
                    */

                    Console.WriteLine("File has been written, the end");
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Failed to write the file: {0}", ex.ToString());
                }


            }

            return reply;
        }

        private string GetWebpage(string url)
        {
            WebClient client = new WebClient();
            return client.DownloadString(url);
        }
    }
}
