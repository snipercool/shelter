using Microsoft.AspNetCore.Mvc;
using Shelter;
using System.Collections.Generic;

namespace newMVCproject.Controllers
{
    public class ShelterController:Controller
    {
        public IActionResult Index()
        {   
            var cats = new List<Cat>{};
            cats.Add(new Cat("Felix","19/01/2005",true, true, "23/09/2019"));
            cats.Add(new Cat("Whiskers","22/07/2008",true, false, "12/06/2018"));
            cats.Add(new Cat("Misty","01/01/2001",true, true, "12/06/2009"));
            ViewData["Message"]="Hello, This is my view";
            return View();
        }
        public IActionResult Welcome()
        {
            ViewData["Message"]="Hello, Welcome to HelloWorld Application";
            return View();
        }

    }
}