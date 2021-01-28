using Microsoft.AspNetCore.Mvc;
using StarWars.DTO;
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
            return Ok(_characterService.GetCharacters());
        }

        // GET api/<CharacterController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_characterService.GetCharacter(id));
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
