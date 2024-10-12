using SlimFinancial.Domain.Models.Common.Enums;
using System;


namespace SlimFinancial.Domain.Models.Entity;

    public class Transaction
    {
    public string Id { get; set; } = string.Empty;
    public string Descrition { get; set; } = string.Empty;

    public DateOnly Date {  get; set; }
    public TransactionType TransactionType { get; set; }
    public double Amount { get; set; }

    public required Account SourceAccount { get; set; } 

    }

