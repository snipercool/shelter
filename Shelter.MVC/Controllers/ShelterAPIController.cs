using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
            return Ok(_shelterContext.Shelters);
        }

        //show all animals      animals from 1 shelter so make it from certain shelter?
        [Route("shelter{shelterId}/animals")]
        // public action get all animals
        public IActionResult getAllAnimals()
        {
          return Ok(_shelterContext.Cats);    
        }

        //show animals with all shelter info     die alle animals laat zien gecombineerd met hun shelter informatie in één platte lijst { animalId, shelterId, animalName, shelterName } of iets gelijkaardig.
        //[Route("fullList")]
        // publoc action get all animals with shelter info
        //{
        //  return ok();
        //}

    }
}