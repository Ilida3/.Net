using Store.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Domain.Models
{
    public class OrderIdentityModel : IOrderIdentity
    {
        public int Id { get; }

        public OrderIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}
