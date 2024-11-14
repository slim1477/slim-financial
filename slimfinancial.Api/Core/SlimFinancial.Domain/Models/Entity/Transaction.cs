using SlimFinancial.Domain.Models.Common;
using System;


namespace SlimFinancial.Domain.Models;

    /// <summary>
    /// Represents a Transaction
    /// </summary>
    public class Transaction
    {
    public string Id { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int AccountNumber { get; set; } 
    public DateTime Date {  get; set; }
    public string TransactionType { get; set; } = string.Empty ;
    public double Amount { get; set; }
    public double Balance { get; set; }

    public ICollection<AccountTransaction> Accounts { get; set; } = [];

    }

