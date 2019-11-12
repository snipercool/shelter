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
            var cats = GetCats();
            return View(new ListViewModel { cats = cats });
        }

        public IActionResult Details(int id)
        {
            var targetCat = AnimalDatabase.Shelter.Cats.FirstOrDefault(x => x.Id == id);

            return View(targetCat);
        }

        public IActionResult Delete(int id)
        {
            var targetCat = AnimalDatabase.Shelter.Cats.FirstOrDefault(x => x.Id == id);
            
            return View(targetCat);
        }

        [HttpPost]
        public IActionResult DoDelete(int id)
        {
            var target = AnimalDatabase.Shelter.Cats.FirstOrDefault(x => x.Id == id);
            if (target == default(Cat))
            {
                return NotFound();
            }
           cats.Remove(target);

            return RedirectToAction(nameof(Overview));

        }

        public IActionResult Edit(int id)
        {
            var targetcat = AnimalDatabase.Shelter.Cats.FirstOrDefault(x => x.Id == id);

            return View(targetcat);
        }

        public IActionResult DoEdit(int id, string name)
        {
            var targetCat = AnimalDatabase.Shelter.Cats.FirstOrDefault(x => x.Id == id);
            /*  doesn't work
            targetCat.Name = name;
            */
            return RedirectToAction(nameof(Overview));
        }
        
    }
}