using System;
using System.Threading.Tasks;
using AutoFixture;
using Store.BLL.Implementation;
using Store.DataAccess.Contracts;
using Store.Domain;
using Store.Domain.Contracts;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace Store.BLL.Tests.Unit
{
    public class OrderGetServiceTests
    {
        [Test]
        public async Task ValidateAsync_OrderExists_DoesNothing()
        {
            // Arrange
            var orderContainer = new Mock<IOrderContainer>();

            var order = new Order();
            var orderDataAccess = new Mock<IOrderDataAccess>();
            orderDataAccess.Setup(x => x.GetByAsync(orderContainer.Object)).ReturnsAsync(order);

            var orderGetService = new OrderGetService(orderDataAccess.Object);

            // Act
            var action = new Func<Task>(() => orderGetService.ValidateAsync(orderContainer.Object));

            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }

        [Test]
        public async Task ValidateAsync_OrderNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();

            var orderContainer = new Mock<IOrderContainer>();
            orderContainer.Setup(x => x.OrderId).Returns(id);

            var order = new Order();
            var orderDataAccess = new Mock<IOrderDataAccess>();
            orderDataAccess.Setup(x => x.GetByAsync(orderContainer.Object)).ReturnsAsync((Order)null);

            var orderGetService = new OrderGetService(orderDataAccess.Object);

            // Act
            var action = new Func<Task>(() => orderGetService.ValidateAsync(orderContainer.Object));

            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Order not found by id {id}");
        }
    }
}
