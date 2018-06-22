using System.Data.SqlClient;
using NServiceBus;
using NServiceBus.Persistence.Sql;

public class PersistenceConfiguration : INeedInitialization
{
    public void Customize(EndpointConfiguration configuration)
    {
        var persistence = configuration.UsePersistence<SqlPersistence>();
        persistence.SubscriptionSettings().DisableCache();
        persistence.SqlDialect<SqlDialect.MsSqlServer>();
        persistence.ConnectionBuilder(() => new SqlConnection("Server=.;Database=nservicebus;Trusted_Connection=True;"));
    }
}
