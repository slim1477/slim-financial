
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SlimFinancial.Domain.Models.Entity;
using SlimFinancial.Infrastructure.Data.Configurations;




namespace SlimFinancial.Infrastructure.Data;
/// <summary>
/// Represents the application Database context
/// </summary>
/// <param name="options"></param>
    public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<Person>(options)
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new PersonDbConfig());
            builder.ApplyConfiguration(new TransactionDbConfig());
            builder.ApplyConfiguration(new AccountDbConfig());
            builder.ApplyConfiguration(new DebitCardDbConfig());
            
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<DebitCard> DebitCards { get; set; }
    }

