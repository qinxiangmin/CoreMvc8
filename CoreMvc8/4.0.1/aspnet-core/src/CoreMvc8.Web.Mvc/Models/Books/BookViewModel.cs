﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMvc8.Web.Models.Books
{
    public class BookViewModel
    {
        public int Id { get; set; }

        public string BookName { get; set; }

        public decimal Price { get; set; }
        public string UserName { get; set; }
    }
}
