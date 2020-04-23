using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Store.BLL.Contracts;
using Store.DataAccess.Contracts;
using Store.Domain;
using Store.Domain.Models;

namespace Store.BLL.Implementation
{
    public class BookCreateService : IBookCreateService
    {
        private IBookDataAccess BookDataAccess { get; }

        public BookCreateService(IBookDataAccess bookDataAccess)
        {
            BookDataAccess = bookDataAccess;
        }

        public Task<Book> CreateAsync(BookUpdateModel book)
        {
            return BookDataAccess.InsertAsync(book);
        }
    }
}
