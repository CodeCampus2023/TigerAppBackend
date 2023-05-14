using Microsoft.AspNetCore.Mvc;
using TigerParkBackend.Contracts;
using TigerParkBackend.Contracts.Order;

namespace TigerParkBackend.Host.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
[ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
public class OrdersController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderDto dto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}