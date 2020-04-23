using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Store.Domain;
using Store.Domain.Contracts;

namespace Store.BLL.Contracts
{
    public interface IClientGetService
    {
        Task<IEnumerable<Client>> GetAsync();
        Task<Client> GetAsync(IClientIdentity client);
        Task ValidateAsync(IClientContainer storeContainer);
    }
}
