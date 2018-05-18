using System;
using System.Data.Entity;
using NServiceBus;
using NServiceBus.Persistence;

namespace Infra.NServiceBus.Persistence
{
    public static class SynchronizedStorageExtensions
    {
        public static TDbContext FromCurrentSession<TDbContext>(this SynchronizedStorageSession session) where TDbContext : DbContext    
        {
            var sqlPersistenceSession = session.SqlPersistenceSession();
            var context = Activator.CreateInstance(typeof(TDbContext), new object[] { sqlPersistenceSession.Connection }) as TDbContext;
            context.Database.UseTransaction(sqlPersistenceSession.Transaction);
            return context;
        }
    }
}

