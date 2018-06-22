using NServiceBus;

class TransportConfiguration : INeedInitialization
{
    public void Customize(EndpointConfiguration endpointConfiguration)
    {
        endpointConfiguration.UseTransport<LearningTransport>();
    }
}
