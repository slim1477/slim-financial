using Microsoft.AspNetCore.Mvc;
using SlimFinancial.Domain.Dtos;
using SlimFinancial.Infrastructure.Services;

namespace SlimFinancial.Api.Controllers;

    [ApiController]
    [Route("Api/[Controller]")]
    public class TransactionsController(TransactionService service) : ControllerBase
    {
    private readonly TransactionService _service = service;


        [HttpGet]
        public async Task<IActionResult> GetAllTransactionsasync() 
        {
            return Ok(await _service.GetAllTransactions());
        }

        [HttpGet]
    [Route("{acctNum}")]
        public async Task<IActionResult> GetTransactionsByAccountNumberAsync(string acctNum) 
        {
            return Ok(await _service.GetByAccountNumber(acctNum));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromBody] TransactionCreateDto payload)
        {
        if (payload == null) return BadRequest();
        return Ok(await _service.CreateTransaction(payload));
        }
    }

