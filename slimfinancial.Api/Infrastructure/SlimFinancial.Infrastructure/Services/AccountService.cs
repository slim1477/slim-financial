using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SlimFinancial.Application.Repository;
using SlimFinancial.Domain.Dtos;
using SlimFinancial.Domain.Models.Entity;
using SlimFinancial.Infrastructure.Data;
using SlimFinancial.Infrastructure.Data.Repository;

namespace SlimFinancial.Infrastructure.Services;

//Represents the services for an account 
public class AccountService(AccountRepo repo, UserManager<Person> userManager)
{
    private readonly AccountRepo _repo = repo;
    private readonly UserManager<Person> _userManager = userManager;

    /// <summary>
    /// Creates an account
    /// </summary>
    /// <param name="entity"></param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="KeyNotFoundException"></exception>
    public async Task<int> OpenAccount(Account entity)
    {
        if(entity == null) throw new ArgumentNullException(nameof(entity));
        var isUserExists =  _userManager.FindByIdAsync(entity.OwnerId);
        if (isUserExists == null) throw new KeyNotFoundException("user does not exsist");
        return await _repo.CreateAsync(entity);
    }

    /// <summary>
    /// Deletes an account
    /// </summary>
    /// <param name="entity"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public void CloseAccount(Account entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        _repo.Delete(entity);
    }


    /// <summary>
    /// Gets all accounts
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<Account>> GetAllAccounts()
    {
        return await _repo.GetAllAsync();
    }

    /// <summary>
    /// Gets account by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Account> GetByAccountNumber(string id)
    {
        return await  _repo.GetByAccountNumberAsync(id);
        
    }

    /// <summary>
    /// Gets account by owner Id
    /// </summary>
    /// <param name="ownerId"></param>
    /// <returns>Accounts that has the specified owner Id</returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<IEnumerable<Account>> GetByOwnerId(string ownerId)
    {
        return await _repo.GetByOwnerIdAsync(ownerId);
    }

    /// <summary>
    /// updates an account
    /// </summary>
    /// <param name="entity"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<Account> Update(Account entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        var updatedEntity = await  _repo.UpdateAsync(entity);
        return updatedEntity;
    }
}

