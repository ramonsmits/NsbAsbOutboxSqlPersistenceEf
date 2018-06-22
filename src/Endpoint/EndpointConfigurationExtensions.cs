using System.Data.Entity;
using NServiceBus;

static class EndpointConfigurationExtensions
{
    public static void ConfigureDbContextManager<T>(this EndpointConfiguration endpointConfiguration)
       where T : DbContext
    {
        var pipeline = endpointConfiguration.Pipeline;
        pipeline.Register(new DbContextManagerBehavior<T>(), $"Manage {typeof(T)} unit of work");

        endpointConfiguration.RegisterComponents(c => c.ConfigureComponent<DbContextWrapper<T>>(DependencyLifecycle.SingleInstance));
    }
}
