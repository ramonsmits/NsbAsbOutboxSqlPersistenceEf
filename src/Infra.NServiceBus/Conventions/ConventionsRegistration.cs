using NServiceBus;

class ConventionsRegistration : INeedInitialization
{
    public void Customize(EndpointConfiguration configuration)
    {
        configuration.Conventions().DefiningCommandsAs(MessageConventions.IsCommand);
        configuration.Conventions().DefiningDataBusPropertiesAs(MessageConventions.IsDataBusProperty);
        configuration.Conventions().DefiningEventsAs(MessageConventions.IsEvent);
        configuration.Conventions().DefiningMessagesAs(MessageConventions.IsMessage);
        configuration.Conventions().DefiningExpressMessagesAs(MessageConventions.IsExpressMessage);
        configuration.Conventions().DefiningTimeToBeReceivedAs(MessageConventions.IsExpiringMessage);
    }
}
