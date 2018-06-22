using System.Threading.Tasks;
using NServiceBus;

public class PlaceOrderCommandHandler : IHandleMessages<PlaceOrderCommand>
{
    readonly IDbContextWrapper<OrderDbContext> orderStorageContext;

    public PlaceOrderCommandHandler(IDbContextWrapper<OrderDbContext> orderStorageContext)
    {
        this.orderStorageContext = orderStorageContext;
    }

    public async Task Handle(PlaceOrderCommand placeOrderCommand, IMessageHandlerContext context)
    {
        var dataContext = orderStorageContext.Get(context);

        var order = Order.Create(placeOrderCommand.OrderId, placeOrderCommand.OrderNumber);
        order.PlaceOrder(placeOrderCommand.PlacedAtDate);
        dataContext.Orders.Add(order);
    }
}
