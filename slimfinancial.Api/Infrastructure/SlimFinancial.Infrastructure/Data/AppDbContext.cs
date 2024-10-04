using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SlimFinancial.Domain.Models.Entity;
using System;



namespace SlimFinancial.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var harsher = builder.Entity<IdentityUser>();


        }

        DbSet<Person> Persons { get; set; }
        DbSet<Transaction> Transactions { get; set; }
        DbSet<Account> Accounts { get; set; }
    }
}
