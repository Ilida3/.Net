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
    public class OrderUpdateService : IOrderUpdateService
    {
        private IOrderDataAccess OrderDataAccess { get; }
        private IClientGetService ClientGetService { get; }
        private IBookGetService BookGetService { get; }

        public OrderUpdateService(IOrderDataAccess orderDataAccess, IBookGetService bookGetService,
            IClientGetService clientGetService)
        {
            OrderDataAccess = orderDataAccess;
            ClientGetService = clientGetService;
            BookGetService = bookGetService;
        }

        public async Task<Order> UpdateAsync(OrderUpdateModel order)
        {
            await ClientGetService.ValidateAsync(order);
            await BookGetService.ValidateAsync(order);

            return await OrderDataAccess.UpdateAsync(order);

        }
    }
}
