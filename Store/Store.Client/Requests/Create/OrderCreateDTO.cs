using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Store.Client.Requests.Create
{
   public class OrderCreateDTO
    {
        //Информация о книге
        public int? BookId { get; set; }

        //Время покупки
        [Required(ErrorMessage = "Time is required")]
        public string Time { get; set; }

        //Дата покупки
        [Required(ErrorMessage = "Date is required")]
        public string Date { get; set; }

        //Информация о покупателе
        public int? ClientId { get; set; }
    }
}
