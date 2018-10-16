using Abp.Domain.Entities;
using CoreMvc8.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreMvc8.Movies
{
   public class Movie:Entity
    {
        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }
        
        public User User { get; set; }
    }
}
