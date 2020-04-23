using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.DataAccess.Entities
{
    public partial class Book
    {
        public Book()
        {
            this.Order = new HashSet<Order>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public virtual ICollection<Order> Order { get; set; }

        // ID книги
        public int Id { get; set; }
        // название книги
        public string Name { get; set; }
        // автор книги
        public string Author { get; set; }
        // цена
        public int Price { get; set; }
        // год выпуска
        public int Year { get; set; }
    }
}