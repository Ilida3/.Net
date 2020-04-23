using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Store.Domain;
using Store.Domain.Contracts;

namespace Store.BLL.Contracts
{
    public interface IOrderGetService
    {
        Task<IEnumerable<Order>> GetAsync();
        Task<Order> GetAsync(IOrderIdentity order);
        Task ValidateAsync(IOrderContainer storeContainer);
    }
}
