using NServiceBus;

class TransportConfiguration : INeedInitialization
{
    public void Customize(EndpointConfiguration endpointConfiguration)
    {
        var transport = endpointConfiguration.UseTransport<MsmqTransport>();
    }
}
