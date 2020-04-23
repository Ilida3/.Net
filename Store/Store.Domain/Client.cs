using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Domain
{
    public class Client
    {
        //ID клиента
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }
    }
}
