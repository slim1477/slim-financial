

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlimFinancial.Domain.Models;

namespace SlimFinancial.Infrastructure.Data.Configurations;

public class AccountDebitCardConfig : IEntityTypeConfiguration<AccountDebitCard>
{
    public void Configure(EntityTypeBuilder<AccountDebitCard> builder)
    {
        builder.HasKey(ad => new {ad.Pan,ad.AccountNumber});

        builder.HasOne(d => d.DebitCard)
               .WithMany(a => a.LinkedAccounts)
               .HasForeignKey("AccountNumber")
               .HasPrincipalKey(d => d.Pan);

        builder.HasOne(a => a.Account)
               .WithMany(d => d.DebitCards)
               .HasForeignKey("Pan")
               .HasPrincipalKey(a => a.AccountNumber);
    }
}

