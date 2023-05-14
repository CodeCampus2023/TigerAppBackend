using Microsoft.AspNetCore.Mvc;
using TigerParkBackend.Application.AppData.Contexts.Authorization.Services;
using TigerParkBackend.Contracts;
using TigerParkBackend.Contracts.Partner;

namespace TigerParkBackend.Host.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
[ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
public class PartnersController : ControllerBase
{
    private readonly IAuthService _authService;

    public PartnersController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterPartnerDto dto, CancellationToken cancellationToken)
    {
        var result = await _authService.Register(dto, cancellationToken);
        if (result is not null) return CreatedAtAction(nameof(Register), result);
        ModelState.AddModelError("", "Phone already exist");
        return BadRequest();
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginPartnerDto dto, CancellationToken cancellationToken)
    {
        var result = await _authService.Login(dto, cancellationToken);
        return Ok(result);
    }
}