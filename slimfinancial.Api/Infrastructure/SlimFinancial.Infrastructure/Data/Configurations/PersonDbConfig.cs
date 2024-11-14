

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlimFinancial.Domain.Models;
using SlimFinancial.Infrastructure.Helper;
using System;

namespace SlimFinancial.Infrastructure.Data.Configurations;

public class PersonDbConfig : IEntityTypeConfiguration<Person>
{
  
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        
        builder.HasKey(x => x.PersonNumber);
        //builder.HasAlternateKey(x => x.PersonNumber);
        //builder.Property(p => p.PersonNumber).HasComputedColumnSql("CAST(PersonNumber AS TEXT)",stored:true);
        builder.Property(p => p.Id).HasComputedColumnSql("PersonNumber",stored:true);
        builder.Property(p => p.PersonNumber)
               .HasDefaultValue(1701000)
               .HasAnnotation("Sqlite:Autoincrement",true)
               .ValueGeneratedOnAdd();
        builder.ToTable($"{nameof(Person)}s");
        //builder.HasMany(a => a.Accounts).WithOne(a => a.Person).HasForeignKey("PersonNumber");
        //builder.HasMany<Account>().WithOne().HasForeignKey(a => a.Id);
        //builder.HasData(GenerateTestPersons());
    }

    //public static List<Person> GenerateTestPersons()
    //{
    //    var harsher = new PasswordHasher<Person>();
        
    //    var persons = new List<Person>();
       
    //    Person person1 = new()
    //    {
    //        //Id = "337f5059-c404-4d22-8128-f8297258856f",
    //        PersonNumber = IdGenerator.Generate<Person>(),
    //        Fname = "John",
    //        Lname = "Smith",
    //        UserName = "jsmith",
    //        Address = "123 test street",
    //        DateOfBirth = new DateOnly(1947, 12, 17),
    //        Email = "jsmith@example.com",
    //        NormalizedEmail = "JSMITH@EXAMPLE.COM",
    //        PhoneNumber = "1234567890"
    //    };
    //    person1.PasswordHash = harsher.HashPassword(person1, "MyP@ssW@rD!");
    //    persons.Add(person1);
    //    Person person2 = new()
    //    {
    //        //Id = "bb7bc11e-4de9-44a5-b770-d4be2e20bc29",
    //        PersonNumber = IdGenerator.Generate<Person>(),
    //        Fname = "Laura",
    //        Lname = "Maxwell",
    //        UserName = "lmaxwell",
    //        Address = "234 Admirality way",
    //        DateOfBirth = new DateOnly(1985, 05, 15),
    //        Email = "lmaxwell@demo.com",
    //        NormalizedEmail = "LMAXWELL@DEMO.COM",
    //        PhoneNumber = "2356998523"
    //    };
    //    person2.PasswordHash = harsher.HashPassword(person2, "myP@ssWord!2");
    //    persons.Add(person2);
    //    return persons;
    //}
}

