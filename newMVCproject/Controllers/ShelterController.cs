using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Shelter;
using newMVCproject.Models;

namespace newMVCproject.Controllers
{
    public class ShelterController:Controller
    {
        public IActionResult Index()
        {   
            var cats = new List<Cat>{};
            cats.Add(new Cat("Felix","19/01/2005",true, true, "23/09/2019"));
            cats.Add(new Cat("Bacardi","22/07/2008",true, false, "12/06/2018"));
            cats.Add(new Cat("Misty","01/01/2001",true, true, "12/06/2009"));
            return View(new ListViewModel { cats = cats});
        }
        public IActionResult CatList()
        {
            return View(new ListViewModel());
        }
    }
}