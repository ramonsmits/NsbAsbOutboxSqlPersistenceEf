using System;
using System.Data.Entity;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Pipeline;

public class PersistAndPublishBehavior<TDbContext> : Behavior<IInvokeHandlerContext> where TDbContext : DbContext
{
    public override async Task Invoke(IInvokeHandlerContext context, Func<Task> next)
    {
        var session = context.SynchronizedStorageSession;
        var sqlPersistenceSession = session.SqlPersistenceSession();
        var dbContext = (TDbContext)Activator.CreateInstance(typeof(TDbContext), sqlPersistenceSession.Connection);

        using (dbContext)
        {
            dbContext.Database.UseTransaction(sqlPersistenceSession.Transaction);
            context.Extensions.Set(dbContext);

            await next()
                .ConfigureAwait(false);

            await dbContext.SaveChangesAsync()
                .ConfigureAwait(false);
        }
    }
}
