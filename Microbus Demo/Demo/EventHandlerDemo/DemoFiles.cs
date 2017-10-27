using Enexure.MicroBus;
using System;
using System.Threading.Tasks;

namespace Demo.EventHandlerDemo
{
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
