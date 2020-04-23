using System;
using System.Collections.Generic;
using System.Text;
using Store.Client.Requests.Create;

namespace Store.Client.Requests.Update
{
   public class BookUpdateDTO : BookCreateDTO
    {
        public int Id { get; set; }
    }
}
