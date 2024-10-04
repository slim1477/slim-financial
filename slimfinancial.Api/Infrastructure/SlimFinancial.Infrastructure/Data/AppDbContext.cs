
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SlimFinancial.Domain.Models.Entity;




namespace SlimFinancial.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<Person>(options)
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            


        }

        private DbSet<Person> Persons { get; set; }
        private DbSet<Transaction> Transactions { get; set; }
        private DbSet<Account> Accounts { get; set; }
        private DbSet<DebitCard> DebitCards { get; set; }
    }
}
