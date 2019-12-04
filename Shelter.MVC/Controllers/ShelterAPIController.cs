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
        public IActionResult GetAllShelters()
        {
            return Ok(_shelterContext.Shelters);
        }

    }
}