using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.DataAccess.Entities
{
    public partial class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        //идентификатор
        public int Id { get; set; }

        //Время покупки
        public string Time { get; set; }

        //Дата покупки
        public string Date { get; set; }

        public int? ClientId { get; set; }

        public int? BookId { get; set; }

        //Информация о книге
        public virtual Book Book { get; set; }

        //Информация о покупателе
        public virtual Client Client { get; set; }
    }
}
