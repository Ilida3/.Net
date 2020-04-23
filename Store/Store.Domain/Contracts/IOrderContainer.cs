using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Domain.Contracts
{
    public interface IOrderContainer
    {
        public int? OrderId { get; }
    }
}
