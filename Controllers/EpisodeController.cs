using Microsoft.AspNetCore.Mvc;
using StarWars.Models;
using StarWars.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return Ok(_episodeService.GetEpisodes());
        }

        // GET api/<EpisodeController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_episodeService.GetByID(id));
        }

        // POST api/<EpisodeController>
        [HttpPost]
        public void Post(Episode episode)
        {
            _episodeService.Add(episode);
        }

        // PUT api/<EpisodeController>/5
        [HttpPut("{id}")]
        public void Put(int id, Episode episode)
        {
            _episodeService.Update(id, episode);
        }

        // DELETE api/<EpisodeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _episodeService.Delete(id);
        }
    }
}
