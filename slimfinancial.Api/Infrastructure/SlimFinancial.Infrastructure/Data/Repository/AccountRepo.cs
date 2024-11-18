

using Microsoft.EntityFrameworkCore;
using SlimFinancial.Application.Repository;
using SlimFinancial.Domain.Models;
using SlimFinancial.Domain.Models.Common;

namespace SlimFinancial.Infrastructure.Data.Repository;

/// <summary>
/// Represents the account data store
/// </summary>
/// <param name="dbContext"></param>
public class AccountRepo(AppDbContext dbContext) : IRepository<Account>
{
    private readonly AppDbContext _dbContext = dbContext;
    public async Task<int> CreateAsync(Account entity)
    {
         _dbContext.Accounts.Add(entity);
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<int> Close(Account entity)
    {
        entity.Status = AccountStatus.Closed;
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Account>> GetByPersonNumberAsync(string personNumber)
    {
        return await _dbContext.Accounts.Where(x => x.PersonNumber == Int32.Parse(personNumber)).ToListAsync();
        
    }
    public async Task<IEnumerable<Account>> GetAllAsync()
    {
        return await _dbContext.Accounts.ToListAsync();
    }

    public async Task<Account?> GetByAccountNumberAsync(string acctNum)
    {
        return await _dbContext.Accounts.FirstOrDefaultAsync(x => x.AccountNumber == Int32.Parse(acctNum));
    }


    public  void Update(Account entity)
    {
        
        _dbContext.Accounts.Update(entity);
        
        
    }

    public async Task<Account> UpdateBalanceAsync(Account account, double amount,TransactionType type)
    {

        switch (type)
        {
            case TransactionType.Debit:
                account.Balance -= amount;
               break;
            case TransactionType.Credit:
                account.Balance += 89988;
               break ;
        }
        var hasChanges = _dbContext.ChangeTracker.HasChanges();
        //var changed = _dbContext.Update(account);
        await _dbContext.SaveChangesAsync();
        return account;
    }

    public async Task SaveAccountChanges()
    {
        await _dbContext.SaveChangesAsync();
    }
}

