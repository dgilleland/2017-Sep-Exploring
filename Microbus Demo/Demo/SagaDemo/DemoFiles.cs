using Enexure.MicroBus;
using Enexure.MicroBus.Sagas;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.SagaDemo
{
    public class OrderShippingSaga
        : ISaga
        , ISagaStartedBy<OrderPlaced>
        , IEventHandler<ItemShipped>
    {
        public bool IsCompleted { get; protected set; }
        public Guid SagaId { get; private set; }

        private readonly IMicroBus Bus;
        public OrderShippingSaga(IMicroBus bus)
        {
            Bus = bus;
        }

        public Task Handle(OrderPlaced ev)
        {
            SagaId = ev.OrderId;
            Console.WriteLine($"Saga started by ordering {ev.Items.Count} items");
            foreach (var item in ev.Items)
            {
                var cmd = new ShipItem { OrderId = ev.OrderId, ProductId = item.Key, Quantity = item.Value };
                Console.WriteLine($"\tShip {cmd.Quantity} of {cmd.ProductId}");
                Bus.SendAsync(cmd);
            }
            return Task.CompletedTask;
        }

        public Task Handle(ItemShipped ev)
        {
            Console.WriteLine($"Shipped {ev.Quantity} of product {Warehouse.Inventory[ev.ProductId].Product.Name}");
            return Task.CompletedTask;
        }
    }

    public class OrderShippingSagaFinder : ISagaFinder<OrderShippingSaga, CustomerOrderEvent>
    {
        private readonly ISagaRepository<OrderShippingSaga> Repository;
        public OrderShippingSagaFinder(ISagaRepository<OrderShippingSaga> repository)
        {
            Repository = repository;
        }
        public Task<OrderShippingSaga> FindByAsync(CustomerOrderEvent message)
        {
            return Repository.FindAsync(message);
        }
    }

    public class OrderShippingSagaRepository : ISagaRepository<OrderShippingSaga>
    {
        private static IDictionary<Guid, OrderShippingSaga> Repository =
            new Dictionary<Guid, OrderShippingSaga>();

        private readonly IMicroBus Bus;
        public OrderShippingSagaRepository(IMicroBus bus)
        {
            Bus = bus;
        }

        public Task CompleteAsync(OrderShippingSaga saga)
        {
            Repository.Remove(saga.SagaId);
            return Task.CompletedTask;
        }

        public Task CreateAsync(OrderShippingSaga saga)
        {
            Repository.Add(saga.SagaId, saga);
            return Task.CompletedTask;
        }

        public Task<OrderShippingSaga> FindAsync(IEvent message)
        {
            if (message is CustomerOrderEvent)
            {
                var ev = message as CustomerOrderEvent;
                if(Repository.ContainsKey(ev.OrderId))
                    return Task.FromResult(Repository[ev.OrderId]);
                return Task.FromResult<OrderShippingSaga>(null);
            }
            throw new Exception($"message must inherit from the {nameof(CountdownEvent)}");
        }

        public OrderShippingSaga NewSaga()
        {
            return new OrderShippingSaga(Bus);
        }

        public Task UpdateAsync(OrderShippingSaga saga)
        {
            Repository[saga.SagaId] = saga;
            return Task.CompletedTask;
        }
    }

    #region Peripheral Commands, Events, etc.
    public abstract class CustomerOrderEvent : IEvent
    {
        public Guid OrderId { get; set; }
    }

    public class OrderPlaced : CustomerOrderEvent
    {
        public Guid OrderId { get; set; }
        // For simplicity, we'll omit any customer info

        public IDictionary<Guid, int> Items { get; set; }
    }

    #region Warehouse domain
    public class Product
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
    }

    public class ShipItem : ICommand
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class ItemShipped : CustomerOrderEvent
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class Warehouse
        : ICommandHandler<ShipItem>
    {
        private readonly IMicroBus Bus;

        public Warehouse(IMicroBus bus)
        {
            Bus = bus;
        }

        #region Inventory Items
        public static IDictionary<Guid, InventoryItem> Inventory =
            new Dictionary<Guid, InventoryItem>
            {
                { Hammer.ProductId, new InventoryItem{ Product = Hammer, QuantityOnHand = 5 }  },
                { Nails.ProductId, new InventoryItem{ Product = Nails, QuantityOnHand = 1000 } },
                { Plywood.ProductId, new InventoryItem{ Product = Plywood, QuantityOnHand = 40 } },
                { TwoByFour.ProductId, new InventoryItem{ Product = TwoByFour, QuantityOnHand = 20 } }
            };

        public static Product Hammer =>
            new Product { ProductId = Guid.Parse("68208965-6c52-4cd6-b55d-649ca6241b3a"), Name = nameof(Hammer) };
        public static Product Nails =>
            new Product { ProductId = Guid.Parse("a37b1f76-bdac-4c59-9cc5-1888df50cf4a"), Name = nameof(Nails) };
        public static Product Plywood =>
            new Product { ProductId = Guid.Parse("9f039cb9-a71c-4da2-aad2-d7fb9ecb03b9"), Name = nameof(Plywood) };
        public static Product TwoByFour =>
            new Product { ProductId = Guid.Parse("6e366fb8-2633-4e64-b6f9-e5f2e5d637c3"), Name = nameof(TwoByFour) };

        public class InventoryItem
        {
            public Product Product { get; set; }
            public int QuantityOnHand { get; set; }
        }
        #endregion Inventory Items

        #region Command Handlers
        public Task Handle(ShipItem command)
        {
            var item = Inventory[command.ProductId];
            int orderQuantity = command.Quantity, shipQuantity;
            do
            {
                if (item.QuantityOnHand <= 0)
                {
                    // restock the item
                    Thread.Sleep(500);
                    item.QuantityOnHand += 12; // cheaper by the dozen :)
                }
                shipQuantity = Math.Min(orderQuantity, item.QuantityOnHand);
                item.QuantityOnHand -= shipQuantity;
                var shipped = new ItemShipped
                {
                    OrderId = command.OrderId,
                    ProductId = command.ProductId,
                    Quantity = shipQuantity
                };
                Bus.PublishAsync(shipped);
            } while (shipQuantity > 0);
            return Task.CompletedTask;
        }
        #endregion Command Handlers
    }
    #endregion Warehouse domain
    #endregion Peripheral Commands, Events, etc.
}