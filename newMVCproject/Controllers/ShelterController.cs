using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Shelter;
using newMVCproject.Models;
using System.Linq;

namespace newMVCproject.Controllers
{
    public class ShelterController:Controller
    {
        public List<Cat> GetCats(){
            var cats = new List<Cat>{};
            cats.Add(new Cat(0,"Felix","19/01/2005",true, true, "23/09/2019"));
            cats.Add(new Cat(1,"Bacardi","22/07/2008",true, false, "12/06/2018"));
            cats.Add(new Cat(2,"Misty","01/01/2001",true, true, "12/06/2009"));
            return cats;
        }

        public IActionResult Overview()
        {   
            var cats = GetCats();
            return View(new ListViewModel { cats = cats });
        }

        public Cat getTargetCat(List<Cat> cats, int id){
            for(int i = 0; i < cats.Count; i++){
                if(cats[i].Id == id){
                    Cat targetCat = cats[i];
                    return targetCat;
                }
            }
            return null;
        }

        public IActionResult Details(int id)
        {
            var cats = GetCats();
            var targetCat = getTargetCat(cats, id);

            return View(targetCat);
        }
    }
}