using MediatR;
using Microsoft.AspNetCore.Mvc;
using ModsenEventService.Domain.Models;

namespace ModsenEventService.API.Controllers;

[ApiController]
[Route("api/events")]
public class ModsenEventController : ControllerBase
{
    private readonly IMediator _mediator;

    public ModsenEventController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public IList<ModsenEvent> GetAsync()
    {
        throw new NotImplementedException();
    }

    [HttpGet("{eventId}")]
    public ModsenEvent GetByIdAsync([FromQuery]Guid eventId)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public Task AddAsync()
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    public Task UpdateAsync()
    {
        throw new NotImplementedException();
    }

    [HttpDelete]
    public Task DeleteAsync()
    {
        throw new NotImplementedException();
    }
}