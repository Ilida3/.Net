using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Store.BLL.Contracts;
using Store.Client.DTO.Read;
using Store.Client.Requests.Create;
using Store.Client.Requests.Update;
using Store.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Store.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        private ILogger<OrderController> Logger { get; }
        private IOrderCreateService OrderCreateService { get; }
        private IOrderGetService OrderGetService { get; }
        private IOrderUpdateService OrderUpdateService { get; }
        private IMapper Mapper { get; }

        public OrderController(ILogger<OrderController> logger, IMapper mapper, IOrderCreateService orderCreateService, IOrderGetService orderGetService, IOrderUpdateService orderUpdateService)
        {
            this.Logger = logger;
            this.OrderCreateService = orderCreateService;
            this.OrderGetService = orderGetService;
            this.OrderUpdateService = orderUpdateService;
            this.Mapper = mapper;
        }

        [HttpPut]
        [Route("")]
        public async Task<OrderDTO> PutAsync(OrderCreateDTO order)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.OrderCreateService.CreateAsync(this.Mapper.Map<OrderUpdateModel>(order));

            return this.Mapper.Map<OrderDTO>(result);
        }

        [HttpPatch]
        [Route("")]
        public async Task<OrderDTO> PatchAsync(OrderUpdateDTO order)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.OrderUpdateService.UpdateAsync(this.Mapper.Map<OrderUpdateModel>(order));

            return this.Mapper.Map<OrderDTO>(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<OrderDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called");

            return this.Mapper.Map<IEnumerable<OrderDTO>>(await this.OrderGetService.GetAsync());
        }

        [HttpGet]
        [Route("{ordergId}")]
        public async Task<OrderDTO> GetAsync(int orderId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {orderId}");

            return this.Mapper.Map<OrderDTO>(await this.OrderGetService.GetAsync(new OrderIdentityModel(orderId)));
        }
    }
}
