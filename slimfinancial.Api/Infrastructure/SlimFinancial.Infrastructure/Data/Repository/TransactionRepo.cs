

using Microsoft.EntityFrameworkCore;
using SlimFinancial.Application.Repository;
using SlimFinancial.Domain.Models;

namespace SlimFinancial.Infrastructure.Data.Repository;

public class TransactionRepo(AppDbContext dbContext) : IRepository<Transaction>
{
    AppDbContext _dbContext = dbContext;
    public async Task<int> CreateAsync(Transaction trans)
    {
        _dbContext.Transactions.Add(trans);
       return await  _dbContext.SaveChangesAsync();
    }

    public void Delete(Transaction entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Transaction>> GetAllAsync()
    {
        return await _dbContext.Transactions.ToListAsync();
    }

    public async Task<Transaction> GetByIdAsync(string id)
    {
        return await _dbContext.Transactions.FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task<Transaction> UpdateAsync(Transaction entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Transaction>> GetByAccountNumber(string acctNumber)
    {
        return await Task<IEnumerable<Transaction>>.Run(() =>
        {
            return _dbContext.Transactions.Where(x => x.SourceAccount.AccountNumber == acctNumber);
        });
    }
}

