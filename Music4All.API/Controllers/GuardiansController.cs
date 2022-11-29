using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Music4All.API.Resources;
using Music4All.Domain;
using Music4All.Infraestructure.Models;

namespace Music4All.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class GuardiansController : ControllerBase
{
        private readonly IGuardianDomain _guardianDomain;
        private readonly IMapper _mapper;
        
        

        public GuardiansController(IGuardianDomain guardianDomain, IMapper mapper)
        {
            _guardianDomain = guardianDomain;
            _mapper = mapper;
        }

        // GET: api/Guardians
        [HttpGet]
        //[ProducesResponseType(typeof(IEnumerable<string>), 200)]
        public async Task<IEnumerable<GuardianResource>>  Get()
        {
            var providers = await _guardianDomain.getAll();
            var resources = _mapper.Map<IEnumerable<Guardian>, IEnumerable<GuardianResource>>(providers);
            return resources;

        }

        // GET: api/Guardians/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            var guardian = await _guardianDomain.getGuardianById(id);
            var resource = _mapper.Map<Guardian, GuardianResource>(guardian);
            return Ok(resource);
        }

        // POST: api/Guardians
        [HttpPost]
        [ProducesResponseType(typeof(IActionResult), 201)]
        [ProducesResponseType(typeof(IEnumerable<Guardian>), 400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Post([FromBody] SaveGuardianResource resource)
        {
            if (!ModelState.IsValid)
                     return BadRequest("error de formato");
            
            var guardian = _mapper.Map<SaveGuardianResource, Guardian>(resource);
            var result = await _guardianDomain.createGuardian(guardian);

            var guardianResource = _mapper.Map<Guardian,GuardianResource>(result.Resource);
            return Ok(guardianResource);
            
        }

        // PUT: api/Guardians/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SaveGuardianResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest("error de formato");
            var guardian = _mapper.Map<SaveGuardianResource, Guardian>(resource);
            var result = await _guardianDomain.updateGuardian(id,guardian);
            if (!result.Success)
                return BadRequest(result.Message);
            var guardianResource = _mapper.Map<Guardian, GuardianResource>(result.Resource);
            return Ok(guardianResource);
        }

        // DELETE: api/Guardians/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _guardianDomain.deleteGuardian(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var resource = _mapper.Map<Guardian, GuardianResource>(result.Resource);
            return Ok(resource);

        }
}

