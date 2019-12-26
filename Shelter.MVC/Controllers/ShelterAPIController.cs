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
        private readonly ShelterContext _shelterContext; //delete?
        private readonly IShelterDataAccess _dataAccess;
        private readonly ILogger<ShelterAPIController> _logger;
        /*public ShelterAPIController(ILogger<ShelterAPIController> logger, ShelterContext sheltercontext)
        {
            _shelterContext = sheltercontext;
            _logger = logger;
        }*/
        public ShelterAPIController(ILogger<ShelterAPIController> logger, IShelterDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
            _logger = logger;
        }

        [HttpGet("shelters")]
        // show all shelters
        public IActionResult GetAllShelters() 
        {
            return Ok(_dataAccess.GetAllSheltersFull());
        }

        [HttpGet("Shelter/{shelterId)")]
        public IActionResult getShelterById(int shelterId)
        {
            var shelter = _dataAccess.GetShelterById(shelterId); ;
            return shelter == default(Shared.Shelter) ? (IActionResult)NotFound() : Ok(shelter);
        }
 
        [HttpGet("shelter/{shelterId}/animals")]
        //show all animals from a certain shelter
        public IActionResult getAllAnimals(int shelterId)
        {
            return Ok(_shelterContext.Shelters.Include(X => X.Animals).FirstOrDefault(X => X.Id == shelterId)); 
            // change to dataAccess animalbyshelterandid? 
        }

        [HttpGet("showAll")]
        //show animals with all their shelter info in list (animalId, shelterId, animalName,shelterName)
        public IActionResult getAllAnimalsAndShelters()
        {
           var Shelters = 
                from Shelter in _shelterContext.Shelters
                select Shelter;
            
            var Animals = 
                from Animal in _shelterContext.Animals
                select Animal;

            List<String> animalsandshelters = new List<String>();

            foreach(var shelter in Shelters){
                foreach(var a in Animals){
                    animalsandshelters.Add(a.name + " " + a.Id.ToString() + " " + shelter.name + " " + shelter.Id.ToString());
                }
            }
            return Ok(animalsandshelters);
          //change to dataAccess show all animals with shelterinfo
        }
    }
}