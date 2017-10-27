using Autofac;
using Demo.EventHandlerDemo;
using Enexure.MicroBus;
using Enexure.MicroBus.Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine("MicroBus Demos");
            Console.WriteLine("==============\n");
            string choice;
            do
            {
                // Display menu
                Console.WriteLine("A) Commands and Command Handlers");
                Console.WriteLine("B) Events and Event Handlers");
                Console.WriteLine("C) Queries");
                Console.Write("\nSelect a demo: ");
                choice = Console.ReadLine().ToUpper();
                // Process menu choice
                switch(choice)
                {
                    case "A":
                        break;
                    case "B":
                        new DemoEvents().Run();
                        break;
                    case "C":
                        break;
                }
                Console.WriteLine("\nPress [Enter] to continue...");
                Console.ReadLine();
                Console.Clear();
            } while (choice != "X");
        }

    }

}
