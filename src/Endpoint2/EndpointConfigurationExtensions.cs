using System.Data.Entity;
using NServiceBus;

public static class EndpointConfigurationExtensions
{
    public static void EnablePersistAndPublish<TDbContext>(this EndpointConfiguration configuration)
       where TDbContext : DbContext
    {
        var pipeline = configuration.Pipeline;
        pipeline.Register(new PersistAndPublishBehavior<TDbContext>(), "Persist data in db and raise events if any");
        configuration.RegisterComponents(components => { components.ConfigureComponent<PersistAndPublishBehavior<TDbContext>>(DependencyLifecycle.InstancePerUnitOfWork); });
    }
}
