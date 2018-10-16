using Abp.EntityFrameworkCore;
using CoreMvc8.Books;
using CoreMvc8.EntityFrameworkCore;
using CoreMvc8.EntityFrameworkCore.Repositories;
using CoreMvc8.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreMvc8.Repositories
{
    public class BookRepository:CoreMvc8RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(IDbContextProvider<CoreMvc8DbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        public Book GetBookById(int Id)
        {
            var query = FirstOrDefault(Id);
            
            return query;
     
        }
    }
}
