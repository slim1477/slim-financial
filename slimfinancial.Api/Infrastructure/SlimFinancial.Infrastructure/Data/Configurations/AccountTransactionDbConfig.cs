

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlimFinancial.Domain.Models;

namespace SlimFinancial.Infrastructure.Data.Configurations;

public class AccountTransactionDbConfig : IEntityTypeConfiguration<AccountTransaction>
{
    public void Configure(EntityTypeBuilder<AccountTransaction> builder)
    {
        builder.HasKey(at => new {at.AccountNumber,at.TransactionId});

        builder.HasOne(a => a.Account)
                .WithMany(t => t.Transactions)
                .HasForeignKey(t => t.AccountNumber)
                .HasPrincipalKey(a => a.AccountNumber);

        builder.HasOne(t => t.Transaction)
                .WithMany(a => a.Accounts)
                .HasForeignKey(a => a.TransactionId);
    }
}

