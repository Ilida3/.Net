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
    public class ClientGetService : IClientGetService
    {
        private IClientDataAccess ClientDataAccess { get; }

        public ClientGetService(IClientDataAccess clientDataAccess)
        {
            this.ClientDataAccess = clientDataAccess;
        }

        public Task<IEnumerable<Client>> GetAsync()
        {
            return this.ClientDataAccess.GetAsync();
        }

        public Task<Client> GetAsync(IClientIdentity client)
        {
            return this.ClientDataAccess.GetAsync(client);
        }

        public async Task ValidateAsync(IClientContainer clientContainer)
        {
            if (clientContainer == null)
            {
                throw new ArgumentNullException(nameof(clientContainer));
            }

            var client = await this.GetBy(clientContainer);

            if (clientContainer.ClientId.HasValue && client == null)
            {
                throw new InvalidOperationException($"Client not found by id {clientContainer.ClientId}");
            }
        }

        private Task<Client> GetBy(IClientContainer clientContainer)
        {
            return this.ClientDataAccess.GetByAsync(clientContainer);
        }
    }
}
