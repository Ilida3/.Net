using Store.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Domain.Models
{
    public class ClientUpdateModel : IClientIdentity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }
    }
}
