using Store.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Domain.Models
{
    public class ClientIdentityModel : IClientIdentity
    {
        public int Id { get; }

        public ClientIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}
