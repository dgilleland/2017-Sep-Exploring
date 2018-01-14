using Autofac;
using Enexure.MicroBus;
using Enexure.MicroBus.Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.QueryDemo
{
    class DemoQueries
    {
        IContainer DiContainer;
        public DemoQueries()
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

            var search = bus.QueryAsync(new MeaningOfLife(12,3,6,18));
            search.Wait();
            Console.WriteLine($"The search for the MeaningOfLife is {search.Result}");
        }
    }
}
