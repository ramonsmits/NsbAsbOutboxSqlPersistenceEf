using System;
using NServiceBus;

class RecoveryConfiguration : INeedInitialization
{
    public void Customize(EndpointConfiguration configuration)
    {
        var recoverability = configuration.Recoverability();
        recoverability.DisableLegacyRetriesSatellite();
        recoverability.Immediate(x => { x.NumberOfRetries(0); });
        recoverability.Delayed(x => { x.NumberOfRetries(0).TimeIncrease(TimeSpan.FromSeconds(30)); });
    }
}
