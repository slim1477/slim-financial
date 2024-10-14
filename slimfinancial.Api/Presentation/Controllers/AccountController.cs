using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SlimFinancial.Infrastructure.Services;

namespace SlimFinancial.Api.Controllers;

[ApiController]
[Route("Api/[controller]")]
//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class AccountController(AccountService service) : ControllerBase
    {
    private readonly AccountService _accountService = service;


        [HttpGet]
        public async Task<IActionResult> GetAllAccounts()
        {
        return Ok(await _accountService.GetAllAccounts());
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> AccountsByOwnerId(string id)
        {
        
        return Ok(await _accountService.GetByOwnerId(id));
        }

    }

