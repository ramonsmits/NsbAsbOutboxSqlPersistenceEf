using System.Threading.Tasks;
using Endpoint1.Commands;
using NServiceBus;

namespace Endpoint1
{
    public class PlaceOrderCommandHandler : IHandleMessages<PlaceOrderCommand>
    {
        public async Task Handle(PlaceOrderCommand placeOrderCommand, IMessageHandlerContext context)
        {
            var dataContext = context.OrderDbContext();
            var order = Domain.Order.Create(placeOrderCommand.OrderId, placeOrderCommand.OrderNumber);
            order.PlaceOrder(placeOrderCommand.PlacedAtDate);
            dataContext.Orders.Add(order);
        }
    }
}

