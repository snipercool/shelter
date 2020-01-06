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
           Animal pickedAnimal = _dataAccess.DeleteAnAnimal(shelterId, animalId);
            if(pickedAnimal == null){
                return NotFound("error 404: animal or shelter not found");
            }else {
                return Ok("deleted animal from database");
            }
            
        }

        //doesn't work yet

        [HttpPut("updateAnimal/{animalId}/{shelterId}")]
        public IActionResult DoUpdateAnimal(int shelterId, int animalId,[FromBody]Shared.Animal animal)
        {
            var pickedAnimal = _dataAccess.GetAnimalByShelterAndId(shelterId, animalId);

            return Ok(animal);
        }
    }
}