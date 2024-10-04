using Microsoft.AspNetCore.Mvc;
using SlimFinancial.Application;
using SlimFinancial.Domain.Dtos;

namespace SlimFinancial.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
    {

    [HttpPost]
    [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto req)
        {
        if (ModelState.IsValid) 
        { 
            
        }
        return BadRequest("Invalid request");
        }


    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> Register([FromBody] LoginRequestDto req)
    {
        if (ModelState.IsValid)
        {
            var res = await authService.Register(req);
            LoginResponseDto response = new()
            {
                SessionToken = res.SessionToken,
                Status = res.Status,
                Message = [res.Message]
            };
            return Ok(response);
        }
        return BadRequest("Invalid request");
    }
}

