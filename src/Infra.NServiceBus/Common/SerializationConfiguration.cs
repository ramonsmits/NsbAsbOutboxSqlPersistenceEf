using NServiceBus;

class SerializationConfiguration : INeedInitialization
{
    public void Customize(EndpointConfiguration endpointConfiguration)
    {
        endpointConfiguration.UseSerialization<JsonSerializer>();
    }
}
