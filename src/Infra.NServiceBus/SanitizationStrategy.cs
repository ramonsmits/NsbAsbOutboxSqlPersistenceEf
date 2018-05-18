using NServiceBus;
using NServiceBus.Transport.AzureServiceBus;

namespace Infra.NServiceBus
{
    public class SanitizationStrategy : ISanitizationStrategy
    {
        public string Sanitize(string entityPathOrName, EntityType entityType)
        {
            if (entityType == EntityType.Subscription)
            {
                var len = 50 >= entityPathOrName.Length ? 0 : entityPathOrName.Length - 50;
                return entityPathOrName.Substring(len);
            }

            return entityPathOrName;
        }
    }

}
