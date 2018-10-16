using Abp.Domain.Entities;
using CoreMvc8.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoreMvc8.Books
{
    public class Book:Entity
    {       
        [Required]
        public string BookName { get; set; }

        public decimal Price { get; set; }

        public long UserId { get; set; }
        [ForeignKey(nameof(UserId))]

        public User User { get; set; }
    }
}
