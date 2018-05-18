using System;
using System.Reflection;

namespace Infra.NServiceBus.Conventions
{
    public class MessageConventions
    {
        public static bool IsCommand(Type t)
        {
            return t.Namespace != null && (t.Namespace.EndsWith("Commands"));
        }

        public static bool IsEvent(Type t)
        {
            return t.Namespace != null && (t.Namespace.EndsWith("Events"));
        }

        public static bool IsMessage(Type t)
        {
            return t.Namespace != null && (t.Namespace.EndsWith("Messages"));
        }

        public static bool IsExpressMessage(Type t)
        {
            return t.Name.EndsWith("Express");
        }

        public static TimeSpan IsExpiringMessage(Type t)
        {
            return t.Name.EndsWith("Expires") ? TimeSpan.FromSeconds(30) : TimeSpan.MaxValue;
        }

        public static bool IsDataBusProperty(PropertyInfo pi)
        {
            return pi.Name.EndsWith("Data");
        }

        public static bool IsEncryptedProperty(PropertyInfo pi)
        {
            return pi.Name.EndsWith("Encrypted");
        }
    }
}
