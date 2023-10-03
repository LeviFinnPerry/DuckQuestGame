using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DuckQuest.Models;
using System;

namespace DuckQuest.Controllers
{
    [ApiController]
    [Route("api/character")]
    public class EnterAttributesController : ControllerBase
    {
        [HttpGet("enter-attributes")]
        public IActionResult EnterAttributes()
        {
            // Retrieve the character's name from session or temporary storage
            var characterName = HttpContext.Session.GetString("CharacterName");

            if (string.IsNullOrEmpty(characterName))
            {
                // If the name is not stored, redirect back to the name input step
                return RedirectToAction("GenerateCharacter");
            }

            // Return the HTML form for entering other attributes
            return Content(GetAttributeInputFormHtml(characterName), "text/html");
        }

        [HttpPost("enter-attributes")]
        public IActionResult EnterAttributes([FromForm] CharacterAttributesInputModel inputModel)
        {
            // Validate the input model here if needed

            // Retrieve the character's name from session storage
            var characterName = HttpContext.Session.GetString("CharacterName");

            // Create a character object with the name and other attributes
            var character = new Character
            {
                Name = characterName,
                Quickness = inputModel.Quickness,
                Ugly = inputModel.Ugly,
                Arcana = inputModel.Arcana,
                Cool = inputModel.Cool,
                Kismit = inputModel.Kismit,
            };

            // You can save the character or perform other actions here

            return Ok(character);
        }

        private string GetAttributeInputFormHtml(string characterName)
        {
            // Return the HTML form for entering character attributes
            return $@"
                <!DOCTYPE html>
                <html lang=""en"">
                <!-- Rest of your HTML form here -->
                </html>";
        }
    }
}
