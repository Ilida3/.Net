using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Store.Client.Requests.Create
{
    public class BookCreateDTO
    {
        // название книги
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        // автор книги
        [Required(ErrorMessage = "Author is required")]
        public string Author { get; set; }

        // цена
        [Required(ErrorMessage = "Price is required")]
        public int Price { get; set; }

        // год выпуска
        [Required(ErrorMessage = "Year is required")]
        public int Year { get; set; }
    }
}
