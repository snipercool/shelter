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

        //show all animals from a certain shelter
        [Route("shelter/{shelterId}/animals")]
        public IActionResult getAllAnimals(int shelterId)
        {
           //make it only take animals from 1 shelter instead of all the animals
            return Ok(_shelterContext.Shelters.Include(X => X.Animals).FirstOrDefault(X => X.Id == shelterId)); 
        }

        [Route("showAll")]
        //show animals with all their shelter info
        public IActionResult getAllAnimalsAndShelters()
        {
          return Ok(_shelterContext.Dogs); //change once fixed in other file    
        }

    }
}