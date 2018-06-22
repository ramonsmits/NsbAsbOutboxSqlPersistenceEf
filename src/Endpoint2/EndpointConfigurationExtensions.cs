using System.Data.Entity;
using NServiceBus;

static class EndpointConfigurationExtensions
{
    public static void ConfigureDbContextManager<TDbContext>(this EndpointConfiguration configuration)
       where TDbContext : DbContext
    {
        var pipeline = configuration.Pipeline;
        pipeline.Register(new DbContextManagerBehavior<TDbContext>(), $"Manage {typeof(TDbContext)} unit of work");
    }
}
