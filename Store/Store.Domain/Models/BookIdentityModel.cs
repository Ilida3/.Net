using Store.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Domain.Models
{
    public class BookIdentityModel : IBookIdentity
    {
        public int Id { get; }

        public BookIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}