using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pluxee.Domain.Event.Integration;
using Pluxee.OrderService.Application.Commands.CreateOrder;
using Pluxee.OrderService.Application.Queries.GetOrders;
using Pluxee.OrderService.Domain.Order;
using Pluxee.Shared.Domain.Customer.Events;

namespace Pluxee.OrderService.Api;

[ApiController]
[Route("api/v1/orders")]
public class CustomerController(IMediator mediator, IIntegrationEventHandler<CustomerCreatedIntegrationEvent> handler) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<OrderViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<OrderViewModel>>> GetOrders(CancellationToken cancellationToken)
    {
        await handler.Handle(new CustomerCreatedIntegrationEvent());
        var data = await mediator.Send(new GetOrdersQuery(), cancellationToken);
        return Ok(data);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> CreateOrder([FromBody] CreateOrderCommand request, CancellationToken cancellationToken)
    {
        await mediator.Send(request, cancellationToken);
        return Created();
    }
}