using System;
using System.IO;
using System.Text;
using System.Net;

/* To run the application, use CTRL + F5  */
namespace HelloWorld
{
    class Program
    {
        /* Arguments to the main function are optional
        Void means that this method returns no value
        'Main' needs to be capitalized, otherwise the CLR will not be able to find 
        the entrypoint of the application.  */
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!"); //Example writing on the console
            /* Comment out multiple lines to save key presses */

            /*
            Console.Beep(); //Plays a beep noise, sounds fun 
            Console.ReadLine(); 
            */
            string myFirstString = "Here is a test string";
            int myFirstInt = 11;
            Double myFirstDouble = 22.4;
            Console.WriteLine(myFirstString);
            Console.WriteLine("You can also format strings like this...\nIt sucks tho...: {0}\n{1}\n{2}", myFirstInt, myFirstString, myFirstDouble);
            Console.WriteLine("Here is another example:{0} {1}", byte.MinValue, byte.MaxValue);

            /* If and else statements*/
            if (myFirstDouble == 22.4)
            {
                Console.WriteLine("Yeah, you're cool, Double");
            } 
            else if (myFirstDouble == 33.4)
            {
                Console.WriteLine("Eh, still okay, Double");
            } 
            else
            {
                Console.WriteLine("Dang, what happened, Double?");
            }

            /* Another way to write short conditionals */
            string testMessage = (myFirstDouble == 22.4) ? "Good Double" : "Wrong Double";
            string builtString = "Here is the result of our short conditional: " + testMessage + "\n";
            Console.WriteLine(builtString);


            /* For debugging tools, press F9 on the line you'd like a breakpoint in.
             * You can 'Step Into' the code with F10 to see it run*/
            /* For loops */
            for (int j = 0; j < 3; j++)
            {
                Console.WriteLine("Here is j: {0}", j);
                if (j == 2)
                {
                    break;
                }
            }

            /* While loops */
            bool displayMenu = true;
            while (displayMenu)
            {
                Console.WriteLine("This can go on forever...but we'll end it here....");
                displayMenu = false;
            }

            int funNum = 0;
            do
            {
                Console.WriteLine("Still in do while...");
                funNum++;
            } while (funNum != 2);

            /* Here are arrays...Collections are WAY better than arrays */
            int[] numbers = new int[5];
            int[] numbers2 = new int[] { 4, 8, 22, 43 };
            numbers[0] = 1;
            numbers[1] = 2;
            numbers[3] = 3;
            Console.WriteLine("Here is the length of the array: {0}. Here is spot 1: {1}", numbers.Length, numbers[1]);
            foreach (int aNumber in numbers2)
            {
                Console.WriteLine("Here is that number: {0}\n", aNumber);
            }
            string testString = "Here is a testString we shall convert to char array.";
            char[] charArray = testString.ToCharArray();
            Array.Reverse(charArray);
            foreach (char theChar in charArray)
            {
                Console.WriteLine("Here is that char: {0}: ", theChar);
            }

            /* Test method, called below */
            SayHello();
            Console.WriteLine("Here is that string: {0}", stringPrinter("Here's a test string"));

            /* Try catch method */
            try
            {
                var number = "1234";
                byte b = Convert.ToByte(number);
                Console.WriteLine(b);
            }
            catch (Exception)
            {
                Console.WriteLine("The number could not be converted to a byte.");
            }

            /* Random number in range */
            Random myRandom = new Random();
            int randomNumber = myRandom.Next(1, 11);
            Console.WriteLine("Here is that random number: {0}", randomNumber);


            /* String stuff */
            /* Date time */
            DateTime myBirthday = DateTime.Parse("03/03/1995");
            TimeSpan myAge = DateTime.Now.Subtract(myBirthday);
            Console.WriteLine("My age is: {0}", myAge.TotalDays);

            /* Class stuff */
            Car myCar = new Car(); //Crete a distinct car
            myCar.Make = "Test Make";
            myCar.Model = "Test Model";
            myCar.Year = 1986;
            myCar.Color = "Silver";

            Console.WriteLine("{0}, {1}, {2}, {3}", myCar.Make, myCar.Model, myCar.Year, myCar.Color);

            Console.WriteLine("Here is the value of your car: {0}", DetermineCarValue(myCar));
            Console.WriteLine("Here is a function called from this object: {0}", myCar.DetermineMarketValue());

            myCar.Model = "Another Cool Model";
            myCar.Year = 1965;
            Console.WriteLine("{0}, {1}, {2}, {3}", myCar.Make, myCar.Model, myCar.Year, myCar.Color);

            Car mySecondCar = new Car("Ford", "Escape", 2005, "Red-ish");

            mySecondCar.DoSomethingPublic();

            /* Writing to a file */
            string filePlacement2 = Path.Combine(Directory.GetCurrentDirectory(), "testFolder", "testFile.txt");
            Console.WriteLine("Here is the current path of this code: {0}", filePlacement2);
            /* If that file does not exist, we will make it */
            if (File.Exists(filePlacement2))
            {
                Console.WriteLine("This file exists, it's cool");
                string writeInText = "Hey, though we would just write this in here...";
                File.WriteAllText(filePlacement2, writeInText);
            }
            else
            {
                Console.WriteLine("File does not exist, not cool man...making it now.");
                string writeInText = "Hey, thought we would just write this in here...";
                string filePath = @filePlacement2;
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

            /* Some web/example of importing assemblies */
            WebClient client = new WebClient();
            string reply = client.DownloadString("https://josephkeller.me");

            Console.WriteLine("Here is that reply: {0}", reply);
        }

        /* Here are some defined classes */
        class Car
        {
            public string Make { get; set; }
            public string Model { get; set; }
            public int Year { get; set; }
            public string Color { get; set; }

            /* Basic car constructor class */
            public Car()
            {
                Make = "basic car";
                Model = "Basic Model";
                Year = 1995;
                Color = "Blue Basic";
            }

            /* public constructor class */
            public Car(string make, string model, int year, string color)
            {
                Make = make;
                Model = model;
                Year = year;
                Color = color;
            }

            public string DetermineMarketValue()
            {
                string value;

                if (Year < 1970)
                {
                    value = "Your car has a low value";
                }
                else
                {
                    value = "Your car has a high value";
                }

                return value;
            }

            /* Example public and private methods*/
            public void DoSomethingPublic()
            {
                Console.WriteLine("Here we would be doing something");
                //We cannot call this method outside of this class, because it is private
                Console.WriteLine(helperPrivateMethod());
            }

            private string helperPrivateMethod()
            {
                return "Hello from the private method.";
            }



        }

        /* Here are soem test methods... */
        private static void SayHello()
        {
            Console.WriteLine("Hello world");
        }

        private static string stringPrinter(string message)
        {
            return message;
        }

        private static string DetermineCarValue(Car car)
        {
            string goodCarValue = "";

            if (car.Year < 1970)
            {
                goodCarValue = "Your car has a low value";
            } 
            else
            {
                goodCarValue = "Your car has a high value";
            }

            return goodCarValue;
        }
    }
}