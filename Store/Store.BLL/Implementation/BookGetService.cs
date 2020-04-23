using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Store.BLL.Contracts;
using Store.DataAccess.Contracts;
using Store.Domain;
using Store.Domain.Contracts;

namespace Store.BLL.Implementation
{
    public class BookGetService : IBookGetService
    {
        private IBookDataAccess BookDataAccess { get; }

        public BookGetService(IBookDataAccess bookDataAccess)
        {
            this.BookDataAccess = bookDataAccess;
        }
        public Task<IEnumerable<Book>> GetAsync()
        {
            return this.BookDataAccess.GetAsync();
        }

        public Task<Book> GetAsync(IBookIdentity book)
        {
            return this.BookDataAccess.GetAsync(book);
        }

        public async Task ValidateAsync(IBookContainer bookContainer)
        {
            if (bookContainer == null)
            {
                throw new ArgumentNullException(nameof(bookContainer));
            }

            var book = await this.GetBy(bookContainer);

            if (bookContainer.BookId.HasValue && book == null)
            {
                throw new InvalidOperationException($"Book not found by id {bookContainer.BookId}");
            }
        }
        private Task<Book> GetBy(IBookContainer bookContainer)
        {
            return this.BookDataAccess.GetByAsync(bookContainer);
        }
    }
}
