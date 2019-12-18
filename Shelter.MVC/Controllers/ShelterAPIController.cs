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
        private readonly ShelterContext _shelterContext;
        private readonly ILogger<ShelterAPIController> _logger;
        public ShelterAPIController(ILogger<ShelterAPIController> logger, ShelterContext sheltercontext){
            _shelterContext = sheltercontext;
            _logger = logger;
        }

        [Route("shelters")]
        // show all shelters
        public IActionResult GetAllShelters() 
        {
            var showShelter = 
                from Shelter in _shelterContext.Shelters
                select Shelter;
            List<String> names = new List<String>();
            foreach(var s in showShelter){
                var temp = s.Id.ToString();
                names.Add(s.name);
                names.Add(temp);
            }
            return Ok(names);
        }

        
        [Route("shelter/{shelterId}/animals")]
        //show all animals from a certain shelter
        public IActionResult getAllAnimals(int shelterId)
        {
            return Ok(_shelterContext.Shelters.Include(X => X.Animals).FirstOrDefault(X => X.Id == shelterId)); 
        }

        [Route("showAll")]
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
                    animalsandshelters.Add(a.name);
                    animalsandshelters.Add(a.Id.ToString());
                    animalsandshelters.Add(shelter.name);
                    animalsandshelters.Add(shelter.Id.ToString());
                }
            }

            return Ok(animalsandshelters);

        }
    }
}