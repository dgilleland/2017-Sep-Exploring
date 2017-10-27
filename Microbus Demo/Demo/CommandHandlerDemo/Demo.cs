using Autofac;
using Enexure.MicroBus;
using Enexure.MicroBus.Autofac;

namespace Demo.CommandHandlerDemo
{
    class DemoCommands
    {
        IContainer DiContainer;
        public DemoCommands()
        {
            // MicroBus
            var busBuilder = new BusBuilder();
            busBuilder.RegisterHandlers(GetType().Assembly);
            busBuilder.RegisterGlobalHandler<WireTapHandler>();
            // Autofac
            var builder = new ContainerBuilder();
            builder.RegisterMicroBus(busBuilder);
            DiContainer = builder.Build();
        }

        public void Run()
        {
            var bus = DiContainer.Resolve<IMicroBus>();

            bus.SendAsync(new DialNumber { Number = "780-555-2222" });
        }
    }
}
