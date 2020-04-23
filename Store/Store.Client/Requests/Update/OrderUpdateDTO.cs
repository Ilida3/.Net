using System;
using System.Collections.Generic;
using System.Text;
using Store.Client.Requests.Create;

namespace Store.Client.Requests.Update
{
    public class OrderUpdateDTO : OrderCreateDTO
    {
        public int Id { get; set; }
    }
}
