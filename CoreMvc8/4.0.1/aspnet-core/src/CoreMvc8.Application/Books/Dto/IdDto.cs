using Abp.Runtime.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreMvc8.Books.Dto
{
   public class IdDto:IShouldNormalize
    {
        [Required]
        public int Id { get; set; }

        public void Normalize()//数据验证有效后触发
        {
            if (Id == 0)
            {
                 Id = 9;
            }  
        }
    }
}
