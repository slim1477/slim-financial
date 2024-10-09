using Microsoft.AspNetCore.Mvc;
using SlimFinancial.Infrastructure.Services;

namespace SlimFinancial.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountsController(AccountService service) : ControllerBase
    {
    private readonly AccountService _accountService = service;


        [HttpGet]
        [Route("Accounts")]
        public async Task<IActionResult> Accounts()
        {
        
        return Ok(await _accountService.GetAll());
        }

    [HttpPost]
    [Route("Accounts/{id}")]
    public async Task<IActionResult> Accounts([FromBody] string id)
    {
        if (id == null) return BadRequest("please provide an account number");
        return Ok(await _accountService.GetByIdAsync(id));
    }
    }

