using NServiceBus;

class AuditErrorConfiguration : INeedInitialization
{
    public void Customize(EndpointConfiguration endpointConfiguration)
    {
        endpointConfiguration.AuditProcessedMessagesTo("audit");
        endpointConfiguration.SendFailedMessagesTo("error");
    }
}
