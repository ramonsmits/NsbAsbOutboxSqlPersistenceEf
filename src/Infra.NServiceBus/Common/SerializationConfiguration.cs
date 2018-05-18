using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;

namespace Infra.NServiceBus.Common
{
    class SerializationConfiguration : INeedInitialization
    {
        public void Customize(EndpointConfiguration endpointConfiguration)
        {
            endpointConfiguration.UseSerialization<JsonSerializer>();
        }
    }
}
