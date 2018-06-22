using System.Data.Entity;
using NServiceBus;

public static class EndpointConfigurationExtensions
{
    public static void EnablePersistAndPublish<TDbContext>(this EndpointConfiguration configuration)
       where TDbContext : DbContext
    {
        var pipeline = configuration.Pipeline;
        pipeline.Register(
            behavior: new PersistAndPublishBehavior<TDbContext>(),
            description: "Persist data in db and raise events if any");

        configuration.RegisterComponents(
            components =>
            {
                components.ConfigureComponent<PersistAndPublishBehavior<TDbContext>>(DependencyLifecycle.InstancePerUnitOfWork);
            });
    }
}
