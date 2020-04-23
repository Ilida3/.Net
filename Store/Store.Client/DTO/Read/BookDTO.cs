using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Client.DTO.Read
{
    public class BookDTO
    {
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
