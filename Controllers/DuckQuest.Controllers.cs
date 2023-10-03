using Microsoft.AspNetCore.Mvc;
using DuckQuest.Models;

namespace DuckQuest.Controllers
{
    [Route("character")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        [HttpGet("generate")]
        public ActionResult<Character> GenerateCharacter()
        {
            // Implement logic to generate a random character
            var character = GenerateRandomCharacter();

            // You can return the character directly or return it as JSON
            // return character;
            return Ok(character);
        }

        private Character GenerateRandomCharacter()
        {
            // Implement logic to generate a random character here
            // You can set random values for each attribute as needed

            var randomCharacter = new Character
            {
                Id = 1,
                Name = "RandomCharacter",
                // Set other attributes with random values
            };

            return randomCharacter;
        }
    }
}
