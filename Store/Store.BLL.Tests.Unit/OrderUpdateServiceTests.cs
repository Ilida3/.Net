using System;
using System.Threading.Tasks;
using AutoFixture;
using Store.BLL.Implementation;
using Store.DataAccess.Contracts;
using Store.Domain;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Store.Domain.Models;
using Store.BLL.Contracts;

namespace Store.BLL.Tests.Unit
{
    public class Tests
    {
        [Test]
        public async Task UpdateAsync_OrderValidationSucceed_CreatesOrder()
        {
            // Arrange
            var order = new OrderUpdateModel();
            var expected = new Order();

            var bookGetService = new Mock<IBookGetService>();
            bookGetService.Setup(x => x.ValidateAsync(order));

            var clientGetService = new Mock<IClientGetService>();
            clientGetService.Setup(x => x.ValidateAsync(order));

            var orderDataAccess = new Mock<IOrderDataAccess>();
            orderDataAccess.Setup(x => x.UpdateAsync(order)).ReturnsAsync(expected);

            var orderGetService = new OrderUpdateService(orderDataAccess.Object, bookGetService.Object, clientGetService.Object);

            // Act
            var result = await orderGetService.UpdateAsync(order);

            // Assert
            result.Should().Be(expected);
        }

        [Test]
        public async Task UpdateAsync_OrderValidationFailed_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var order = new OrderUpdateModel();
            var expected = fixture.Create<string>();

            var bookGetService = new Mock<IBookGetService>();
            bookGetService
                .Setup(x => x.ValidateAsync(order))
                .Throws(new InvalidOperationException(expected));

            var clientGetService = new Mock<IClientGetService>();
            clientGetService.Setup(x => x.ValidateAsync(order)).Throws(new InvalidOperationException(expected));


            var orderDataAccess = new Mock<IOrderDataAccess>();

            var orderGetService = new OrderUpdateService(orderDataAccess.Object, bookGetService.Object, clientGetService.Object);

            // Act
            var action = new Func<Task>(() => orderGetService.UpdateAsync(order));

            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            orderDataAccess.Verify(x => x.UpdateAsync(order), Times.Never);
        }
    }
}