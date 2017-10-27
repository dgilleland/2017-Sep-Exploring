using Enexure.MicroBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
}
