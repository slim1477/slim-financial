

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlimFinancial.Domain.Models;

namespace SlimFinancial.Infrastructure.Data.Configurations;

public class AccountDbConfig : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.HasKey(a => a.AccountNumber);
        //builder.Property(a => a.AccountNumber)
        //        .HasComputedColumnSql("CAST(AccountNumber AS TEXT)", stored: true);
        builder.Property(a => a.AccountNumber)
               .HasDefaultValue(1100100100)
               .HasAnnotation("Sqlite:Autoincrement", true)
               .ValueGeneratedOnAdd();

        //builder.HasData(
        //new Account
        //{
        //    Id = "f215f808-69e6-4377-8be7-7a68bde38cdd",
        //    AccountNumber = "110012569855",
        //    Type = AccountType.Savings,
        //    Balance = 2000,
        //},
        //new Account
        //{
        //    Id = "a6c6a48d-e149-4086-936b-3ec693e39ab4",
        //    AccountNumber = "110016633598",
        //    Type = AccountType.Checking,
        //    Balance = 5000,
        //},
        //     new Account
        //     {
        //         Id = "bfdfd2fc-77b2-4f2a-a703-66a46a0a30a7",
        //         AccountNumber = "11001255989",
        //         Type = AccountType.Savings,
        //         Balance = 2000,
        //     },
        //new Account
        //{
        //    Id = "f33c6a2c-c167-46de-aaf9-07652ae1e4d1",
        //    AccountNumber = "110016633598",
        //    Type = AccountType.Checking,
        //    Balance = 5000,
        //}
        //);
    }
 
}

