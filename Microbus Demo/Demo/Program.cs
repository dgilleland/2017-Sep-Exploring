using Autofac;
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

        IContainer DiContainer;
        private Program()
        {
            var busBuilder = new BusBuilder().RegisterHandlers(GetType().Assembly);
            var builder = new ContainerBuilder();
            builder.RegisterMicroBus(busBuilder);
            DiContainer = builder.Build();
        }

        private void Run()
        {
            var bus = DiContainer.Resolve<IMicroBus>();

            bus.PublishAsync(new Spoke { Words = "Hello World" });
        }
    }

    public class Spoke : IEvent
    {
        public string Words { get; set; }
    }

    public class CyanListener : IEventHandler<Spoke>
    {
        public async Task Handle(Spoke @event)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@event.Words);
            Console.ResetColor();
        }
    }

    public class RedListener : IEventHandler<Spoke>
    {
        public async Task Handle(Spoke @event)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@event.Words);
            Console.ResetColor();
        }
    }

    public class YellowListener : IEventHandler<Spoke>
    {
        public async Task Handle(Spoke @event)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@event.Words);
            Console.ResetColor();
        }
    }
}
