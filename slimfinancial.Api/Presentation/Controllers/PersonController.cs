using Microsoft.AspNetCore.Mvc;
using SlimFinancial.Application.Service;
using SlimFinancial.Domain.Dtos;

namespace SlimFinancial.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController(IPersonService personService) : ControllerBase
    {

    [HttpPost]
    [Route("login")]
        public  async Task<IActionResult> Login([FromBody] PersonLoginRequestDto req)
        {
        
        if (ModelState.IsValid) 
        {
            var res = await personService.Login(req);
            var response = new PersonLoginResponseDto
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
    public async Task<IActionResult> Register([FromBody] PersonRegisterRequestDto req)
    {
        if (ModelState.IsValid)
        {
            var res = await personService.Register(req);
            return res.Message switch
            {
                "Email already exists" => Conflict(res),
                "Created" => Ok(res),
                _ => BadRequest(res),
            };
        }
        return BadRequest("Invalid request");
    }

    [HttpGet]
    public async Task<IActionResult> GetPersons()
    {
        var res = await personService.GetAll();
        return Ok(res);
    }
}

