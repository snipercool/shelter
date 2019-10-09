using Microsoft.AspNetCore.Mvc;

namespace newMVCproject.Controllers
{
    public class ShelterController:Controller
    {
        public IActionResult Index()
        {   
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