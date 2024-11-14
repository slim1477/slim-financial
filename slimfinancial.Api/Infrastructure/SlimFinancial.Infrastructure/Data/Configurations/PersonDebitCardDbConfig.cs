
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlimFinancial.Domain.Models;

namespace SlimFinancial.Infrastructure.Data.Configurations;

public class PersonDebitCardDbConfig : IEntityTypeConfiguration<PersonDebitCard>
{
    public void Configure(EntityTypeBuilder<PersonDebitCard> builder)
    {
        builder.HasKey(pd => new {pd.Pan,pd.PersonNumber});

        builder.HasOne(p => p.Person)
               .WithMany(d => d.DebitCards)
               .HasForeignKey("PersonNumber")
               .HasPrincipalKey(p => p.PersonNumber);

        builder.HasOne(d => d.DebitCard)
               .WithMany(p => p.Persons)
               .HasForeignKey("Pan")
               .HasPrincipalKey(d => d.Pan);
    }
}

