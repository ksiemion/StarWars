using Microsoft.AspNetCore.Mvc;
using StarWars.Infrastructure.DTO;
using StarWars.Infrastructure.Services;

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
            {
                return Ok(pl);
            }
            else
                return NotFound();
        }

        // GET api/<PlanetController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var pl = _planetService.GetByID(id);
            if (pl != null)
            {
                return Ok(pl);
            }
            else
            {
                return NotFound($"Planet By ID {id} was not found");
            }
        }

        // POST api/<PlanetController>
        [HttpPost]
        public IActionResult Post(PlanetDTO planet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pl = _planetService.Add(planet);
            if (pl == null)
            {
                return NotFound($"Could not add planet to the database");
            }
            return CreatedAtAction("Get", new { id = pl.ID }, pl);
        }

        // PUT api/<PlanetController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, PlanetDTO planet)
        {
            _planetService.Update(id, planet);
            return Ok(planet);
        }

        // DELETE api/<PlanetController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _planetService.Delete(id);
        }
    }
}
