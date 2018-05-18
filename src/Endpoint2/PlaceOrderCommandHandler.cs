using System.Threading.Tasks;
using Domain;
using Endpoint2.Commands;
using Infra.NServiceBus.Persistence;
using NServiceBus;
using NServiceBus.Logging;

namespace Endpoint2
{
    public class PlaceOrderCommandHandler : IHandleMessages<PlaceOrderCommand>
    {
        static ILog log = LogManager.GetLogger<PlaceOrderCommand>();
        public async Task Handle(PlaceOrderCommand placeOrderCommand, IMessageHandlerContext context)
        {
            log.Info($"Endpoint2 Received PlaceOrderCommand: {placeOrderCommand.OrderNumber}");
            context.Extensions.TryGet("DbContext", out OrderDbContext dataContext);

            var order = Domain.Order.Create(placeOrderCommand.OrderId, placeOrderCommand.OrderNumber);
            order.PlaceOrder(placeOrderCommand.PlacedAtDate);
            dataContext.Orders.Add(order);
        }
    }
}

