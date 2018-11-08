using Enexure.MicroBus;
using System;
using System.Threading.Tasks;

namespace Demo.CommandHandlerDemo
{
    public class DialNumber : ICommand
    {
        public string Number { get; set; }
    }

    public class TelephoneOperator : ICommandHandler<DialNumber>
    {
        public async Task Handle(DialNumber command)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Dialing {command.Number} ...");
            Console.ResetColor();
        }
    }

    public class WireTapHandler : IDelegatingHandler
    {
        public async Task<object> Handle(INextHandler next, object message)
        {
            if (message is DialNumber)
            {
                var command = message as DialNumber;
                // 1) Pre-process of message
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"[Wiretap open for {command.Number}] ");
                Console.ResetColor();

                // 2) Send message on it's way...
                var waiting = await next.Handle(message);

                // 3) Post-process of message
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"[Wiretap closed for {command.Number}] ");
                Console.ResetColor();

                return waiting;
            }
            else
                return await next.Handle(message);
        }
    }
}