using Autofac;
using Enexure.MicroBus;
using Enexure.MicroBus.Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Variations
{
    public class DemoVariations
    {
        private IContainer DiContainer;

        public DemoVariations()
        {
            // MicroBus
            var busBuilder = new BusBuilder();
            busBuilder.RegisterHandlers(GetType().Assembly);
            //busBuilder.RegisterGlobalHandler<WireTapHandler>();

            // Autofac
            var builder = new ContainerBuilder();
            builder.RegisterMicroBus(busBuilder);
            DiContainer = builder.Build();
        }

        public void RunGenericVariation()
        {
            var bus = DiContainer.Resolve<IMicroBus>();

            RunCommand<Payload>(bus);
        }

        private void RunCommand<T>(IMicroBus bus)
        {
            bus.SendAsync(new GenericCommand<T> { Message = $"T is a {typeof(T).Name}" });
        }
    }

    public class CommandHandler
        : ICommandHandler<GenericCommand<Payload>>
    {
        public Task Handle(GenericCommand<Payload> command)
        {
            Console.WriteLine(command.Message);
            return Task.CompletedTask;
        }
    }

    public class Payload
    {

    }
    public class GenericCommand<T> : ICommand
    {
        public string Message { get; set; }
    }

     
}
