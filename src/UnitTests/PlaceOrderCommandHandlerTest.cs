using System;
using System.Collections.Generic;
using System.Linq;
using EntityFramework.FakeItEasy;
using Moq;
using NServiceBus.Testing;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class PlaceOrderCommandHandlerTest
    {
        PlaceOrderCommandHandler handler;
        readonly List<Order> orders = new List<Order>();
        DateTime placedAtDate;
        Guid orderId;

        [TestFixtureSetUp]
        public async void Setup()
        {
            var dbContext = new OrderDbContext
            {
                Orders = Aef.FakeDbSet(orders)
            };

            placedAtDate = DateTime.UtcNow;
            orderId = new Guid("DE81F6B5-7F29-4AE7-A72B-023F6B58DE72");
            var placeOrderCommand = new PlaceOrderCommand
            {
                OrderId = orderId,
                OrderNumber = 100,
                PlacedAtDate = placedAtDate
            };

            var context = new TestableMessageHandlerContext();

            var orderStorageContextMock = new Mock<IOrderStorageContext>();
            orderStorageContextMock.SetupIgnoreArgs(x => x.Get(null)).Returns(dbContext);

            handler = new PlaceOrderCommandHandler(orderStorageContextMock.Object);

            try
            {
                await handler.Handle(placeOrderCommand, context);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [Test]
        public void Order_Should_Be_Placed_at_correct_date()
        {
            Assert.AreEqual(orders.Single(x => x.OrderId == orderId).PlacedAtDate, placedAtDate);
        }
    }
}
