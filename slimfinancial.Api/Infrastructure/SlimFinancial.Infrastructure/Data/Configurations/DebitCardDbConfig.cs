

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
                Pan = "554499",
                OwnerId = "337f5059-c404-4d22-8128-f8297258856f"
            },
            new DebitCard
            {
                Id = "9fecd945-69c7-435c-8e99-5219b143d5fc",
                Pan = "99664488",
                OwnerId = "bb7bc11e-4de9-44a5-b770-d4be2e20bc29"
            }
            );
    }
}

