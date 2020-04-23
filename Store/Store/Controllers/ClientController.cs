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
    [Route("api/client")]
    public class ClientController : ControllerBase
    {
        private ILogger<ClientController> Logger { get; }
        private IClientCreateService ClientCreateService { get; }
        private IClientGetService ClientGetService { get; }
        private IClientUpdateService ClientUpdateService { get; }
        private IMapper Mapper { get; }

        public ClientController(ILogger<ClientController> logger, IMapper mapper, IClientCreateService clientCreateService, IClientGetService clientGetService, IClientUpdateService clientUpdateService)
        {
            this.Logger = logger;
            this.ClientCreateService = clientCreateService;
            this.ClientGetService = clientGetService;
            this.ClientUpdateService = clientUpdateService;
            this.Mapper = mapper;
        }

        [HttpPut]
        [Route("")]
        public async Task<ClientDTO> PutAsync(ClientCreateDTO client)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.ClientCreateService.CreateAsync(this.Mapper.Map<ClientUpdateModel>(client));

            return this.Mapper.Map<ClientDTO>(result);
        }

        [HttpPatch]
        [Route("")]
        public async Task<ClientDTO> PatchAsync(ClientUpdateDTO client)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.ClientUpdateService.UpdateAsync(this.Mapper.Map<ClientUpdateModel>(client));

            return this.Mapper.Map<ClientDTO>(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<ClientDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called");

            return this.Mapper.Map<IEnumerable<ClientDTO>>(await this.ClientGetService.GetAsync());
        }

        [HttpGet]
        [Route("{clientId}")]
        public async Task<ClientDTO> GetAsync(int clientId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {clientId}");

            return this.Mapper.Map<ClientDTO>(await this.ClientGetService.GetAsync(new ClientIdentityModel(clientId)));
        }
    }
}
