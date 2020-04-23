using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
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
    [Route("api/book")]
    public class BookController : ControllerBase
    {
        private ILogger<BookController> Logger { get; }
        private IBookCreateService BookCreateService { get; }
        private IBookGetService BookGetService { get; }
        private IBookUpdateService BookUpdateService { get; }
        private IMapper Mapper { get; }

        public BookController(ILogger<BookController> logger, IMapper mapper, IBookCreateService bookCreateService, IBookGetService bookGetService, IBookUpdateService bookUpdateService)
        {
            this.Logger = logger;
            this.BookCreateService = bookCreateService;
            this.BookGetService = bookGetService;
            this.BookUpdateService = bookUpdateService;
            this.Mapper = mapper;
        }

        [HttpPut]
        [Route("")]
        public async Task<BookDTO> PutAsync(BookCreateDTO book)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.BookCreateService.CreateAsync(this.Mapper.Map<BookUpdateModel>(book));

            return this.Mapper.Map<BookDTO>(result);
        }

        [HttpPatch]
        [Route("")]
        public async Task<BookDTO> PatchAsync(BookUpdateDTO book)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.BookUpdateService.UpdateAsync(this.Mapper.Map<BookUpdateModel>(book));

            return this.Mapper.Map<BookDTO>(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<BookDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called");

            return this.Mapper.Map<IEnumerable<BookDTO>>(await this.BookGetService.GetAsync());
        }

        [HttpGet]
        [Route("{bookId}")]
        public async Task<BookDTO> GetAsync(int bookId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {bookId}");

            return this.Mapper.Map<BookDTO>(await this.BookGetService.GetAsync(new BookIdentityModel(bookId)));
        }
    }
}
