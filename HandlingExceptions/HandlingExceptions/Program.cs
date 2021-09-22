using System;
using System.IO;
using System.Text;

namespace HandlingExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePlacement2 = Path.Combine(Directory.GetCurrentDirectory(), "testFolder", "testFile.txt");
            FileWorker fileworker1 = new FileWorker(filePlacement2);
            fileworker1.HelpFileExistence();

            try
            {
                string content = File.ReadAllText(@fileworker1.FileLocation);
                Console.WriteLine(content);
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine("File not found: {0}", ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("Directory not found: {0}", ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was a problem: {0}", ex.Message);
            }
            finally
            {
                //Used for code to finalize, setting objects to null, closing db connections, etc.
                Console.WriteLine("Closing application now...");
            }
        }

        class FileWorker
        {
            public string FileLocation { get; set; }

            /* Basic car constructor class */
            public FileWorker()
            {
                FileLocation = "";
            }

            /* public constructor class */
            public FileWorker(string fileLocation)
            {
                FileLocation = fileLocation;
            }

            /* Determine if file exists */
            public void HelpFileExistence()
            {
                /* If that file does not exist, we will make it */
                if (File.Exists(FileLocation))
                {
                    Console.WriteLine("This file exists, it's cool");
                    string writeInText = "Hey, though we would just write this in here...";
                    File.WriteAllText(FileLocation, writeInText);
                }
                else
                {
                    Console.WriteLine("File does not exist, not cool man...making it now.");
                    string writeInText = "Hey, thought we would just write this in here...";
                    string filePath = @FileLocation;
                    try
                    {
                        // Create the file, or overwrite if the file exists.
                        using (FileStream fs = File.Create(filePath))
                        {
                            byte[] info = new UTF8Encoding(true).GetBytes(writeInText);
                            // Add some information to the file.
                            fs.Write(info, 0, info.Length);
                        }

                        // Open the stream and read it back.
                        using (StreamReader sr = File.OpenText(filePath))
                        {
                            string s = "";
                            while ((s = sr.ReadLine()) != null)
                            {
                                Console.WriteLine(s);
                            }
                        }

                        Console.WriteLine("File has been written, the end");
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine("Failed to write the file: {0}", ex.ToString());
                        Console.WriteLine(ex.ToString());
                    }


                }
            }
        }

    }
}
