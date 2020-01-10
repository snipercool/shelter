using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Shelter.MVC.Models;
using Shelter.Shared;

namespace Shelter.MVC.Controllers
{
    [Route("/api")]
    public class ShelterAPIController : Controller
    {
        private readonly IShelterDataAccess _dataAccess;
        private readonly ILogger<ShelterAPIController> _logger;
        public ShelterAPIController(ILogger<ShelterAPIController> logger, IShelterDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
            _logger = logger;
        }

        /// <summary> Shows all shelters (without animals/employees)</summary>
        /// <response code="401">Authorization required</response>
        /// <response code="404">Item not found</response>  
        [HttpGet("shelters")]
        //[Authorize]
        // show all shelters name and id's
        public IActionResult GetAllShelters()
        {
            return Ok(_dataAccess.GetAllShelters());
        }

        /// <summary> Shows all shelters (with animals/employees</summary>
        /// <response code="401">Authorization required</response>
        /// <response code="404">Item not found</response>  
        [HttpGet("sheltersFull")]
        //[Authorize]
        // show all shelters full with employees and animals
        public IActionResult GetAllSheltersFull()
        {
            return Ok(_dataAccess.GetAllSheltersFull());
        }

        /// <summary>Shows a specific shelter</summary>
        /// <param name="shelterId">ID of the shelter you want to show</param>
        /// <response code="401">Authorization required</response>
        /// <response code="404">Item not found</response>  
        [HttpGet("shelter/{shelterId}")]
        //[Authorize]
        //show 1 specific shelters name and id
        public IActionResult getThisShelterById(int shelterId)
        {
            var shelter = _dataAccess.GetShelterById(shelterId);
            return shelter == default(Shared.Shelter) ? (IActionResult)NotFound("No shelter found with these parameters") : Ok(shelter);
        }

        /// <summary>Shows a specific animal</summary>
        /// <param name="shelterId">ID of the shelter in which the animal is located</param>
        /// <param name="animalId">ID the animal you want to show</param>
        /// <response code="401">Authorization required</response>
        /// <response code="404">Item not found</response>  
        [HttpGet("shelter/{shelterId}/animal/{animalId}")]
        //[Authorize]
        //show all info about 1 specific animal by using it's id and shelter it resides in
        public IActionResult getAllAnimals(int shelterId, int animalId)
        {
            var animal = _dataAccess.GetAnimalByShelterAndId(shelterId, animalId);
            return animal == default(Shared.Animal) ? (IActionResult)NotFound("No animal found with these parameters") : Ok(animal);
        }

        /// <summary>Shows all animals from one shelter</summary>
        /// <param name="shelterId">ID of the shelter you want to see the animals of</param>
        /// <response code="401">Authorization required</response>
        /// <response code="404">Item not found</response>  
        [HttpGet("showAnimals/{shelterId}")]
        //[Authorize]
        //show all animals from 1 specific shelter
        public IActionResult getAnimals(int shelterId)
        {
            var animals = _dataAccess.GetAnimals(shelterId);
            return animals == default(IEnumerable<Animal>) ? (IActionResult)NotFound("No animals found with these parameters") : Ok(animals);
        }

        /// <summary>Delete a specific animal</summary>
        /// <param name="shelterId">ID of the shelter in which the animal is located</param>
        /// <param name="animalId">ID the animal you want to delete</param>
        /// <response code="401">Authorization required</response>
        /// <response code="404">Item not found</response>  
        [HttpDelete("deleteAnimal/{animalId}/{shelterId}")]
        //[Authorize]
        public IActionResult DoDeleteAnimal(int shelterId, int animalId)
        {
            Animal pickedAnimal = _dataAccess.DeleteAnimal(shelterId, animalId);

            return pickedAnimal == default(Shared.Animal) ? (IActionResult)NotFound("No animal found with these parameters") : Ok(pickedAnimal);

        }

        /// <summary>Update a specific animal</summary>
        /// <param name="shelterId">ID of the shelter in which the animal is located</param>
        /// <param name="animalId">ID the animal you want to update</param>
        /// <param name="new_name">The new name of the animal</param>
        /// <param name="dateOfBirth">The new date of birth of the animal</param>
        /// <param name="isChecked">The new checked attribute of the animal</param>
        /// <param name="kidFriendly">The new kidfriendliness of the animal</param>
        /// <param name="dateOfArrival">The new date of arrival of the animal</param>
        /// <param name="new_shelterId">The new ShelterId of the animal</param>
        /// <response code="401">Authorization required</response>
        /// <response code="404">Item not found</response>  
        [HttpPut("updateAnimal/{animalId}/{shelterId}")]
        //[Authorize]
        public IActionResult DoUpdateAnimal(int shelterId, int animalId, string new_name, string dateOfBirth, bool isChecked, bool kidFriendly, string dateOfArrival, int new_shelterId)
        {
            Animal pickedAnimal = _dataAccess.UpdateAnimal(shelterId, animalId, new_name, dateOfBirth, isChecked, kidFriendly, dateOfArrival, new_shelterId);

            return pickedAnimal == default(Shared.Animal) ? (IActionResult)NotFound("No animal found with these parameters") : Ok(pickedAnimal);
        }

        /// <summary>Create a cat</summary>
        /// <param name="cat">Attributes of the cat you want to create</param>
        /// <response code="401">Authorization required</response>
        [HttpPost("createAnimal/Cat")]
        //[Authorize]
        //Create an cat
        public IActionResult DoCreateCat(Shelter.Shared.Cat cat)
        {
            Animal createdAnimal = _dataAccess.CreateCat(cat);
            return createdAnimal == default(Shared.Animal) ? (IActionResult)NotFound("No animal found with these parameters") : Ok(createdAnimal);
        }

        /// <summary>Create a dog</summary>
        /// <param name="dog">Attributes of the dog you want to create</param>
        /// <response code="401">Authorization required</response>
        [HttpPost("createAnimal/Dog")]
        //[Authorize]
        //Create a dog
        public IActionResult DoCreateDog(Shelter.Shared.Dog dog)
        {
            Animal createdAnimal = _dataAccess.CreateDog(dog);
            return createdAnimal == default(Shared.Animal) ? (IActionResult)NotFound("No animal found with these parameters") : Ok(createdAnimal);
        }

        /// <summary>Create a different animal from cat/dog</summary>
        /// <param name="other">Attributes of the other animal you want to create</param>
        /// <response code="401">Authorization required</response>
        [HttpPost("createAnimal/Other")]
        //[Authorize]
        //Create an other animal
        public IActionResult DoCreateOther(Shelter.Shared.Other other)
        {
            Animal createdAnimal = _dataAccess.CreateOther(other);
            return createdAnimal == default(Shared.Animal) ? (IActionResult)NotFound("No animal found with these parameters") : Ok(createdAnimal);
        }
    }
}