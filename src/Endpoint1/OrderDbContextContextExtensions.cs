using Domain;
using NServiceBus;

namespace Endpoint1
{
    public static class OrderDbContextContextExtensions
    {
        public static IOrderDbContext FakeOrderDbContext { get; set; }

        public static IOrderDbContext OrderDbContext(this IMessageHandlerContext context)
        {
            return FakeOrderDbContext ?? context.Extensions.Get<IOrderStorageContext>().GetOrderDbContext(context.SynchronizedStorageSession);
        }
    }
}