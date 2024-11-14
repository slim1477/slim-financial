using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SlimFinancial.Domain.Models;
using SlimFinancial.Infrastructure.Data.Configurations;




namespace SlimFinancial.Infrastructure.Data;
/// <summary>
/// Represents the application Database context
/// </summary>
/// <param name="options"></param>
public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityUserContext<Person,int>(options)
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new PersonDbConfig());
            builder.ApplyConfiguration(new TransactionDbConfig());
            builder.ApplyConfiguration(new AccountDbConfig());
            builder.ApplyConfiguration(new DebitCardDbConfig());
            builder.ApplyConfiguration(new AccountTransactionDbConfig());
            builder.ApplyConfiguration(new PersonAccountDbConfig());
            builder.ApplyConfiguration(new PersonDebitCardDbConfig());
            builder.ApplyConfiguration(new AccountDebitCardConfig());
            //builder.ApplyConfiguration(new IdentityUserClaimDbConfig());
            
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<DebitCard> DebitCards { get; set; }
        public DbSet<AccountTransaction> AccountTransactions { get; set; }
        public DbSet<PersonAccount> PersonAccounts { get; set; }
        public DbSet<PersonDebitCard> PersonDebitCards { get; set; }
    }

