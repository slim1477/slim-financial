

using SlimFinancial.Domain.Dtos;
using SlimFinancial.Domain.Models;

namespace SlimFinancial.Application.Service;

    public interface IAccountService
    {
        Task<ReqResponseDto> OpenAccount(AccountOpenReqDto entity);
        Task<ReqResponseDto> CloseAccount(string accountNumber);
        void UpdateAccount(AccountDto account);
        Task<AccountDto> GetAccountByAccountNumber(string accountNumber);
        Task<IEnumerable<AccountDto>> GetAllAccounts();
        Task<IEnumerable<AccountDto>> GetByPersonNumber(string personNumber);
        Task<Transaction> Credit(string accountNumber,double amount);
        Task<Transaction> Debit(string accountNumber, double amount);
    }

