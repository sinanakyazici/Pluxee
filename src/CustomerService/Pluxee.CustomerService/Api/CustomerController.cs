using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pluxee.CustomerService.Application.Commands.CustomerCommands.CreateCustomer;
using Pluxee.CustomerService.Application.Queries.CustomerQueries.GetCustomers;
using Pluxee.CustomerService.Domain.Customer;

namespace Pluxee.CustomerService.Api;

[ApiController]
[Route("api/v1/customers")]
public class CustomerController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CustomerViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CustomerViewModel>>> GetCustomers()
    {
        var data = await mediator.Send(new GetCustomersQuery());
        return Ok(data);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> CreateCustomer([FromBody] CreateCustomerCommand request)
    {
        await mediator.Send(request);
        return Created();
    }
}