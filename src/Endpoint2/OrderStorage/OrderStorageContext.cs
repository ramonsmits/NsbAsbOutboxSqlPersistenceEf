using System;
using NServiceBus;

/// <summary>
/// This only exist to warp the extension method as these cannot easily to mocked for unit testing.
/// </summary>
class OrderStorageContext : IOrderStorageContext
{
    public OrderDbContext GetOrderDbContext(IMessageHandlerContext context)
    {
        if (!context.Extensions.TryGet(out OrderDbContext dataContext)) throw new Exception($"No DbContext set for '{typeof(OrderDbContext)}.");
        return dataContext;
    }
}
