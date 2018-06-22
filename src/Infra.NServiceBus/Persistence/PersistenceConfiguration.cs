using System.Data.SqlClient;
using NServiceBus;
using NServiceBus.Persistence.Sql;

public class PersistenceConfiguration : INeedInitialization
{
    public void Customize(EndpointConfiguration configuration)
    {
        configuration.EnableInstallers();
        var persistence = configuration.UsePersistence<SqlPersistence>();
        persistence.SubscriptionSettings().DisableCache();
        persistence.TablePrefix("Endpoint_");
        var dialect = persistence.SqlDialect<SqlDialect.MsSqlServer>();
        //dialect.Schema("OrderContext");
        persistence.ConnectionBuilder(connectionBuilder: () => new SqlConnection("Server=.;Database=nservicebus;Trusted_Connection=True;"));
    }
}
