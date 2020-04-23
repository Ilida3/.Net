using Store.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Domain.Models
{
    public class OrderUpdateModel : IOrderIdentity, IBookContainer, IClientContainer
    {
        //идентификатор
        public int Id { get; set; }

        //Время покупки
        public string Time { get; set; }

        //Дата покупки
        public string Date { get; set; }

        public int? ClientId { get; set; }

        public int? BookId { get; set; }
    }
}
