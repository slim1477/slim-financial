using SlimFinancial.Application.IRepository;
using SlimFinancial.Domain.Models.Entity;


namespace SlimFinancial.Application.IService;

// Represents application services blueprint
public interface IService<T> : IRepository <T> where T : class
{

    //IEnumerable<Account> GetAccounts(int persId);

    //Account GetAccountByAcctNumber(string accountNumber);

    //IEnumerable<Transaction> GetTransactionsByAcctNumber(string AccountNumber);
}
