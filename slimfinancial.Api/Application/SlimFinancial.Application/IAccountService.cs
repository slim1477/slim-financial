
using SlimFinancial.Domain.Models.Entity;


namespace SlimFinancial.Application;

// Represents services for an account
    public interface IAccountService
    {
       
        IEnumerable<Account> GetAccounts(int persId);

        Account GetAccountByAcctNumber(string accountNumber);

        Transaction GetTransactionByAcctNumber(string AccountNumber);
    }
