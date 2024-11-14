
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlimFinancial.Domain.Models;

namespace SlimFinancial.Infrastructure.Data.Configurations;

public class PersonAccountDbConfig : IEntityTypeConfiguration<PersonAccount>
{
    public void Configure(EntityTypeBuilder<PersonAccount> builder)
    {
        builder.HasKey(pa => new { pa.PersonNumber, pa.AccountNumber });
        builder.ToTable("JointAccounts");

        builder.HasOne(p => p.Person)
               .WithMany(ja => ja.JointAccounts)
               .HasForeignKey("PersonNumber")
               .HasPrincipalKey(p => p.PersonNumber);

        builder.HasOne(p => p.Account)
                .WithMany(jo => jo.JointOwners)
                .HasForeignKey("AccountNumber")
                .HasPrincipalKey(a => a.AccountNumber);

    }
}

