

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
            Id = Guid.NewGuid().ToString(),
        });
    }
 
}

