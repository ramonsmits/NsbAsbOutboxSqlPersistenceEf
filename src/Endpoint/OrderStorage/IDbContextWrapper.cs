using System.Data.Entity;
using NServiceBus;

public interface IDbContextWrapper<T> where T : DbContext
{
    T Get(IMessageHandlerContext session);
}
