using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using CoreMvc8.Authorization.Roles;
using CoreMvc8.Authorization.Users;
using CoreMvc8.MultiTenancy;
using CoreMvc8.Books;
using CoreMvc8.Movies;
using CoreMvc8.TestDemo;

namespace CoreMvc8.EntityFrameworkCore
{
    public class CoreMvc8DbContext : AbpZeroDbContext<Tenant, Role, User, CoreMvc8DbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Book> Book { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Passage> Passage { get; set; }
        public DbSet<PassageCategory> PassageCategory { get; set; }
       
        public CoreMvc8DbContext(DbContextOptions<CoreMvc8DbContext> options)
            : base(options)
        {
        }
    }
}
