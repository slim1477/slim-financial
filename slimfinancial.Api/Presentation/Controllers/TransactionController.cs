using Microsoft.AspNetCore.Mvc;
using SlimFinancial.Application.Service;
using SlimFinancial.Domain.Dtos;
using SlimFinancial.Infrastructure.Services;

namespace SlimFinancial.Api.Controllers;

    [ApiController]
    [Route("Api/[Controller]")]
    public class TransactionController(ITransactionService service) : ControllerBase
    {
    private readonly ITransactionService _service = service;


        [HttpGet]
        public async Task<IActionResult> GetAllTransactionsasync() 
        {
            return Ok(await _service.GetAllTransactions());
        }

        [HttpGet]
        [Route("{acctNum}")]
        public async Task<IActionResult> GetTransactionsByAccountNumberAsync(string acctNum) 
        {
            return Ok(await _service.GetTransactionByAccountNumber(acctNum));
        }

        [HttpPost]
        [Route("post")]
        public async Task<IActionResult> CreateTransaction([FromBody] TransactionReqDto payload)
        {
        
            if (payload == null) return BadRequest();
            var res = await _service.CreateTransactionAsync(payload);

            switch (res.Status)
            {
                case true:
                    return Ok(res);
                case false:
                    return UnprocessableEntity(res);
            }
        }
    }

