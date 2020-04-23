using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Client.DTO.Read
{
    public class OrderDTO
    {
        //идентификатор
        public int Id { get; set; }

        //Информация о книге
        public BookDTO Book { get; set; }

        //Время покупки
        public string Time { get; set; }

        //Дата покупки
        public string Date { get; set; }

        //Информация о покупателе
        public ClientDTO Client { get; set; }

    }
}
