using System;
using System.Data.Entity;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Pipeline;

public class DbContextManagerBehavior<T> : Behavior<IInvokeHandlerContext> where T : DbContext
{
    public override async Task Invoke(IInvokeHandlerContext context, Func<Task> next)
    {
        var lazyContext = new Lazy<T>(() =>
        {
            var session = context.SynchronizedStorageSession;
            var sqlPersistenceSession = session.SqlPersistenceSession();
            var dbContext = (T)Activator.CreateInstance(typeof(T), sqlPersistenceSession.Connection);
            dbContext.Database.UseTransaction(sqlPersistenceSession.Transaction);
            return dbContext;
        });

        context.Extensions.Set(lazyContext);

        try
        {
            await next()
                .ConfigureAwait(false);

            if (lazyContext.IsValueCreated)
            {
                await lazyContext.Value.SaveChangesAsync()
                    .ConfigureAwait(false);
            }
        }
        finally
        {
            if (lazyContext.IsValueCreated)
            {
                lazyContext.Value.Dispose();
            }
        }
    }
}
