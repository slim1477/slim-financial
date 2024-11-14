

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlimFinancial.Domain.Models;

namespace SlimFinancial.Infrastructure.Data.Configurations;

/// <summary>
/// Represents configuration for the Debitcard table
/// </summary>
public class DebitCardDbConfig : IEntityTypeConfiguration<DebitCard>
{
    public void Configure(EntityTypeBuilder<DebitCard> builder)
    {
        builder.HasKey(x => x.Pan);
        //builder.Property(x => x.Pan).HasComputedColumnSql("CAST(Pan AS TEXT",stored:true);
        builder.Property(d => d.Pan)
               .HasDefaultValue(429448001)
               .HasAnnotation("Sqlite:Autoincrement",true)
               .ValueGeneratedOnAdd();



    }
}

