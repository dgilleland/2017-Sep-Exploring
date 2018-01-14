using Demo.CommandHandlerDemo;
using Demo.EventHandlerDemo;
using Demo.QueryDemo;
using System;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new Program();
            app.Run();
        }

        void Run()
        {
            string choice;
            do
            {
                // Display menu
                Console.WriteLine("MicroBus Demos");
                Console.WriteLine("==============\n");
                Console.WriteLine("A) Commands and Command Handlers");
                Console.WriteLine("B) Events and Event Handlers");
                Console.WriteLine("C) Queries");
                Console.WriteLine("X) eXit");
                Console.Write("\nSelect a demo: ");
                choice = Console.ReadLine().ToUpper();
                // Process menu choice
                switch(choice)
                {
                    case "A":
                        new DemoCommands().Run();
                        break;
                    case "B":
                        new DemoEvents().Run();
                        break;
                    case "C":
                        new DemoQueries().Run();
                        break;
                }
                Console.WriteLine("\nPress [Enter] to continue...");
                Console.ReadLine();
                Console.Clear();
            } while (choice != "X");
        }

    }

}
