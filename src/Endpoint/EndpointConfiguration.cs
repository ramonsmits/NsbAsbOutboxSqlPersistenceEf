using System.Threading.Tasks;
using NServiceBus;

class Program
{
    public static async Task Main()
    {
        var endpointConfiguration = new EndpointConfiguration("Endpoint");
        endpointConfiguration.EnableOutbox();
        endpointConfiguration.EnableInstallers();

        endpointConfiguration.ConfigureDbContextManager<OrderDbContext>();


        var instance = await Endpoint.Start(endpointConfiguration);
        await Task.Delay(-1);
        // Unreachable
        await instance.Stop();
    }
}