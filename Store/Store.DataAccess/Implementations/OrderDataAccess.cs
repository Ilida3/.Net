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

namespace Store.DataAccess.Implementations
{
    public class OrderDataAccess : IOrderDataAccess
    {
        private BookStoreContext Context { get; }
        private IMapper Mapper { get; }

        public OrderDataAccess(BookStoreContext context, IMapper mapper)
        {
            this.Context = context;
            Mapper = mapper;
        }

        public async Task<Order> InsertAsync(OrderUpdateModel order)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<DataAccess.Entities.Order>(order));
            await this.Context.SaveChangesAsync();
            return this.Mapper.Map<Order>(result.Entity);
        }

        public async Task<IEnumerable<Order>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<Order>>(await this.Context.Order.Include(x => x.Book).Include(x => x.Client).ToListAsync());
        }

        public async Task<Order> GetAsync(IOrderIdentity orderId)
        {

            var result = await this.Get(orderId);
            return this.Mapper.Map<Order>(result);
        }

        private async Task<Store.DataAccess.Entities.Order> Get(IOrderIdentity orderId)
        {

            if (orderId == null)
                throw new ArgumentNullException(nameof(orderId));
            return await this.Context.Order.Include(x => x.Book).Include(x => x.Client).FirstOrDefaultAsync(x => x.Id == orderId.Id);

        }

        public async Task<Order> UpdateAsync(OrderUpdateModel order)
        {
            var existing = await this.Get(order);

            var result = this.Mapper.Map(order, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Order>(result);
        }

        public async Task<Order> GetByAsync(IOrderContainer order)
        {
            return order.OrderId.HasValue
                ? this.Mapper.Map<Order>(await this.Context.Order.FirstOrDefaultAsync(x => x.Id == order.OrderId))
                : null;
        }
    }
}
