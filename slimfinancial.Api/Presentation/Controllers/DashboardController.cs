using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SlimFinancial.Infrastructure.Services;

namespace SlimFinancial.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class DashboardController(AccountService service) : ControllerBase
    {
    private readonly AccountService _accountService = service;


        [HttpGet]
        [Route("Accounts/{id}")]
        public async Task<IActionResult> Accounts(string id)
        {
        
        return Ok(await _accountService.GetByOwnerId(id));
        }

    [HttpGet]
    [Route("Transactions/{id}")]
    public async Task<IActionResult> Transactions( string id)
    {
        //TODO: create transaction service to retrieve transactions.
       
        return Ok("Transaction services would soon be created");
    }
    }

