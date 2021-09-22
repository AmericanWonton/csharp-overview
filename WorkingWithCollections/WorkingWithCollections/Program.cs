using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WorkingWithCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car("Oldsmobile", "Cutlas Supreme", "00000000", 400.40, 1999);
            Car car2 = new Car("Geo", "Prism", "111111", 300.21, 1980);

            Book b1 = new Book("Robert Taylor", "Microsoft Services", "0-0000-0");

            /* ArrayLists are dynamically sized, have cool features like sort, remove, etc.
             Thing is, it's on some old ish...you can put ANYTHING inside a collection
             */
            ArrayList myArrayList = new ArrayList();
            myArrayList.Add(car1);
            myArrayList.Add(car2);
            myArrayList.Add(b1);

            /* Collections are way cooler. They are lists and 'generic lists'.
             Generics require the certain datatype that should be allowed in that collection */
            // List<T>
            List<Car> myList = new List<Car>();
            myList.Add(car1);
            myList.Add(car2);
            foreach (Car car in myList)
            {
                Console.WriteLine(car.Model);
            }

            //You can initialize List as well
            List<Car> myList2 = new List<Car>()
            {
                new Car() {Make = "Cooliostoolio", Model = "Big", VIN = "345E", StickerPrice=400.50, Year=1978},
                new Car() {Make = "Cooliostoolio", Model = "Kinda Big", VIN = "444RET", StickerPrice=700.50, Year=3000},
                new Car() {Make = "Funmobile", Model = "Atlanta", VIN="F6", StickerPrice=200.32, Year=1700},
                new Car() {Make = "BMW", Model = "Blackish", VIN="G74833", StickerPrice=2020.32, Year=1900}
            };

            /* Definitions are like key, value maps */
            // Dictionary<TKey, TValue>
            Dictionary<string, Car> myDictionary = new Dictionary<string, Car>();
            myDictionary.Add(car1.VIN, car1);
            myDictionary.Add(car2.VIN, car2);
            Console.WriteLine("Here is that second car: {0}", myDictionary["111111"].Make);

            /* You can use LINQ queries to find things easier */
            //Linq Query
            var coolstoolio = from car in myList2
                              where car.Make == "Cooliostoolio"
                              && car.Year == 3000
                              select car;
            //Linq Method
            foreach (var car in coolstoolio)
            {
                Console.WriteLine("{0}, {1}", car.Model, car.VIN);
            }

            //Another way of doing LINQ Query
            /* Lambed expression is in the parenthiesies. It's like a mini method, returning an instance of 
             'othercars', which is p */
            var otherCars = myList2.Where(p => p.Make == "BMW" && p.Year == 1900);
            foreach (var car in otherCars)
            {
                Console.WriteLine("{0}, {1}", car.Model, car.VIN);
            }


            //ordered cars
            var orderedCars = from car in otherCars
                              orderby car.Year descending
                              select car;
            /* Other way:
             var orderedCars = myCars.OrderByDescending(p => p.Year == 1900)
             */
            foreach (var car in orderedCars)
            {
                Console.WriteLine("{0}, {1}", car.Model, car.Year);
            }

            /* You can also define the values returned at runtime. There's a lot going on under the 
              hood with linq...but you MUST assign these datatypes as 'var' */
            var newerCars = from car in myList2
                            where car.Make == "Cooliostoolio"
                            && car.Year >= 1900
                            select new { car.Make, car.Model };
            Console.WriteLine(newerCars.GetType());
        }
    }

    class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string VIN { get; set; }
        public double StickerPrice { get; set; }
        public int Year {get;set;}

        /* Basic car constructor class */
        public Car()
        {
            Make = "basic car";
            Model = "Basic Model";
            VIN = "0000112100011";
            StickerPrice = 33.4;
            Year = 2000;
        }

        /* public constructor class */
        public Car(string make, string model, string vin, double stickerprice, int year)
        {
            this.Make = make;
            this.Model = model;
            this.VIN = vin;
            this.StickerPrice = stickerprice;
            this.Year = year;
        }

    }

    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }

        /* Basic car constructor class */
        public Book()
        {
            Title = "A Title";
            Author = "An Author";
            ISBN = "SIDKL:!@#";
        }

        /* public constructor class */
        public Book(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
        }
    }
}
