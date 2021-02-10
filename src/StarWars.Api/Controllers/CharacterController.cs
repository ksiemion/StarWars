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
            {
                return Ok(chr);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: api/<CharacterController>
        [HttpGet("{pageNumber}/{pageSize}")]
        public IActionResult GetByPage(int pageNumber = 1, int pageSize = 5)
        {
            var chr = _characterService.GetCharacters(pageNumber, pageSize);
            if (chr != null)
            {
                return Ok(chr);
            }
            else
            {
                return NotFound();
            }
        }

        // GET api/<CharacterController>/5
        [HttpGet("{id}", Name = "GetCharacter")]
        public IActionResult Get(int id)
        {
            var chr = _characterService.GetCharacter(id);
            if (chr != null)
            {
                return Ok(chr);
            }
            else
            {
                return NotFound($"Character By ID {id} was not found");
            }
        }

        // POST api/<CharacterController>
        [HttpPost]
        public IActionResult Post(CharacterDTO character)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chr = _characterService.Add(character);
            if (chr == null)
            {
                return NotFound($"Could not add character to the database");
            }
            return CreatedAtAction("Get", new { id = chr.ID }, chr);
        }

        // PUT api/<CharacterController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, CharacterDTO character)
        {
            return Ok(_characterService.Update(id, character));
        }

        // DELETE api/<CharacterController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _characterService.Delete(id);
            return NoContent();
        }
    }
}
 