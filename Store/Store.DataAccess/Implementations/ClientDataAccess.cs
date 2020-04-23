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

namespace Store.DataAccess
{
    public class ClientDataAccess : IClientDataAccess
    {
        private BookStoreContext Context { get; }
        private IMapper Mapper { get; }

        public ClientDataAccess(BookStoreContext context, IMapper mapper)
        {
            this.Context = context;
            Mapper = mapper;
        }

        public async Task<Client> InsertAsync(ClientUpdateModel client)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<DataAccess.Entities.Client>(client));

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Client>(result.Entity);
        }

        public async Task<IEnumerable<Client>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<Client>>(
                await this.Context.Client.ToListAsync());
        }

        public async Task<Client> GetAsync(IClientIdentity client)
        {
            var result = await this.Get(client);

            return this.Mapper.Map<Client>(result);
        }

        public async Task<Client> UpdateAsync(ClientUpdateModel client)
        {
            var existing = await this.Get(client);

            var result = this.Mapper.Map(client, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Client>(result);
        }

        public async Task<Client> GetByAsync(IClientContainer client)
        {
            return client.ClientId.HasValue
                ? this.Mapper.Map<Client>(await this.Context.Client.FirstOrDefaultAsync(x => x.Id == client.ClientId))
                : null;
        }

        private async Task<Store.DataAccess.Entities.Client> Get(IClientIdentity client)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            return await this.Context.Client.FirstOrDefaultAsync(x => x.Id == client.Id);
        }
    }
}
