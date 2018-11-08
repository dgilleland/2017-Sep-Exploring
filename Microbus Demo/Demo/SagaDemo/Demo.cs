using Autofac;
using Enexure.MicroBus;
using Enexure.MicroBus.Autofac;
using Enexure.MicroBus.Sagas;
using System;
using System.Collections.Generic;

namespace Demo.SagaDemo
{
    internal class DemoSaga
    {
        private IContainer DiContainer;

        public DemoSaga()
        {
            // MicroBus
            var busBuilder = new BusBuilder();
            busBuilder.RegisterHandlers(GetType().Assembly);
            busBuilder.RegisterSaga<OrderShippingSaga>();//(FinderList.Empty.AddSagaFinder<OrderShippingSagaFinder>());
            // Autofac
            var builder = new ContainerBuilder();
            builder
                .RegisterType<OrderShippingSagaRepository>()
                .AsSelf()
                .AsImplementedInterfaces()
                .SingleInstance();
            builder.RegisterMicroBus(busBuilder);
            DiContainer = builder.Build();
        }

        public void Run()
        {
            var bus = DiContainer.Resolve<IMicroBus>();

            // Triggering Event
            var newOrder = new OrderPlaced
            {
                OrderId = Guid.NewGuid(),
                Items = new Dictionary<Guid, int>
                {
                    { Warehouse.Hammer.ProductId, 4 },
                    { Warehouse.Nails.ProductId, 400 },
                    { Warehouse.Plywood.ProductId, 25 },
                    { Warehouse.TwoByFour.ProductId, 30 },
                }
            };
            var search = bus.PublishAsync(newOrder);
            search.Wait();
        }
    }
}