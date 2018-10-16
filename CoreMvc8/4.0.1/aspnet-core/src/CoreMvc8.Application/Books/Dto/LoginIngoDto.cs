using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreMvc8.Books.Dto
{
    public class LoginIngoDto:EntityDto
    {
        public string UserNameOrEmailAddress { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
