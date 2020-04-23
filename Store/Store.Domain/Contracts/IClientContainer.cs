using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Domain.Contracts
{
    public interface IClientContainer
    {
        public int? ClientId { get; }
    }
}
