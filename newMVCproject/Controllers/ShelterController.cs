using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Shelter.Shared;
using newMVCproject.Models;
using System.Linq;

namespace newMVCproject.Controllers
{
    public class ShelterController:Controller
    {
        public IActionResult Overview()
        {   
            
            return View(AnimalDatabase.Shelter);
            //new ListViewModel{ cats = cats}
        }

        public IActionResult Details(int id)
        {
            var targetAnimal = AnimalDatabase.Shelter.Cats.FirstOrDefault(x => x.Id == id);

            return View(targetAnimal);
        }

        public IActionResult Delete(int id)
        {
            var targetAnimal = AnimalDatabase.Shelter.Cats.FirstOrDefault(x => x.Id == id);
            
            return View(targetAnimal);
        }

        [HttpPost]
        public IActionResult DoDelete(int id)
        {
            var targetAnimal = AnimalDatabase.Shelter.Cats.FirstOrDefault(x => x.Id == id);
            if (targetAnimal == default(Cat))
            {
                return NotFound();
            }
           //cats.Remove(targetAnimal);

            return RedirectToAction(nameof(Overview));

        }

        public IActionResult Edit(int id)
        {
            var targetAnimal = AnimalDatabase.Shelter.Cats.FirstOrDefault(x => x.Id == id);
            if (targetAnimal == default(Cat))
                {
                    return NotFound();
                }
            return View(targetAnimal);
        }

        public IActionResult DoEdit(int id, string name)
        {
            var targetAnimal = AnimalDatabase.Shelter.Cats.FirstOrDefault(x => x.Id == id);
            if (targetAnimal == default(Cat))
                {
                    return NotFound();
                }
            targetAnimal.Name = name;
            return RedirectToAction(nameof(Overview));
        }
        
    }
}