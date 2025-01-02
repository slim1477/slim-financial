

using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using SlimFinancial.Application.Service;
using SlimFinancial.Domain.Dtos;
using SlimFinancial.Domain.Models;
using SlimFinancial.Domain.Models.Common;
using SlimFinancial.Infrastructure.Data.Repository;


namespace SlimFinancial.Infrastructure.Services;

/// <summary>
/// Represents the transaction service
/// </summary>
/// <param name="repo"></param>
/// <param name="mapper"></param>
public class TransactionService(TransactionRepo repo,IAccountService service,IMapper mapper) : ITransactionService
{
    private readonly TransactionRepo _repo = repo;
    private readonly IMapper _mapper = mapper;
    private readonly IAccountService _service = service;

    /// <summary>
    /// Gets all transaction
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<TransactionDto>> GetAllTransactions()
    {
        var transactions = await _repo.GetAllAsync();
        return _mapper.Map<IEnumerable<TransactionDto>>(transactions);
       
    }
    /// <summary>
    /// Gets transactions by account number
    /// </summary>
    /// <param name="accountNum"></param>
    /// <returns></returns>
    public async Task<IEnumerable<TransactionDto>> GetTransactionByAccountNumber(string accountNum)
    {
        var transactions = await _repo.GetByAccountNumber(accountNum);
        return _mapper.Map<List<TransactionDto>>(transactions);

    }
    /// <summary>
    /// Creates a new transaction
    /// </summary>
    /// <param name="trans"></param>
    /// <returns></returns>
    public async Task<TransactionResDto> CreateTransactionAsync(TransactionReqDto trans)
    {
        
        try 
        {
            List<Transaction> transactions = [];
            switch (trans.SourceAcctNumber.IsNullOrEmpty())
            {
                case true:
                   var transaction = await _service.Credit(trans.DestinationAccountNumber,trans.TransactionAmount);
                    transaction.Description = "Initial Deposit";
                    transaction.TransactionType = TransactionType.Credit.ToString();
                    transactions.Add(transaction);
                break;
                case false:
                    var debitTransaction = await _service.Debit(trans.SourceAcctNumber, trans.TransactionAmount);
                    var creditTransaction = await _service.Credit(trans.DestinationAccountNumber, trans.TransactionAmount);
                    debitTransaction.Description = $"transfer to {trans.DestinationAccountNumber}";
                    creditTransaction.Description = $"transfer from {trans.SourceAcctNumber}";
                    debitTransaction.TransactionType = TransactionType.Debit.ToString();
                    creditTransaction.TransactionType = TransactionType.Credit.ToString(); 
                    transactions.Add(debitTransaction);
                    transactions.Add(creditTransaction);
                break;
            }
             await _repo.CreateAsync(transactions);
            return new TransactionResDto
            {
                Status = true,
                Message = "transfer succesfully completed"
            };
                
           
        }catch(Exception ex)
        {
            return new TransactionResDto
            {
                Status = false,
                Message = ex.Message,
            };
        }
    }


}

