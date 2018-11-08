using Demo.CommandHandlerDemo;
using Demo.EventHandlerDemo;
using Demo.QueryDemo;
using Demo.SagaDemo;
using Demo.Variations;
using System;

namespace Demo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var app = new Program();
            app.Run();
        }

        private void Run()
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
                Console.WriteLine("D) Sagas");
                Console.WriteLine("E) Generic Variation");
                Console.WriteLine("X) eXit");
                Console.Write("\nSelect a demo: ");
                choice = Console.ReadLine().ToUpper();
                // Process menu choice
                switch (choice)
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

                    case "D":
                        new DemoSaga().Run();
                        break;

                    case "E":
                        new DemoVariations().RunGenericVariation();
                        break;
                }
                Console.WriteLine("\nPress [Enter] to continue...");
                Console.ReadLine();
                Console.Clear();
            } while (choice != "X");
        }
    }
}