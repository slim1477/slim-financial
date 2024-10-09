using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SlimFinancial.Application.Repository;
using SlimFinancial.Domain.Models.Entity;
using SlimFinancial.Infrastructure.Data;

namespace SlimFinancial.Infrastructure.Services;

//Represents the services for an account 
public class AccountService(AppDbContext dbContext, UserManager<Person> userManager) :IRepository<Account>
{
    private readonly AppDbContext _dbContext = dbContext;
    private readonly UserManager<Person> _userManager = userManager;

    /// <summary>
    /// Creates an account
    /// </summary>
    /// <param name="entity"></param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="KeyNotFoundException"></exception>
    public void Create(Account entity)
    {
        if(entity == null) throw new ArgumentNullException(nameof(entity));
        var isUserExists =  _userManager.FindByIdAsync(entity.OwnerId);
        if (isUserExists == null) throw new KeyNotFoundException("user does not exsist");
        var newAccount = _dbContext.Accounts.Add(entity);
        _dbContext.SaveChanges();
        
    }

    /// <summary>
    /// Deletes an account
    /// </summary>
    /// <param name="entity"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public void Delete(Account entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        var isUserExists = _dbContext.Accounts.Remove(entity);
        _dbContext?.SaveChanges();
    }


    /// <summary>
    /// Gets all accounts
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<AccountDto>> GetAll()
    {
        return await _dbContext.Accounts.ToListAsync();
    }

    /// <summary>
    /// Gets account by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Account> GetByIdAsync(string id)
    {
        return await _dbContext.Accounts.FindAsync(id);
    }

    /// <summary>
    /// updates an account
    /// </summary>
    /// <param name="entity"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public void Update(Account entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        _dbContext.Entry(entity).State = EntityState.Modified;
        
    }
}

