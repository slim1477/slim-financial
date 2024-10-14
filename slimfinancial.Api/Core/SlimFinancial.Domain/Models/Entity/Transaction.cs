using SlimFinancial.Domain.Models.Common.Enums;
using System;


namespace SlimFinancial.Domain.Models;

    public class Transaction
    {
    public string Id { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public DateOnly Date {  get; set; }
    public string TransactionType { get; set; } = string.Empty ;
    public double Amount { get; set; }

    public required Account SourceAccount { get; set; } 

    }

