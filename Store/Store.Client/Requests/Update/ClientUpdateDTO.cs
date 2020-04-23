using System;
using Store.Client.Requests.Create;

namespace Store.Client.Requests.Update
{
    public class ClientUpdateDTO : ClientCreateDTO
    {
        public int Id { get; set; }
    }
}
