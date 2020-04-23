using AutoMapper;
using Store.Client.DTO.Read;
using Store.Client.Requests.Create;
using Store.Client.Requests.Update;
using Store.Domain.Models;

namespace Store
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<DataAccess.Entities.Book, Domain.Book>();
            this.CreateMap<DataAccess.Entities.Client, Domain.Client>();
            this.CreateMap<DataAccess.Entities.Order, Domain.Order>();
            this.CreateMap<Domain.Book, BookDTO>();
            this.CreateMap<Domain.Client, ClientDTO>();
            this.CreateMap<Domain.Order, OrderDTO>();

            this.CreateMap<BookCreateDTO, BookUpdateModel>();
            this.CreateMap<BookUpdateDTO, BookUpdateModel>();
            this.CreateMap<BookUpdateModel, DataAccess.Entities.Book>();

            this.CreateMap<ClientCreateDTO, ClientUpdateModel>();
            this.CreateMap<ClientUpdateDTO, ClientUpdateModel>();
            this.CreateMap<ClientUpdateModel, DataAccess.Entities.Client>();

            this.CreateMap<OrderCreateDTO, OrderUpdateModel>();
            this.CreateMap<OrderUpdateDTO, OrderUpdateModel>();
            this.CreateMap<OrderUpdateModel, DataAccess.Entities.Order>();
        }
    }
}
