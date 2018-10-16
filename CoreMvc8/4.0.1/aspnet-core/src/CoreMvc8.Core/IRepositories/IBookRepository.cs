using Abp.Domain.Repositories;
using CoreMvc8.Books;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreMvc8.IRepositories
{
    public interface IBookRepository:IRepository<Book>
    {
        Book GetBookById(int Id);
    }
}
