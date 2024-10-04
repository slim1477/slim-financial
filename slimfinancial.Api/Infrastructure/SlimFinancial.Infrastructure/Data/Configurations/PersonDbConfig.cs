

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlimFinancial.Domain.Models.Entity;

namespace SlimFinancial.Infrastructure.Data.Configurations;

public class PersonDbConfig : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany<Account>().WithOne().HasForeignKey(a => a.Id);
        builder.HasData( 
            new Person { 
            Id = Guid.NewGuid().ToString(),
            Fname = "John",
            Lname = "Smith",
            Address = "123 test street",
            DateOfBirth = new DateOnly(1947, 12, 17),
            Email = "jsmith@example.com",
            PhoneNumber = "1234567890"
        },
        new Person
        {
            Id = Guid.NewGuid().ToString(),
            Fname = "Laura",
            Lname = "Maxwell",
            Address = "234 Admirality way",
            DateOfBirth = new DateOnly(1985,05,15),
            Email = "lmaxwell@demo.com",
            PhoneNumber = "2356998523"
        });
    }
}

