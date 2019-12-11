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
            return Ok(_shelterContext.Shelters.Include(X => X.Animals).Include(x => x.Employees));
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
          return Ok(_shelterContext.Shelters.Include(X => X.Animals).Select(c => new {c.Id, c.name, c.Animals})); //change once fixed in other file    
        }

    }
}