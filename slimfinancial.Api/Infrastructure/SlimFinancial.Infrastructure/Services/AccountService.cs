using SlimFinancial.Application;
using SlimFinancial.Domain.Models.Entity;

namespace SlimFinancial.Infrastructure.Services;

//Represents the services for an account 
public class AccountService : IAccountService
{
    public Account GetAccountByAcctNumber(string accountNumber)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Account> GetAccounts(int persId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Transaction> GetTransactionsByAcctNumber(string AccountNumber)
    {
        throw new NotImplementedException();
    }
}

