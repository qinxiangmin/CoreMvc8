using System;
using System.Collections.Generic;
using Abp.Authorization.Users;
using Abp.Extensions;
using CoreMvc8.Books;
using CoreMvc8.Movies;

namespace CoreMvc8.Authorization.Users
{
    public class User : AbpUser<User>
    {
        public const string DefaultPassword = "123qwe";

        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }

        public static User CreateTenantAdminUser(int tenantId, string emailAddress)
        {
            var user = new User
            {
                TenantId = tenantId,
                UserName = AdminUserName,
                Name = AdminUserName,
                Surname = AdminUserName,
                EmailAddress = emailAddress
            };

            user.SetNormalizedNames();

            return user;
        }

        public string UserImageUrl { get; set; }

       // public List<Book> Book { get; set; }

        public List<Movie> Movie { get; set; }
    }
}
