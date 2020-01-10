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

        /// <summary>
        /// Shows all shelters
        /// </summary>
        [HttpGet("shelters")]
        [Authorize]
        // show all shelters name and id's
        public IActionResult GetAllShelters()
        {
            return Ok(_dataAccess.GetAllShelters());
        }

        /// <summary>
        /// Shows all shelters
        /// </summary>
        [HttpGet("sheltersFull")]
        [Authorize]
        // show all shelters full with employees and animals
        public IActionResult GetAllSheltersFull()
        {
            return Ok(_dataAccess.GetAllSheltersFull());
        }
        
        /// <summary>
        /// Shows all shelters
        /// </summary>
        [HttpGet("shelter/{shelterId}")]
        [Authorize]
        //show 1 specific shelters name and id
        public IActionResult getThisShelterById(int shelterId)
        {
            var shelter = _dataAccess.GetShelterById(shelterId);
            return shelter == default(Shared.Shelter) ? (IActionResult)NotFound("No shelter found with these parameters") : Ok(shelter);
        }

        /// <summary>
        /// Shows all shelters
        /// </summary>
        [HttpGet("shelter/{shelterId}/animal/{animalId}")]
        [Authorize]
        //show all info about 1 specific animal by using it's id and shelter it resides in
        public IActionResult getAllAnimals(int shelterId, int animalId)
        {
            var animal = _dataAccess.GetAnimalByShelterAndId(shelterId, animalId);
            return animal == default(Shared.Animal) ? (IActionResult)NotFound("No animal found with these parameters") : Ok(animal);
        }

        /// <summary>
        /// Shows all shelters
        /// </summary>
        [HttpGet("showAnimals/{shelterId}")]
        [Authorize]
        //show all animals from 1 specific shelter
        public IActionResult getAnimals(int shelterId)
        {
            var animals = _dataAccess.GetAnimals(shelterId);
            return animals == default(IEnumerable<Animal>) ? (IActionResult)NotFound("No animals found with these parameters") : Ok(animals);
        }

        /// <summary>
        /// Shows all shelters
        /// </summary>
        [HttpDelete("deleteAnimal/{animalId}/{shelterId}")]
        [Authorize]
        public IActionResult DoDeleteAnimal(int shelterId, int animalId)
        {
            Animal pickedAnimal = _dataAccess.DeleteAnimal(shelterId, animalId);

            return pickedAnimal == default(Shared.Animal) ? (IActionResult)NotFound("No animal found with these parameters") : Ok(pickedAnimal);

        }

        /// <summary>
        /// Shows all shelters
        /// </summary>
        [HttpPut("updateAnimal/{animalId}/{shelterId}")]
        [Authorize]
        public IActionResult DoUpdateAnimal(int shelterId, int animalId, string new_name, string dateOfBirth, bool isChecked, bool kidFriendly, string dateOfArrival, int new_shelterId)
        {
            Animal pickedAnimal = _dataAccess.UpdateAnimal(shelterId, animalId, new_name, dateOfBirth, isChecked, kidFriendly, dateOfArrival, new_shelterId);

            return pickedAnimal == default(Shared.Animal) ? (IActionResult)NotFound("No animal found with these parameters") : Ok(pickedAnimal);
        }
        
        /// <summary>
        /// Shows all shelters
        /// </summary>
        [HttpPost("createAnimal/{ShelterId}/Cat")]
        [Authorize]
        //Create an cat
        public IActionResult DoCreateCat(int ShelterId, Shelter.Shared.Cat cat)
        {
            Animal createdAnimal = _dataAccess.CreateCat(ShelterId, cat);
            return createdAnimal == default(Shared.Animal) ? (IActionResult)NotFound("No animal found with these parameters") : Ok(createdAnimal);
        }

        /// <summary>
        /// Shows all shelters
        /// </summary>
        [HttpPost("createAnimal/{ShelterId}/Dog")]
        [Authorize]
        //Create a dog
        public IActionResult DoCreateDog(int ShelterId, Shelter.Shared.Dog dog)
        {
            Animal createdAnimal = _dataAccess.CreateDog(ShelterId, dog);
            return createdAnimal == default(Shared.Animal) ? (IActionResult)NotFound("No animal found with these parameters") : Ok(createdAnimal);
        }

        /// <summary>
        /// Shows all shelters
        /// </summary>
        [HttpPost("createAnimal/{ShelterId}/Others")]
        [Authorize]
        //Create an other animal
        public IActionResult DoCreateOther(int ShelterId, Shelter.Shared.Other other)
        {
            Animal createdAnimal = _dataAccess.CreateOther(ShelterId, other);
            return createdAnimal == default(Shared.Animal) ? (IActionResult)NotFound("No animal found with these parameters") : Ok(createdAnimal);
        }
    }
}