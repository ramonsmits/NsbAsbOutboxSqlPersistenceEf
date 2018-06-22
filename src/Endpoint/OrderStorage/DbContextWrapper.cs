using System;
using System.Data.Entity;
using NServiceBus;

/// <summary>
/// This only exist to wrap the extension method as these cannot easily to mocked for unit testing.
/// </summary>
class DbContextWrapper<T> : IDbContextWrapper<T> where T : DbContext
{
    public T Get(IMessageHandlerContext context)
    {
        if (context.Extensions.TryGet(out Lazy<T> dataContext))
        {
            return dataContext.Value;
        }
        throw new Exception($"No DbContext set for '{typeof(T)}.");
    }
}
