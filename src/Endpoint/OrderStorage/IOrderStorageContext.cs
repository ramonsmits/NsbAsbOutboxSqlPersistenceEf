using NServiceBus;

public interface IOrderStorageContext
{
    OrderDbContext Get(IMessageHandlerContext session);
}
