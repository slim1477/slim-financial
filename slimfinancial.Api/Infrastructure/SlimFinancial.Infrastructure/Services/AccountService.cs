using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SlimFinancial.Application.Service;
using SlimFinancial.Domain.Dtos;
using SlimFinancial.Domain.Models;
using SlimFinancial.Domain.Models.Common;
using SlimFinancial.Infrastructure.Data.Repository;

namespace SlimFinancial.Infrastructure.Services;

//Represents the services for an account 
public class AccountService(AccountRepo repo, UserManager<Person> userManager,IMapper mapper) : IAccountService
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
    public async Task<ReqResponseDto> OpenAccount(AccountOpenReqDto entity)
    {
        try
        {
            if(entity.PersonNumber.IsNullOrEmpty()) throw new ArgumentNullException("Person Number Cannot be empty");
            var isUserExists = _userManager.FindByIdAsync(entity.PersonNumber);
            var newAcct = isUserExists == null ? throw new KeyNotFoundException("user does not exsist") :
                          new Account
                          {
                              PersonNumber = Int32.Parse(entity.PersonNumber),
                              Type = AccountType.Checking,
                              Status = AccountStatus.Active,
                              Balance = 0
                          };
            var res = await _repo.CreateAsync(newAcct);

            return new ReqResponseDto { Success = true, Message = "Account Successfully Opened" };
        }
        catch (Exception) 
        {
            throw;
        }
       
    }

    /// <summary>
    /// Deletes an account
    /// </summary>
    /// <param name="entity"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<ReqResponseDto> CloseAccount(string accountNumber)
    {
        try
        {
            if (accountNumber.IsNullOrEmpty()) throw new ArgumentNullException("account number cannot be null");
            var account = await _repo.GetByAccountNumberAsync(accountNumber) ?? throw new ArgumentNullException($"Account {accountNumber} does not exist");
            _ = account.Balance < 0 ? throw new Exception("cannot close account with balance greater than 0") : await _repo.Close(account);
            return new ReqResponseDto { Success = true, Message = $"Account number {account.AccountNumber} closed successfully" };

        }
        catch (Exception) 
        {
            throw;
        }

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
    /// Gets account by account number
    /// </summary>
    /// <param name="acctNum"></param>
    /// <returns></returns>
    public async Task<AccountDto> GetAccountByAccountNumber(string acctNum)
    {
        var  account = await _repo.GetByAccountNumberAsync(acctNum);
        return _mapper.Map<AccountDto>(account);
        
    }

    /// <summary>
    /// Gets account by owner Id
    /// </summary>
    /// <param name="personNumber"></param>
    /// <returns>Accounts that has the specified owner Id</returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<IEnumerable<AccountDto>> GetByPersonNumber(string personNumber)
    {
        var accounts = await _repo.GetByPersonNumberAsync(personNumber);
        return _mapper.Map<IEnumerable<AccountDto>>(accounts);
    }

    /// <summary>
    /// updates an account
    /// </summary>
    /// <param name="entity"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public void UpdateAccount(AccountDto acct)
    {
        ArgumentNullException.ThrowIfNull(acct);
        var payload = _mapper.Map<Account>(acct);
        _repo.Update(payload);
        //return _mapper.Map<AccountDto>(updatedEntity);
    }

    /// <summary>
    /// Credits a given account
    /// </summary>
    /// <param name="accountNumber"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    public async Task<Transaction> Credit(string accountNumber, double amount)
    {
        var account = await _repo.GetByAccountNumberAsync(accountNumber);
        account.Balance += amount;
        await _repo.SaveAccountChanges();
        //var account1 = _mapper.Map<Account>(account);
        //var updatedAcct = await _repo.UpdateBalanceAsync(account1, amount, TransactionType.Credit);
        //_repo.UpdateAsync(account1);
        
        return new Transaction
        {
            Id = Guid.NewGuid().ToString(),
            AccountNumber = account.AccountNumber,
            Amount = amount,
            Date = DateTime.Now.Date,
            TransactionType = TransactionType.Credit.ToString(),
            Balance = account.Balance,
        };
    }

    /// <summary>
    /// Debits a given account
    /// </summary>
    /// <param name="accountNumber"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task<Transaction> Debit(string accountNumber, double amount)
    {
        try
        {
            var account = await _repo.GetByAccountNumberAsync(accountNumber) ?? throw new InvalidOperationException();
            var newBalance = account.Balance < amount ? throw new Exception("Insufficient Balance") : account.Balance -= amount; 
            await _repo.SaveAccountChanges();
            return new Transaction
            {
                Id = Guid.NewGuid().ToString(),
                AccountNumber = account.AccountNumber,
                Amount = amount,
                Date = DateTime.Now.Date,
                TransactionType = TransactionType.Debit.ToString(),
                Balance = newBalance,
            };
        }
        catch (Exception)
        {
            throw;
        }
        
    }
}

