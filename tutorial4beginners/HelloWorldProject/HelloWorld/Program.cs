using System;

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

            /* For loops */
            for (int j = 0; j < 3; j++)
            {
                Console.WriteLine("Here is j: {0}", j);
            }
        }
    }
}