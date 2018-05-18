using System.Threading.Tasks;
using NServiceBus;

class Program
{
    public static async Task Main()
    {
        var endpointConfiguration = new EndpointConfiguration("Endpoint");
        endpointConfiguration.EnableOutbox();

        endpointConfiguration.ConfigureDbContextManager<OrderDbContext>();
        endpointConfiguration.RegisterComponents(c=>c.ConfigureComponent<OrderStorageContext>(DependencyLifecycle.SingleInstance));
        
        endpointConfiguration.EnableInstallers();

        var instance = await Endpoint.Start(endpointConfiguration);
        await Task.Delay(-1);
        // Unreachable
        await instance.Stop();
    }
}