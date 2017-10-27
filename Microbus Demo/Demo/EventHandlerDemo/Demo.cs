using Autofac;
using Enexure.MicroBus;
using Enexure.MicroBus.Autofac;

namespace Demo.EventHandlerDemo
{
    class DemoEvents
    {
        IContainer DiContainer;
        public DemoEvents()
        {
            // MicroBus
            var busBuilder = new BusBuilder();
            busBuilder.RegisterHandlers(GetType().Assembly);
            // Autofac
            var builder = new ContainerBuilder();
            builder.RegisterMicroBus(busBuilder);
            DiContainer = builder.Build();
        }

        public void Run()
        {
            var bus = DiContainer.Resolve<IMicroBus>();

            bus.PublishAsync(new Spoke { Words = "Hello World" });
        }
    }
}
