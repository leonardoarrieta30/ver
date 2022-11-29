
using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Music4All.API.Resources;
using Music4All.Domain;
using Music4All.Infraestructure.Models;

namespace Music4All.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class MusicianController : ControllerBase
{
     private readonly IMusicianDomain _musicianDomain;
     private readonly IMapper _mapper;
    
    public MusicianController(IMusicianDomain musicianDomain, IMapper mapper)
    {
        _musicianDomain = musicianDomain;
        _mapper = mapper;
    }

  
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<string>), 200)]

    public async Task<IActionResult> Get()
    {
        try
        {
            var result = await _musicianDomain.getAll();
            return Ok(_mapper.Map<List<Musician>, List<MusicianResource>>(result));
        }
        catch (Exception exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
        }
        
    }

  
    [HttpGet("{id}", Name = "GetMusician")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            if (id == 0)
            {
                return BadRequest("Id");
            }
            var result = await _musicianDomain.getMusicianById(id); 
            return Ok(_mapper.Map<Musician, MusicianResource>(result));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
        }
    }


    [HttpPost]
    [ProducesResponseType(typeof(IActionResult), 201)]
    [ProducesResponseType(typeof(List<Musician>), 400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Post([FromBody] MusicianResource musicianInput)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("error de formato");
            }

            var musician = _mapper.Map<MusicianResource, Musician>(musicianInput);

            var result = await _musicianDomain.createMusician(musician);

            return StatusCode(StatusCodes.Status201Created, " created");
        }
        catch (ArgumentException argumentException)
        {
            return StatusCode(StatusCodes.Status400BadRequest, argumentException.Message);
        }
        
    }

/*
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Musician musician)
    {
        try
        {
            var result = await _musicianDomain.updateMusician(id, musician);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
        }
    }
*/
    // DELETE: api/Musics/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var result = await _musicianDomain.deleteMusician(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
        }

    }
}