using System.Net.Mime;
using System.Security;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Music4All.API.Resources;
using Music4All.Domain;
using Music4All.Infraestructure.Models;

namespace Music4All.API.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class MusicsController : ControllerBase
{
     private readonly IMusicDomain _musicDomain;
     private readonly IMapper _mapper;
    
    public MusicsController(IMusicDomain eventDomain, IMapper mapper)
    {
        _musicDomain = eventDomain;
        _mapper = mapper;
    }

       // GET: api/Musics
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<string>), 200)]
    //GET api/Musics/byName?name
  //  [HttpGet("byName")]
    public async Task<IActionResult> Get()
    {
        try
        {
            var result = await _musicDomain.getAll();
            return Ok(_mapper.Map<List<Music>, List<MusicResource>>(result));
        }
        catch (Exception exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
        }
        
    }

    // GET: api/Musics/5
    [HttpGet("{id}", Name = "GetMusic")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            if (id == 0)
            {
                return BadRequest("Id");
            }
            var result = await _musicDomain.getMusicById(id); 
            return Ok(_mapper.Map<Music, MusicResource>(result));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
        }
    }

    
    // POST: api/Musics
    [HttpPost]
    [ProducesResponseType(typeof(IActionResult), 201)]
    [ProducesResponseType(typeof(List<Music>), 400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Post([FromBody] MusicResource musicInput)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("error de formato");
            }

            var music = _mapper.Map<MusicResource, Music>(musicInput);

            var result = await _musicDomain.createMusic(music);

            return StatusCode(StatusCodes.Status201Created, "Music created");
        }
        catch (ArgumentException argumentException)
        {
            return StatusCode(StatusCodes.Status400BadRequest, argumentException.Message);
        }
        catch (InvalidCastException invalidCastException)
        {
            return StatusCode(StatusCodes.Status400BadRequest, "Error interno al castear");
        }
        catch (VerificationException verificationException)
        {
            return StatusCode(StatusCodes.Status400BadRequest, verificationException.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar , intente mas tarde");
        }
    }

    // PUT: api/Musics/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Music music)
    {
        try
        {
            var result = await _musicDomain.updateMusic(id, music);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
        }
    }

    // DELETE: api/Musics/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var result = await _musicDomain.deleteMusic(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
        }

    }
  
}