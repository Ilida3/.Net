using Store.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Domain
{
    public class Order : IBookContainer, IClientContainer
    {
        //идентификатор
        public int Id { get; set; }

        //Информация о книге
        public Book Book { get; set; }

        //Время покупки
        public string Time { get; set; }

        //Дата покупки
        public string Date { get; set; }

        //Информация о покупателе
        public Client Client { get; set; }

        public int? ClientId => Client.Id;

        public int? BookId => Book.Id;
    }
}
