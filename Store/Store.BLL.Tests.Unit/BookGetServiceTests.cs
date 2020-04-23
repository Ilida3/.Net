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
    public class BookGetServiceTests
    {
        [Test]
        public async Task ValidateAsync_BookExists_DoesNothing()
        {
            // Arrange
            var bookContainer = new Mock<IBookContainer>();

            var book = new Book();
            var bookDataAccess = new Mock<IBookDataAccess>();
            bookDataAccess.Setup(x => x.GetByAsync(bookContainer.Object)).ReturnsAsync(book);

            var bookGetService = new BookGetService(bookDataAccess.Object);

            // Act
            var action = new Func<Task>(() => bookGetService.ValidateAsync(bookContainer.Object));

            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }

        [Test]
        public async Task ValidateAsync_BookNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();

            var bookContainer = new Mock<IBookContainer>();
            bookContainer.Setup(x => x.BookId).Returns(id);

            var book = new Book();
            var bookDataAccess = new Mock<IBookDataAccess>();
            bookDataAccess.Setup(x => x.GetByAsync(bookContainer.Object)).ReturnsAsync((Book)null);

            var bookGetService = new BookGetService(bookDataAccess.Object);

            // Act
            var action = new Func<Task>(() => bookGetService.ValidateAsync(bookContainer.Object));

            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Book not found by id {id}");
        }
    }
}
