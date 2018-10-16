using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreMvc8.Books.Dto
{
    public class BookDto:EntityDto
    {
        [Required]
        public string BookName { get; set; }

        public decimal Price { get; set; }

       
    }
}
