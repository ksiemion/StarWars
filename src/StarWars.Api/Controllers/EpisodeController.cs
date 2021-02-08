using Microsoft.AspNetCore.Mvc;
using StarWars.Infrastructure.DTO;
using StarWars.Infrastructure.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StarWars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpisodeController : ControllerBase
    {
        private readonly IEpisodeService _episodeService;

        public EpisodeController(IEpisodeService episodeService)
        {
            _episodeService = episodeService;
        }

        // GET: api/<EpisodeController>
        [HttpGet]
        public IActionResult Get()
        {
            var ep = _episodeService.GetEpisodes();
            if (ep != null)
            {
                return Ok(ep);
            }
            else return NotFound();
        }

        // GET api/<EpisodeController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var ep = _episodeService.GetByID(id);
            if (ep != null)
            {
                return Ok(ep);
            }
            else
            {
                return NotFound($"Episode By ID {id} was not found");
            }
        }

        // POST api/<EpisodeController>
        [HttpPost]
        public IActionResult Post(EpisodeDTO episode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var epi = _episodeService.Add(episode);
            if (epi == null)
            {
                return NotFound($"Could not add episode to the database");
            }
            return CreatedAtAction("Get", new { id = epi.ID }, epi);
        }

        // PUT api/<EpisodeController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, EpisodeDTO episode)
        {
            _episodeService.Update(id, episode);
            return Ok(episode);
        }

        // DELETE api/<EpisodeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _episodeService.Delete(id);
        }
    }
}
