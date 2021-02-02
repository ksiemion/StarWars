using Microsoft.AspNetCore.Mvc;
using StarWars.Infrastructure.DTO;
using StarWars.Infrastructure.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StarWars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        // GET: api/<CharacterController>
        [HttpGet]
        public IActionResult Get()
        {
            var chr = _characterService.GetCharacters();
            if (chr != null)
                return Ok(chr);
            else
                return NotFound();
        }

        // GET: api/<CharacterController>
        [HttpGet("{pageNumber}/{pageSize}")]
        public IActionResult GetByPage(int pageNumber = 1, int pageSize = 5)
        {
            var chr = _characterService.GetCharacters(pageNumber, pageSize);
            if (chr != null)
                return Ok(chr);
            else
                return NotFound();
        }

        // GET api/<CharacterController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var chr = _characterService.GetCharacter(id);
            if (chr != null)
                return Ok(chr);
            else return NotFound();
        }

        // POST api/<CharacterController>
        [HttpPost]
        public void Post(CharacterDTO character)
        {
            _characterService.Add(character);
        }

        // PUT api/<CharacterController>/5
        [HttpPut("{id}")]
        public void Put(int id, CharacterDTO character)
        {
            _characterService.Update(id, character);
        }

        // DELETE api/<CharacterController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _characterService.Delete(id);
        }
    }
}
