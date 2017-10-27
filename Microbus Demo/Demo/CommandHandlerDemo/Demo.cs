using Autofac;
using Enexure.MicroBus;
using Enexure.MicroBus.Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.CommandHandlerDemo
{
    class DemoCommands
    {
        IContainer DiContainer;
        public DemoCommands()
        {
            var busBuilder = new BusBuilder().RegisterHandlers(GetType().Assembly);
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
