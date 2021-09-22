using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Todo> todos = new List<Todo>()
            {
                new Todo {Description = "Task 1", EstimatedHours = 3, Status = Status.NotStarted},
                new Todo {Description = "Task 2", EstimatedHours = 8, Status = Status.OnHold},
                new Todo {Description = "Task 3", EstimatedHours = 11, Status = Status.InProgress},
                new Todo {Description = "Task 4", EstimatedHours = 4, Status = Status.InProgress},
                new Todo {Description = "Task 5", EstimatedHours = 66, Status = Status.Completed}
            };

            Console.ForegroundColor = ConsoleColor.DarkGreen; //Example of an enumeration

            /* Here's an example of swithc statements that come in handy.
             * They work well with enums. You can hit tab twice to generate the switch statement*/
            foreach (var todo in todos)
            {
                switch (todo.Status)
                {
                    case Status.NotStarted:
                        Console.WriteLine("We have a nonstarter: {0}", todo.Description);
                        break;
                    case Status.InProgress:
                        Console.WriteLine("We have an Inprogress: {0}", todo.Description);
                        break;
                    case Status.OnHold:
                        Console.WriteLine("We have an onhold: {0}", todo.Description);
                        break;
                    case Status.Completed:
                        Console.WriteLine("We have a completed: {0}", todo.Description);
                        break;
                    default:
                        Console.WriteLine("There's a problem job: {0}", todo.Description);
                        break;
                }
            }
        }

        class Todo
        {
            public string Description { get; set; }
            public int EstimatedHours { get; set; }
            public Status Status { get; set; }

            /* Basic car constructor class */
            public Todo()
            {
                Description = "basic car";
                EstimatedHours = 1;
            }

            /* public constructor class */
            public Todo(string description, int estimatedhours)
            {
                Description = description;
                EstimatedHours = estimatedhours;
            }

        }

        enum Status
        {
            NotStarted,
            InProgress,
            OnHold,
            Completed
        }
    }
}
