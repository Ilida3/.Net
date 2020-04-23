using Store.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Domain;
using Store.Domain.Contracts;

namespace Store.DataAccess.Contracts
{
    public interface IBookDataAccess
    {
        Task<Book> InsertAsync(BookUpdateModel book);
        Task<IEnumerable<Book>> GetAsync();
        Task<Book> GetAsync(IBookIdentity bookId);
        Task<Book> UpdateAsync(BookUpdateModel book);
        Task<Book> GetByAsync(IBookContainer book);
    }
}
