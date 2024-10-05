

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlimFinancial.Domain.Models.Entity;

namespace SlimFinancial.Infrastructure.Data.Configurations;

public class DebitCardDbConfig : IEntityTypeConfiguration<DebitCard>
{
    public void Configure(EntityTypeBuilder<DebitCard> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasData(
            new DebitCard
            {
                Id = "8c9d79fc-87d3-48b3-af14-3f0df2cfd149",
                Pan = "554499"
            },
            new DebitCard
            {
                Id = "9fecd945-69c7-435c-8e99-5219b143d5fc",
                Pan = "99664488"
            }
            );
    }
}

