

using Microsoft.EntityFrameworkCore;
using SlimFinancial.Application.Repository;
using SlimFinancial.Domain.Models;
using System.Linq;

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
        await _dbContext.Accounts.AddAsync(entity);
        return _dbContext.SaveChanges();
    }

    public void Delete(Account entity)
    {
        _dbContext.Accounts.Remove(entity);
        _dbContext?.SaveChanges();
    }

    public async Task<IEnumerable<Account>> GetByOwnerIdAsync(string ownerId)
    {
        return await Task<IEnumerable<Account>>.Run(() =>
        {
            return _dbContext.Accounts.Where(x => x.OwnerId == ownerId);
        });
        
    }
    public async Task<IEnumerable<Account>> GetAllAsync()
    {
        return await _dbContext.Accounts.ToListAsync();
    }

    public async Task<Account> GetByAccountNumberAsync(string acctNum)
    {
        return await _dbContext.Accounts.FirstOrDefaultAsync(x => x.AccountNumber == acctNum);
    }

    public Task<Account> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<Account> UpdateAsync(Account entity)
    {
        _dbContext.Entry(entity).State =  EntityState.Modified;
        return entity;
    }
}

