using NServiceBus;

public interface IOrderStorageContext
{
    OrderDbContext GetOrderDbContext(IMessageHandlerContext session);
}
