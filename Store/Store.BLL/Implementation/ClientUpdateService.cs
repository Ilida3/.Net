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
    public class ClientUpdateService : IClientUpdateService
    {
        private IClientDataAccess ClientDataAccess { get; }

        public ClientUpdateService(IClientDataAccess clientDataAccess)
        {
            ClientDataAccess = clientDataAccess;
        }

        public Task<Client> UpdateAsync(ClientUpdateModel client)
        {
            return ClientDataAccess.UpdateAsync(client);
        }
    }
}
