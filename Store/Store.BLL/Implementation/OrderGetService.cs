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
    public class OrderGetService : IOrderGetService
    {
        private IOrderDataAccess OrderDataAccess { get; }

        public OrderGetService(IOrderDataAccess orderDataAccess)
        {
            this.OrderDataAccess = orderDataAccess;
        }
        public Task<IEnumerable<Order>> GetAsync()
        {
            return this.OrderDataAccess.GetAsync();
        }

        public Task<Order> GetAsync(IOrderIdentity order)
        {
            return this.OrderDataAccess.GetAsync(order);
        }

        public async Task ValidateAsync(IOrderContainer orderContainer)
        {
            if (orderContainer == null)
            {
                throw new ArgumentNullException(nameof(orderContainer));
            }

            var order = await this.GetBy(orderContainer);

            if (orderContainer.OrderId.HasValue && order == null)
            {
                throw new InvalidOperationException($"Order not found by id {orderContainer.OrderId}");
            }
        }
        private Task<Order> GetBy(IOrderContainer orderContainer)
        {
            return this.OrderDataAccess.GetByAsync(orderContainer);
        }
    }
}
