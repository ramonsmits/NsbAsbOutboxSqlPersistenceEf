using System;
using NServiceBus;

/// <summary>
/// This only exist to wrap the extension method as these cannot easily to mocked for unit testing.
/// </summary>
class OrderStorageContext : IOrderStorageContext
{
    public OrderDbContext Get(IMessageHandlerContext context)
    {
        if (context.Extensions.TryGet(out OrderDbContext dataContext))
        {
            return dataContext;
        }
        throw new Exception($"No DbContext set for '{typeof(OrderDbContext)}.");
    }
}
