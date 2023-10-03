using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DuckQuest.Models;
using System;

namespace DuckQuest.Controllers
{
    [Route("api/character")]
    [ApiController]
    public class CharacterNameController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CharacterNameController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("generate")]
        public IActionResult GenerateCharacter()
        {
            // Check if a character name is already stored in session
            string characterName = _httpContextAccessor.HttpContext.Session.GetString("CharacterName");

            if (string.IsNullOrEmpty(characterName))
            {
                // Generate random numbers to select a first name and last name
                Random random = new Random();
                int firstNameIndex = random.Next(NameGenerator.FirstNames.Length);
                int lastNameIndex = random.Next(NameGenerator.LastNames.Length);

                // Get the selected first and last names
                string firstName = NameGenerator.FirstNames[firstNameIndex];
                string lastName = NameGenerator.LastNames[lastNameIndex];

                // Store the generated name in session
                characterName = $"{firstName} {lastName}";
                _httpContextAccessor.HttpContext.Session.SetString("CharacterName", characterName);
            }

            return View("GenerateCharacterView");
        }

        [HttpPost("generate")]
        public IActionResult GenerateCharacter([FromForm] CharacterNameInputModel inputModel)
        {
            // Validate the input model here if needed

            // Store the entered name in a session or temporary storage
            _httpContextAccessor.HttpContext.Session.SetString("CharacterName", inputModel.Name);

            return Ok(new
            {
                Name = inputModel.Name
            });
        }


        public static class NameGenerator
        {
            public static string[] FirstNames = new string[]
            {
                "Apple", "Drake", "Cherry", "Manu", "Rouen", "Zachary", "Sirius", "Feather", "Yolko", "Mallory",
                "Webster", "Honeydew", "Wade", "Chick", "Squirt", "Bubbles", "Moby", "Eggbert", "Wing-Wing", "Bill"
            };

            public static string[] LastNames = new string[]
            {
                "Bluebill", "Skywaddler", "Pintail", "Alfac", "LeeAylesbury", "Grimaud", "Duclair", "Grape-Asker", "Mallard", "Reed",
                "Canard", "Blekingeanka", "Flapper", "Rubberduck", "Thunderbill", "Duckington", "Wisequack", "Cobb", "Frankenduck", "Puddlefoot"
            };
        }
    }
}
