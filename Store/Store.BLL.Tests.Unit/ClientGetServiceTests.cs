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
    public class ClientGetServiceTests
    {
        [Test]
        public async Task ValidateAsync_ClientExists_DoesNothing()
        {
            // Arrange
            var clientContainer = new Mock<IClientContainer>();

            var client = new Client();
            var clientDataAccess = new Mock<IClientDataAccess>();
            clientDataAccess.Setup(x => x.GetByAsync(clientContainer.Object)).ReturnsAsync(client);

            var clientGetService = new ClientGetService(clientDataAccess.Object);

            // Act
            var action = new Func<Task>(() => clientGetService.ValidateAsync(clientContainer.Object));

            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }

        [Test]
        public async Task ValidateAsync_ClientNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();

            var clientContainer = new Mock<IClientContainer>();
            clientContainer.Setup(x => x.ClientId).Returns(id);

            var client = new Client();
            var clientDataAccess = new Mock<IClientDataAccess>();
            clientDataAccess.Setup(x => x.GetByAsync(clientContainer.Object)).ReturnsAsync((Client)null);

            var clientGetService = new ClientGetService(clientDataAccess.Object);

            // Act
            var action = new Func<Task>(() => clientGetService.ValidateAsync(clientContainer.Object));

            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Client not found by id {id}");
        }
    }
}
