using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using newMVCproject.Models;
using Shelter.Shared;
using System.Net.Http.Headers;

namespace newMVCproject.Controllers
{
    [Route("/api")]
    public class ShelterAPIController : Controller 
    {

        public ShelterAPIController(){

        }

        [Route("shelters")]
        public IActionResult GetAllShelters()
        {
            return Ok(.Shelters);
        }
    }
}