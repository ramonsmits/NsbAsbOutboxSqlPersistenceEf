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

