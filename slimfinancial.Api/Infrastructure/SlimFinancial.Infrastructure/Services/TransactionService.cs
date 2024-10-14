

using AutoMapper;
using SlimFinancial.Domain.Dtos;
using SlimFinancial.Domain.Models;
using SlimFinancial.Infrastructure.Data.Repository;
using SlimFinancial.Infrastructure.Helper;

namespace SlimFinancial.Infrastructure.Services;

/// <summary>
/// Represents the transaction service
/// </summary>
/// <param name="repo"></param>
/// <param name="mapper"></param>
public class TransactionService(TransactionRepo repo,AccountRepo acctRepo,IMapper mapper)
{
  private readonly TransactionRepo _repo = repo;
    private readonly IMapper _mapper = mapper;

    /// <summary>
    /// Gets all transaction
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<Transaction>> GetAllTransactions()
    {
        var transactions = await _repo.GetAllAsync();
        //return _mapper.Map<IEnumerable<TransactionDto>>(transactions);
        return transactions;
    }
    /// <summary>
    /// Gets transactions by account number
    /// </summary>
    /// <param name="accountNum"></param>
    /// <returns></returns>
    public async Task<IEnumerable<TransactionGetDto>> GetByAccountNumber(string accountNum)
    {
        var transactions = await _repo.GetByAccountNumber(accountNum);
        return _mapper.Map<List<TransactionGetDto>>(transactions);

    }
    /// <summary>
    /// Creates a new transaction
    /// </summary>
    /// <param name="transaction"></param>
    /// <returns></returns>
    public async Task<int> CreateTransaction(TransactionCreateDto transaction)
    {
        throw new NotImplementedException();
        //TransactionHelper.SetBalance(transaction.SourceId, acctRepo);
        //var sourceBalance = TransactionHelper.Balance;
        //If(sourceBalance >= transaction.TransactionAmount)
        //  {
        //    sourceBalance -= transaction.TransactionAmount;
        //};
        //var newTransaction = _mapper.Map<Transaction>(transaction);
        //newTransaction.Date = DateOnly.FromDateTime(DateTime.Now);
        //return await _repo.CreateAsync(newTransaction);
    }


}

