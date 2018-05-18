using System;
using NServiceBus;

namespace Infra.NServiceBus.Recovery
{
    public class RecoveryConfiguration : INeedInitialization
    {
        public void Customize(EndpointConfiguration configuration)
        {
            var recoverability = configuration.Recoverability();
            recoverability.DisableLegacyRetriesSatellite();            
            recoverability.Immediate(
                customizations: immediate =>
                {
                    immediate.NumberOfRetries(3);
                });
            recoverability.Delayed(
                customizations: delayed =>
                {
                    var numberOfRetries = delayed.NumberOfRetries(5);
                    numberOfRetries.TimeIncrease(TimeSpan.FromSeconds(30));
                });
        }
    }
}
