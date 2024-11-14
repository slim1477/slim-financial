using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimFinancial.Domain.Models;

    /// <summary>
    /// Represents the many-to-many account-transaction relationship
    /// </summary>
    public class AccountTransaction
    {
        public int AccountNumber { get; set; } 
        public Account Account { get; set; } = default!;
        public string TransactionId { get; set; } = string.Empty;
        public Transaction Transaction { get; set; } = default!;
    }

