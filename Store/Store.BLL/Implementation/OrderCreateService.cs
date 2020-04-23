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
    public class OrderCreateService : IOrderCreateService
    {
        private IOrderDataAccess OrderDataAccess { get; }
        private IClientGetService ClientGetService { get; }
        private IBookGetService BookGetService { get; }

        public OrderCreateService(IOrderDataAccess orderDataAccess, IBookGetService bookGetService,
            IClientGetService clientGetService)
        {
            OrderDataAccess = orderDataAccess;
            BookGetService = bookGetService;
            ClientGetService = clientGetService;
        }

        public async Task<Order> CreateAsync(OrderUpdateModel order)
        {
            await ClientGetService.ValidateAsync(order);
            await BookGetService.ValidateAsync(order);

            return await OrderDataAccess.InsertAsync(order);

        }
    }
}
