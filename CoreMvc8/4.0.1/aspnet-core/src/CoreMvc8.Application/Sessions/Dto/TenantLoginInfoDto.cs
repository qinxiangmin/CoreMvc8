﻿using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using CoreMvc8.MultiTenancy;

namespace CoreMvc8.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
