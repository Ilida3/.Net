using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Store.DataAccess.Context;
using Store.DataAccess.Contracts;
using Store.Domain;
using Store.Domain.Contracts;
using Store.Domain.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Store.DataAccess.Implementations
{
    public class BookDataAccess : IBookDataAccess
    {
        private BookStoreContext Context { get; }
        private IMapper Mapper { get; }

        public BookDataAccess(BookStoreContext context, IMapper mapper)
        {
            this.Context = context;
            Mapper = mapper;
        }

        public async Task<Book> InsertAsync(BookUpdateModel book)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<DataAccess.Entities.Book>(book));

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Book>(result.Entity);
        }

        public async Task<IEnumerable<Book>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<Book>>(
                await this.Context.Book.ToListAsync());

        }

        public async Task<Book> GetAsync(IBookIdentity book)
        {
            var result = await this.Get(book);

            return this.Mapper.Map<Book>(result);
        }

        public async Task<Book> UpdateAsync(BookUpdateModel book)
        {
            var existing = await this.Get(book);

            var result = this.Mapper.Map(book, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Book>(result);
        }

        public async Task<Book> GetByAsync(IBookContainer book)
        {
            return book.BookId.HasValue
                ? this.Mapper.Map<Book>(await this.Context.Book.FirstOrDefaultAsync(x => x.Id == book.BookId))
                : null;
        }

        private async Task<Store.DataAccess.Entities.Book> Get(IBookIdentity book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));
            return await this.Context.Book.FirstOrDefaultAsync(x => x.Id == book.Id);
        }
    }
}
