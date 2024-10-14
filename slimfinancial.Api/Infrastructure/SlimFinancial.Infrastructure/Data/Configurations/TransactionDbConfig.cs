


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SlimFinancial.Domain.Models.Common.Enums;
using SlimFinancial.Domain.Models;

namespace SlimFinancial.Infrastructure.Data.Configurations;

public class TransactionDbConfig : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(t => t.Id);
        //builder.HasData(
        //    new Transaction
        //    {
        //        Id = "b750f48c-c0f8-4a2b-bee0-d6cbbc1124d2",
        //        TransactionType = TransactionType.Credit,
        //        Amount = 3000,
        //        Date = new DateOnly(2024, 9, 25),
        //        Descrition = "External Deposit - Payroll"
        //    },
        //    new Transaction
        //    {
        //        Id = "adf5048e-ca8f-46c8-935e-365aa22a8477",
        //        TransactionType = TransactionType.Credit,
        //        Amount = 5000,
        //        Date = new DateOnly(2024,4,19),
        //        Descrition = "Trasnfer from 112255333"
        //    });
        
    }
}

