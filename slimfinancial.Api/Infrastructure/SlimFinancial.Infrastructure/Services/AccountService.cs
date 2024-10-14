using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SlimFinancial.Domain.Dtos;
using SlimFinancial.Domain.Models;
using SlimFinancial.Infrastructure.Data.Repository;

namespace SlimFinancial.Infrastructure.Services;

//Represents the services for an account 
public class AccountService(AccountRepo repo, UserManager<Person> userManager,IMapper mapper)
{
    private readonly AccountRepo _repo = repo;
    private readonly UserManager<Person> _userManager = userManager;
    private readonly IMapper _mapper = mapper;

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
    public async Task<IEnumerable<AccountDto>> GetAllAccounts()
    {
       var accounts =  await _repo.GetAllAsync();
        return _mapper.Map<IEnumerable<AccountDto>>(accounts);
    }

    /// <summary>
    /// Gets account by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<AccountDto> GetByAccountNumber(string id)
    {
        var  account = await _repo.GetByAccountNumberAsync(id);
        return _mapper.Map<AccountDto>(account);
        
    }

    /// <summary>
    /// Gets account by owner Id
    /// </summary>
    /// <param name="ownerId"></param>
    /// <returns>Accounts that has the specified owner Id</returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<IEnumerable<AccountDto>> GetByOwnerId(string ownerId)
    {
        var accounts = await _repo.GetByOwnerIdAsync(ownerId);
        return _mapper.Map<IEnumerable<AccountDto>>(accounts);
    }

    /// <summary>
    /// updates an account
    /// </summary>
    /// <param name="entity"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<AccountDto> Update(Account entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        var updatedEntity = await  _repo.UpdateAsync(entity);
        return _mapper.Map<AccountDto>(updatedEntity);
    }
}

