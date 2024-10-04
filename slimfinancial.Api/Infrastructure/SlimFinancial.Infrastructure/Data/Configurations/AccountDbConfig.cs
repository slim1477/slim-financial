

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlimFinancial.Domain.Models.Common.Enums;
using SlimFinancial.Domain.Models.Entity;

namespace SlimFinancial.Infrastructure.Data.Configurations;

public class AccountDbConfig : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.HasKey(a => a.Id);
        builder.HasMany<Transaction>().WithOne().HasForeignKey(t => t.Id);
        builder.HasMany(jo => jo.JointOwners)
                .WithMany(a => a.Accounts)
                .UsingEntity(
                        ac =>
                        {
                            ac.Property("JointOwnersId").HasColumnName("PersonId");
                        }
                            );
        builder.HasData(
        new Account
        {
            Id = "f215f808-69e6-4377-8be7-7a68bde38cdd",
            OwnerId = "337f5059-c404-4d22-8128-f8297258856f",
            AccountNumber = "110012569855",
            Type = AccountType.Savings,
            Balance = 2000,        
        },
        new Account
        {
            Id = "a6c6a48d-e149-4086-936b-3ec693e39ab4",
            OwnerId = "337f5059-c404-4d22-8128-f8297258856f",
            AccountNumber = "110016633598",
            Type = AccountType.Checking,
            Balance = 5000,
        },
             new Account
             {
                 Id = "f215f808-69e6-4377-8be7-7a68bde38cdd",
                 OwnerId = "bb7bc11e-4de9-44a5-b770-d4be2e20bc29",
                 AccountNumber = "110012569855",
                 Type = AccountType.Savings,
                 Balance = 2000,
             },
        new Account
        {
            Id = "a6c6a48d-e149-4086-936b-3ec693e39ab4",
            OwnerId = "bb7bc11e-4de9-44a5-b770-d4be2e20bc29",
            AccountNumber = "110016633598",
            Type = AccountType.Checking,
            Balance = 5000,
        }
        );
    }
 
}

