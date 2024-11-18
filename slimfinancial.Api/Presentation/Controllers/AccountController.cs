using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SlimFinancial.Application.Service;
using SlimFinancial.Domain.Dtos;
using SlimFinancial.Infrastructure.Services;

namespace SlimFinancial.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class AccountController(IAccountService service) : ControllerBase
{
    private readonly IAccountService _accountService = service;


    [HttpGet]
    public async Task<IActionResult> GetAllAccounts()
    {
        return Ok(await _accountService.GetAllAccounts());
    }
        [HttpGet]
        [Route("acc/{acctNum}")]
        public async Task<IActionResult> GetAccountByAccountNumber(string acctNum)
        {
            var acct = await _accountService.GetAccountByAccountNumber(acctNum);
            return Ok(acct);
        }
        [HttpGet]
        [Route("{personNum}")]
        public async Task<IActionResult> GetAccountsByPersonNumber(string personNum)
        {
            
            if (string.IsNullOrEmpty(personNum)) return BadRequest("Person number cannot be null");
            var accts = await _accountService.GetByPersonNumber(personNum);
             return accts == null ? NotFound("no account found") : Ok(accts);
        }
        [HttpPost]
        [Route("close")]
        public async Task<IActionResult> CloseAccount([FromBody] string acctNum)
        {
            
            try
            {
                
                var res = await _accountService.CloseAccount(acctNum);
                
                return Ok(res);
            }catch (Exception ex)
            {
            var res = new ReqResponseDto
            {
                Success = false,
                Message = ex.Message
            };
            return UnprocessableEntity(res);

        }


    }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateAccount([FromBody] AccountDto acct)
        {
            if (acct == null) return BadRequest("Please provide an account number");
            try
            {
                _accountService.UpdateAccount(acct);
                return Ok();
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex.Message);
            }


        }
    [HttpPost]
    [Route("open")]
    public async Task<IActionResult> OpenAccount([FromBody] AccountOpenReqDto payload)
    {
        try
        {
            
            var res = await _accountService.OpenAccount(payload);
            return Ok(res);
        }
        catch (Exception ex) 
        {
            var res = new ReqResponseDto
            {
                Success = false,
                Message = ex.Message,
            };
            return UnprocessableEntity(res);
        }
    }

}

