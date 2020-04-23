using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Store.Domain;
using Store.Domain.Contracts;

namespace Store.BLL.Contracts
{
    public interface IBookGetService
    {
        Task<IEnumerable<Book>> GetAsync();
        Task<Book> GetAsync(IBookIdentity book);
        Task ValidateAsync(IBookContainer storeContainer);
    }
}
