using CoreMvc8.Books.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMvc8.Web.Models.Books
{
    public class BookListViewModel
    {
        public IReadOnlyList<BookListoutput> Books { get; set; }
        public BookListViewModel(IReadOnlyList<BookListoutput> books)
        {
            Books = books;
        }
    }
}
