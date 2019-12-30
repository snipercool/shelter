using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Shelter.Shared
{
    public interface IDatabaseInitializer
    {
        void Initialize();
    }

    public class DatabaseInitializer : IDatabaseInitializer
    {
        private ShelterContext _context;
        private ILogger<DatabaseInitializer> _logger;
        public DatabaseInitializer(ShelterContext context, ILogger<DatabaseInitializer> logger){
        _context = context;
        _logger = logger;
        }

        public void Initialize(){
            try
        {
            if (_context.Database.EnsureCreated())
            {
                AddData();
            }
        }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Error occurred while creating database");
            }
        }

        private void AddData()
        {
            var Cats = new List<Cat> {
                new Cat {Id = 1, name = "Felix", DateOfBirth = "19/01/2005", IsChecked = true, KidFriendly = true, DateOfArrival = "23/09/2019", ShelterId = 1, Declawed = true, Race = "Persian"},
                new Cat {Id = 2, name = "Bacardi", DateOfBirth = "22/07/2008", IsChecked = true, KidFriendly = false, DateOfArrival = "12/06/2018", ShelterId = 1, Declawed = false, Race = "Chartreux"},
                new Cat {Id = 3, name = "Misty", DateOfBirth = "01/01/2001", IsChecked = true, KidFriendly = true, DateOfArrival = "12/06/2009", ShelterId = 1, Declawed = true, Race = "American Shorthair"}
            };
            var Dogs = new List<Dog> {
                new Dog {Id = 4, name = "Sparky", DateOfBirth = "19/01/2005", IsChecked = true, KidFriendly = true, DateOfArrival = "23/09/2019", ShelterId = 1, Barker = false, Race = "Husky"},
                new Dog {Id = 5, name = "Barky", DateOfBirth = "22/07/2008", IsChecked = true, KidFriendly = false, DateOfArrival = "12/06/2018", ShelterId = 1, Barker = true, Race = "German Sheppard"},
                new Dog {Id = 6, name = "Woef", DateOfBirth = "01/01/2001", IsChecked = true, KidFriendly = true, DateOfArrival = "12/06/2009", ShelterId = 1, Barker = true, Race = "Tackle"}
            };
            var Cats2 = new List<Cat> {
                new Cat {Id = 7, name = "johnny", DateOfBirth = "19/01/2005", IsChecked = true, KidFriendly = true, DateOfArrival = "23/09/2019", ShelterId = 2, Declawed = true, Race = "streetcat"},
                new Cat {Id = 8, name = "wodka", DateOfBirth = "22/07/2008", IsChecked = true, KidFriendly = false, DateOfArrival = "12/06/2018", ShelterId = 2, Declawed = true, Race = "Persian"},
                new Cat {Id = 9, name = "Wiskers", DateOfBirth = "01/01/2001", IsChecked = true, KidFriendly = true, DateOfArrival = "12/06/2009", ShelterId = 2, Declawed = false, Race = "streetcat"}
            };
            var OtherAnimals = new List<Other> {
                new Other {Id = 10, name = "Gary", DateOfBirth = "19/01/2005", IsChecked = true, KidFriendly = true, DateOfArrival = "23/09/2019", ShelterId = 2, Description = "Gary is a special needs snkae", Kind = "Python snake"},
                new Other {Id = 11, name = "Cider", DateOfBirth = "22/07/2008", IsChecked = true, KidFriendly = false, DateOfArrival = "12/06/2018", ShelterId = 2, Description = "cider is an overweight rat", Kind = "Asian Black Rat"},
                new Other {Id = 12, name = "Rocky", DateOfBirth = "01/01/2001", IsChecked = true, KidFriendly = true, DateOfArrival = "12/06/2009", ShelterId = 2, Description = "Rocky doesn't move much", Kind = "pet rock"}
            };
            var Caretakers = new List<Caretaker> {
                new Caretaker {Name = "Steve", DateOfBirth = "20/04/1990", Gender = "male", Mail = "Steve@hotmale.com"},
                new Caretaker {Name = "John", DateOfBirth = "15/06/1969", Gender = "male", Mail = "John@hotmale.com"},
                new Caretaker {Name = "Becky", DateOfBirth = "01/01/1997", Gender = "male", Mail = "Becky@hotfemale.com"}
            };

            var _animals = new List<Animal>{};
            var _animals2 = new List<Animal>{};
            _animals.AddRange(Cats);
            _animals.AddRange(Dogs);
            _animals2.AddRange(Cats2);
            _animals2.AddRange(OtherAnimals);
            var _employees = new List<Employee>{};
            _employees.AddRange(Caretakers);
            var shelter1 = new Shelter {name = "shelter Mechelen", Animals = _animals, Employees = _employees};
            var shelter2 = new Shelter {name = "shelter Leuven", Animals = _animals2, Employees = _employees};
            _context.Shelters.Add(shelter1);
            _context.Shelters.Add(shelter2);
            _context.SaveChanges();
        }
    }
}