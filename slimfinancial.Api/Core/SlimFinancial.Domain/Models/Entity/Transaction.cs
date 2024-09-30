using SlimFinancial.Domain.Models.Common.Enums;
using System;


namespace SlimFinancial.Domain.Models.Entity;

    public class Transaction
    {
    public int Id { get; set; }
    public int AccountId { get; set; }
    public string Descrition { get; set; } = string.Empty;

    public DateOnly Date {  get; set; }
    public TransactionType TransactionType { get; set; }
    public double Amount { get; set; }
    }

