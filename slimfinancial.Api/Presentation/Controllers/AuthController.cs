using Microsoft.AspNetCore.Mvc;
using SlimFinancial.Application.IService;
using SlimFinancial.Domain.Dtos;

namespace SlimFinancial.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
    {

    [HttpPost]
    [Route("login")]
        public  async Task<IActionResult> Login([FromBody] LoginRequestDto req)
        {
        
        if (ModelState.IsValid) 
        {
            var res = await authService.Login(req);
            var response = new LoginResponseDto
            {
                SessionToken = res.SessionToken,
                Success = res.Success,
                Message = res.Message,
            };
            switch (res.Message)
            {
                case "not found":
                    return NotFound(res);
                case "not authorized":
                    return Unauthorized(res);
                case "success":
                    return Ok(res);
                default:
                    return BadRequest(res);
            }

        }
        return BadRequest("Invalid request");
        }


    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDto req)
    {
        if (ModelState.IsValid)
        {
            var res = await authService.Register(req);
            return res.Message switch
            {
                "not found" => NotFound(res),
                "not authorized" => Unauthorized(res),
                "success" => Ok(res),
                _ => BadRequest(res),
            };
        }
        return BadRequest("Invalid request");
    }

    [HttpGet]
    public async Task<IActionResult> GetPersons()
    {
        var res = await authService.GetAll();
        return Ok(res);
    }
}

