using Microsoft.AspNetCore.Mvc;
using StarWars.Infrastructure.DTO;
using StarWars.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StarWars.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanetController : ControllerBase
    {
        private readonly IPlanetService _planetService;

        public PlanetController(IPlanetService planetService)
        {
            _planetService = planetService;
        }

        // GET: api/<PlanetController>
        [HttpGet]
        public IActionResult Get()
        {
            var pl = _planetService.GetAll();
            if (pl != null)
                return Ok(pl);
            else
                return NotFound();
        }

        // GET api/<PlanetController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var pl = _planetService.GetByID(id);
            if (pl != null)
                return Ok(pl);
            else return NotFound();
        }

        // POST api/<PlanetController>
        [HttpPost]
        public void Post(PlanetDTO planet)
        {
            _planetService.Add(planet);
        }

        // PUT api/<PlanetController>/5
        [HttpPut("{id}")]
        public void Put(int id, PlanetDTO planet)
        {
            _planetService.Update(id, planet);
        }

        // DELETE api/<PlanetController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _planetService.Delete(id);
        }
    }
}
