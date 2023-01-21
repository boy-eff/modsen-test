using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModsenEventService.Application.Dtos;
using ModsenEventService.Application.Features.ModsenEvents.Commands;
using ModsenEventService.Application.Features.ModsenEvents.Queries;
using ModsenEventService.Domain.Models;

namespace ModsenEventService.API.Controllers;

[ApiController]
[Route("api/events")]
public class ModsenEventController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IValidator<ModsenEventDto> _validator;

    public ModsenEventController(IMediator mediator, IValidator<ModsenEventDto> validator)
    {
        _mediator = mediator;
        _validator = validator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var query = new GetModsenEventsQuery();
        var result =  await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{eventId}")]
    public async Task<IActionResult> GetByIdAsync(Guid eventId)
    {
        if (eventId == Guid.Empty)
        {
            return BadRequest();
        }
        var query = new GetModsenEventByIdQuery(eventId);
        var result =  await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody]ModsenEventDto dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
        {
            return BadRequest();
        }
        var query = new AddModsenEventCommand(dto);
        var result =  await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody]ModsenEventDto dto)
    {
        var validationResult = await _validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
        {
            return BadRequest();
        }
        var query = new UpdateModsenEventCommand(dto);
        var result =  await _mediator.Send(query);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromQuery]Guid eventId)
    {
        if (eventId == Guid.Empty)
        {
            return BadRequest();
        }
        var query = new DeleteModsenEventCommand(eventId);
        var result =  await _mediator.Send(query);
        return Ok();
    }
}