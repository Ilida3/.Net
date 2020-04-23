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
    public class OrderCreateServiceTests
    {
        [Test]
        public async Task CreateAsync_OrderValidationSucceed_CreateOrder()
        {
            // Arrange
            var order = new OrderUpdateModel();
            var expected = new Order();

            var bookGetService = new Mock<IBookGetService>();
           bookGetService.Setup(x => x.ValidateAsync(order));

            var clientGetService = new Mock<IClientGetService>();
            clientGetService.Setup(x => x.ValidateAsync(order));

            var orderDataAccess = new Mock<IOrderDataAccess>();
            orderDataAccess.Setup(x => x.InsertAsync(order)).ReturnsAsync(expected);

            var orderGetService = new OrderCreateService(orderDataAccess.Object, bookGetService.Object, clientGetService.Object);

            // Act
            var result = await orderGetService.CreateAsync(order);

            // Assert
            result.Should().Be(expected);
        }

        [Test]
        public async Task CreateAsync_OrderValidationFailed_ThrowsError()
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

            var orderGetService = new OrderCreateService(orderDataAccess.Object, bookGetService.Object, clientGetService.Object);

            // Act
            var action = new Func<Task>(() => orderGetService.CreateAsync(order));

            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            orderDataAccess.Verify(x => x.InsertAsync(order), Times.Never);
        }
    }
}
