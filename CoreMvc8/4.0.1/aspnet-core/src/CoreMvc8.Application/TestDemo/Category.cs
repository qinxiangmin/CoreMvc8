using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreMvc8.TestDemo
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [MaxLength(50)]
        public string CategoryName { get; set; }

        public virtual IList<PassageCategory> PassageCategories { get; set; }

    }
}
