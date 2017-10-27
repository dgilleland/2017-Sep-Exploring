using Autofac;
using Enexure.MicroBus;
using Enexure.MicroBus.Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.EventHandlerDemo
{
    class DemoEvents
    {
        IContainer DiContainer;
        public DemoEvents()
        {
            var busBuilder = new BusBuilder().RegisterHandlers(GetType().Assembly);
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
