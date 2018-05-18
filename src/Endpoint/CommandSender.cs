using System;
using System.Threading.Tasks;
using NServiceBus;

class EndpointConfig
{
    public class CommandSender : IWantToRunWhenEndpointStartsAndStops
    {
        public async Task Start(IMessageSession session)
        {
            // Not return task, forking a new thread!
#pragma warning disable 4014
            Task.Run(() => Loop(session));
#pragma warning restore 4014
        }

        async void Loop(IMessageSession session)
        {
            Console.WriteLine("Press enter to send Place Order Command");

            var i = 0;

            while (true)
            {
                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.Enter)
                {
                    await session.SendLocal(
                        new PlaceOrderCommand
                        {
                            OrderId = Guid.NewGuid(),
                            OrderNumber = ++i,
                            PlacedAtDate = DateTime.UtcNow
                        })
                        .ConfigureAwait(false);
                    Console.WriteLine($"Place Order Command sent {i}");
                }
            }
        }

        public Task Stop(IMessageSession session)
        {
            return Task.CompletedTask;
        }
    }
}
