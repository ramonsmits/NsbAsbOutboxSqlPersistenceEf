using System;
using System.Threading.Tasks;
using Domain;
using Infra.NServiceBus;
using NServiceBus;

namespace Endpoint2
{
    public partial class EndpointConfig : IConfigureThisEndpoint, AsA_Worker
    {
        public void Customize(EndpointConfiguration endpointConfiguration)
        {
            endpointConfiguration.DefineEndpointName("Endpoint2");
            endpointConfiguration.EnableOutbox();
            endpointConfiguration.EnablePersistAndPublish<OrderDbContext>();
        }

    }
}


class Program
{
    public static async Task Main()
    {
        var cfg = new EndpointConfiguration("Endpoint2");
        var instance = await Endpoint.Start(cfg);
        await Task.Delay(-1);
        await instance.Stop();
    }
}