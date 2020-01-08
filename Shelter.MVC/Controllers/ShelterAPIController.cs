using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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

        [HttpGet("shelters")]
        // show all shelters name and id's
        public IActionResult GetAllShelters() 
        {
            return Ok(_dataAccess.GetAllShelters());
        }

        [HttpGet("sheltersFull")]
        // show all shelters full with employees and animals
        public IActionResult GetAllSheltersFull() 
        {
            return Ok(_dataAccess.GetAllSheltersFull());
        }

        [HttpGet("shelter/{shelterId}")]
        //show 1 specific shelters name and id
        public IActionResult getThisShelterById(int shelterId)
        {
            var shelter = _dataAccess.GetShelterById(shelterId);
            return shelter == default(Shared.Shelter) ? (IActionResult)NotFound() : Ok(shelter);
        }

        [HttpGet("shelter/{shelterId}/animal/{animalId}")]
        //show all info about 1 specific animal by using it's id and shelter it resides in
        public IActionResult getAllAnimals(int shelterId, int animalId)
        {
            var animal = _dataAccess.GetAnimalByShelterAndId(shelterId, animalId);
            return animal == default(Shared.Animal) ? (IActionResult)NotFound() : Ok(animal);
        }

        [HttpGet("showAnimals/{shelterId}")]
        //show all animals from 1 specific shelter
        public IActionResult getAnimals(int shelterId)
        {
            var animals = _dataAccess.GetAnimals(shelterId);
            return animals == default(IEnumerable<Animal>) ? (IActionResult)NotFound() : Ok(animals);
        }

        [HttpDelete("deleteAnimal/{animalId}/{shelterId}")]
        public IActionResult DoDeleteAnimal(int shelterId, int animalId)
        {
           Animal pickedAnimal = _dataAccess.DeleteAnimal(shelterId, animalId);
            if(pickedAnimal == null){
                return NotFound("error 404: animal or shelter not found");
            }else {
                return Ok(pickedAnimal);
            }
            
        }

        [HttpPut("updateAnimal/{animalId}/{shelterId}")]
        public IActionResult DoUpdateAnimal(int shelterId, int animalId, string new_name, string dateOfBirth, bool isChecked, bool kidFriendly, string dateOfArrival, int new_shelterId)
        {
           Animal pickedAnimal = _dataAccess.UpdateAnimal(shelterId, animalId, new_name, dateOfBirth, isChecked, kidFriendly, dateOfArrival, new_shelterId);

             if(pickedAnimal == null){
                return NotFound("error 404: animal or shelter not found");
            }else {
                return Ok(pickedAnimal);
            }
        }

        [HttpPost("createAnimal/{ShelterId}/Cat")]
        //Create an cat
        public IActionResult DoCreateCat(int ShelterId, Shelter.Shared.Cat cat)
        {
            _dataAccess.CreateCat(ShelterId, cat);
            return Ok();
        }

        [HttpPost("createAnimal/{ShelterId}/Dog")]
        //Create a dog
        public IActionResult DoCreateDog(int ShelterId, Shelter.Shared.Dog dog)
        {
            _dataAccess.CreateDog(ShelterId, dog);
            return Ok();
        }
        
        [HttpPost("createAnimal/{ShelterId}/Others")]
        //Create an other animal
        public IActionResult DoCreateOther(int ShelterId, Shelter.Shared.Other other)
        {
            _dataAccess.CreateOther(ShelterId, other);
            return Ok();
        }
    }
}