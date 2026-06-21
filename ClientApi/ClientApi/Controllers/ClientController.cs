using Core.Domain;
using Core.UseCases.AddClient;
using Core.UseCases.GetClient;
using Core.UseCases.UpdateClient;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClientApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ClientController : ControllerBase
{
    private readonly IMediator _mediator;
    public ClientController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> AddClient([FromBody] AddClientInput clientInput)
    {
        var result = await _mediator.Send(clientInput);
        return Ok(result);  
    }

    [HttpGet("{cpf}")]
    public async Task<IActionResult> GetClientByCpf(string cpf)
    {
        var getClientInput = new GetClientInput(cpf);
        var result = await _mediator.Send(getClientInput);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateClient([FromBody] UpdateClientInput updateClientInput)
    {
        var result = await _mediator.Send(updateClientInput);
        return Ok(result);
    }
}