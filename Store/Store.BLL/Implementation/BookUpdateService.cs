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
   public class BookUpdateService : IBookUpdateService
    {
        private IBookDataAccess BookDataAccess { get; }

        public BookUpdateService(IBookDataAccess bookDataAccess)
        {
            BookDataAccess = bookDataAccess;
        }

        public Task<Book> UpdateAsync(BookUpdateModel book)
        {
            return BookDataAccess.UpdateAsync(book);
        }
    }
}
