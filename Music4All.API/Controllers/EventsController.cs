using System.Net.Mime;
using System.Security;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Music4All.API.Resources;
using Music4All.Domain;
using Music4All.Infraestructure.Models;

namespace Music4All.API.Controllers;

//[Authorize]
[Route("api/v1/[controller]")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class EventsController : ControllerBase
{
     private readonly IEventDomain _eventDomain;
     private readonly IMapper _mapper;
    
    public EventsController(IEventDomain eventDomain, IMapper mapper)
    {
        _eventDomain = eventDomain;
        _mapper = mapper;
    }

    // GET: api/Events
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<string>), 200)]

    public async Task<IActionResult> Get()
    {
        try
        {
            
            var result = await _eventDomain.getAll();
            return Ok(_mapper.Map<List<Event>, List<EventsResource>>(result));
        }
        catch (Exception exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
        }
        
    }

    // GET: api/Events/5
    [HttpGet("{id}", Name = "GetEvent")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            if (id == 0)
            {
                return BadRequest("No se encontrarom eventos.");
            }
            var result = await _eventDomain.getEventById(id); 
            return Ok(_mapper.Map<Event, EventsResource>(result));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
        }
    }
    
    // POST: api/Categories
    [HttpPost]
    [ProducesResponseType(typeof(IActionResult), 201)]
    [ProducesResponseType(typeof(List<Event>), 400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Post([FromBody] EventsResource eventInput)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("error de formato");
            }

            var evento = _mapper.Map<EventsResource, Event>(eventInput);

            var result = await _eventDomain.createEvent(evento);

            return StatusCode(StatusCodes.Status201Created, "event created");
        }
        catch (ArgumentException argumentException)
        {
            return StatusCode(StatusCodes.Status400BadRequest, argumentException.Message);
        }
        catch (InvalidCastException invalidCastException)
        {
            return StatusCode(StatusCodes.Status400BadRequest, "Error interno al castear");
        }
    }

    // PUT: api/Events/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Event evento)
    {
        try
        {
            var result = await _eventDomain.updateEvent(id, evento);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
        }
    }

    // DELETE: api/Event/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var result = await _eventDomain.deleteEvent(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
        }

    }
  
}