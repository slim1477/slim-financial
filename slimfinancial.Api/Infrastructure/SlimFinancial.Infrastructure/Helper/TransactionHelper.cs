

using SlimFinancial.Domain.Models;
using SlimFinancial.Infrastructure.Data.Repository;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;

namespace SlimFinancial.Infrastructure.Helper;

    public  static class TransactionHelper
    {
        public static string AccountId {  get; private set; } = string.Empty;
        public static double Balance { get; private set; }
        
        public static async void SetBalance(string acctNum, AccountRepo repo)
        {
            var acct = await repo.GetByAccountNumberAsync(acctNum);
            if (acct != null) 
            { 
              AccountId = acct.AccountNumber;
              Balance = acct.Balance;
            }
            
        }

      
    }

