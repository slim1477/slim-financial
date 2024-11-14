

using Microsoft.EntityFrameworkCore;
using SlimFinancial.Application.Repository;
using SlimFinancial.Domain.Models;

namespace SlimFinancial.Infrastructure.Data.Repository;

public class TransactionRepo(AppDbContext dbContext) 
{
    AppDbContext _dbContext = dbContext;
    public async Task<int> CreateAsync(List<Transaction> trans)
    {
        //var transaction = _dbContext.Database.BeginTransaction();
        try
        {
            var status = 0;
            foreach (Transaction t in trans) 
            {
                _dbContext.Transactions.Add(t);
                status  = await SaveChanges();
            }
            //await transaction.CommitAsync();
            return status;
        }
        catch (Exception) 
        {
            throw;
        }
        
        
    }

    public Task<int> Close(Transaction entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Transaction>> GetAllAsync()
    {
        return await _dbContext.Transactions.ToListAsync();
    }

    public async Task<Transaction?> GetByIdAsync(string id)
    {
        return await _dbContext.Transactions.FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task<int> UpdateAsync(Transaction entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Transaction>> GetByAccountNumber(string acctNumber)
    {
       
        return await _dbContext.Transactions.Where(x => x.AccountNumber == Int32.Parse(acctNumber)).ToListAsync();
    }

    public  Task<int> SaveChanges()
    {
        return _dbContext.SaveChangesAsync();
    }
}

