﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Store.Domain;
using Store.Domain.Models;

namespace Store.BLL.Contracts
{
    public interface IBookCreateService
    {
        Task<Book> CreateAsync(BookUpdateModel book);
    }
}
