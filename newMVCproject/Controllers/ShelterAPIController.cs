using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using newMVCproject.Models;
using Shelter.Shared;

namespace newMVCproject.Controllers
{
    [Route("/api")]
    public class ShelterAPIController : Controller 
    {
        private readonly ShelterContext _shelterContext;
        public ShelterAPIController(){

        }

        [Route("shelters")]
        public IActionResult GetAllShelters()
        {
            return Ok(_shelterContext.Shelters);
        }
    }
}