using System;
using System.Collections.Generic;
using System.Text;

namespace CoreMvc8.TestDemo
{
    public class PassageCategory
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public long PassageId { get; set; }

        public Passage Passage { get; set; }

    }
}
