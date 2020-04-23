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
    public class ClientCreateService : IClientCreateService
    {
        private IClientDataAccess ClientDataAccess { get; }

        public ClientCreateService(IClientDataAccess clientDataAccess)
        {
            ClientDataAccess = clientDataAccess;
        }

        public Task<Client> CreateAsync(ClientUpdateModel client)
        {
            return ClientDataAccess.InsertAsync(client);
        }
    }
}
