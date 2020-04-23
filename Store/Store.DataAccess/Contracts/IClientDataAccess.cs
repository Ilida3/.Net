using Store.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Domain;
using Store.Domain.Contracts;

namespace Store.DataAccess.Contracts
{
    public interface IClientDataAccess
    {
        Task<Client> InsertAsync(ClientUpdateModel client);
        Task<IEnumerable<Client>> GetAsync();
        Task<Client> GetAsync(IClientIdentity clientId);
        Task<Client> UpdateAsync(ClientUpdateModel client);
        Task<Client> GetByAsync(IClientContainer client);
    }
}
