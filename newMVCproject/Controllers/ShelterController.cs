using Microsoft.AspNetCore.Mvc;
using Shelter;

namespace newMVCproject.Controllers
{
    public class ShelterController:Controller
    {
        public IActionResult Index()
        {   
            var cats = new List<Cat>{};
            cats.add(newCat);
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