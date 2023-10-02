using Microsoft.AspNetCore.Mvc;
using YourProjectName.Models;

namespace YourProjectName.Controllers
{
    [Route("api/character")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterRepository _characterRepository;

        public CharacterController(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        // GET: api/character
        [HttpGet]
        public ActionResult<Character> Get()
        {
            // Implement logic to retrieve the character from the repository
            var character = _characterRepository.GetCharacter();
            if (character == null)
            {
                return NotFound();
            }
            return Ok(character);
        }

        // PUT: api/character
        [HttpPut]
        public ActionResult<Character> Put([FromBody] Character character)
        {
            // Implement logic to update the character in the repository
            if (character == null)
            {
                return BadRequest();
            }

            // Ensure the character exists and then update its attributes
            var existingCharacter = _characterRepository.GetCharacter();
            if (existingCharacter == null)
            {
                return NotFound();
            }

            existingCharacter.Name = character.Name;
            existingCharacter.Quickness = character.Quickness;
            existingCharacter.Ugly = character.Ugly;
            existingCharacter.Arcana = character.Arcana;
            existingCharacter.Cool = character.Cool;
            existingCharacter.Kismit = character.Kismit;
            existingCharacter.Kudos = character.Kudos;
            existingCharacter.Heart = character.Heart;
            existingCharacter.Psyche = character.Psyche;
            existingCharacter.Armour = character.Armour;
            existingCharacter.Equipment = character.Equipment;
            existingCharacter.TreasureDucats = character.TreasureDucats;
            existingCharacter.Pets = character.Pets;
            existingCharacter.Quirks = character.Quirks;
            existingCharacter.Quests = character.Quests;

            // Save the updated character
            _characterRepository.UpdateCharacter(existingCharacter);

            return Ok(existingCharacter);
        }

        // Add other CRUD operations (POST, DELETE) as needed
    }
}
