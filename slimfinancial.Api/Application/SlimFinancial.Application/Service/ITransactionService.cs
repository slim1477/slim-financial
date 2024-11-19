using SlimFinancial.Domain.Dtos;
using SlimFinancial.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimFinancial.Application.Service;

    public interface ITransactionService
    {
        Task<IEnumerable<TransactionDto>> GetAllTransactions();
        Task<IEnumerable<TransactionDto>> GetTransactionByAccountNumber(string acctNum);
        Task<TransactionResDto> CreateTransactionAsync(TransactionReqDto payload);
    }

