using Store.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Domain;
using Store.Domain.Contracts;

namespace Store.DataAccess.Contracts
{
    public interface IOrderDataAccess
    {
        Task<Order> InsertAsync(OrderUpdateModel order);
        Task<IEnumerable<Order>> GetAsync();
        Task<Order> GetAsync(IOrderIdentity orderId);
        Task<Order> UpdateAsync(OrderUpdateModel order);
        Task<Order> GetByAsync(IOrderContainer order);
    }
}
