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
                new Cat {Id = 1, Name = "Felix", DateOfBirth = "19/01/2005", IsChecked = true, KidFriendly = true, DateOfArrival = "23/09/2019"},
                new Cat {Id = 2, Name = "Bacardi", DateOfBirth = "22/07/2008", IsChecked = true, KidFriendly = false, DateOfArrival = "12/06/2018"},
                new Cat {Id = 3, Name = "Misty", DateOfBirth = "01/01/2001", IsChecked = true, KidFriendly = true, DateOfArrival = "12/06/2009"}
            };
            var Dogs = new List<Dog> {
                new Dog {Id = 4, Name = "Sparky", DateOfBirth = "19/01/2005", IsChecked = true, KidFriendly = true, DateOfArrival = "23/09/2019"},
                new Dog {Id = 5, Name = "Barky", DateOfBirth = "22/07/2008", IsChecked = true, KidFriendly = false, DateOfArrival = "12/06/2018"},
                new Dog {Id = 6, Name = "Woef", DateOfBirth = "01/01/2001", IsChecked = true, KidFriendly = true, DateOfArrival = "12/06/2009"}
            };
            var Caretakers = new List<Caretaker> {
                new Caretaker {Name = "Steve", DateOfBirth = "20/04/1990", Gender = "male", Mail = "Steve@hotmale.com"},
                new Caretaker {Name = "John", DateOfBirth = "15/06/1969", Gender = "male", Mail = "John@hotmale.com"},
                new Caretaker {Name = "Becky", DateOfBirth = "01/01/1997", Gender = "male", Mail = "Becky@hotfemale.com"}
            };

            var _animals = new List<Animal>{};
            _animals.AddRange(Cats);
            _animals.AddRange(Dogs);
            var _employees = new List<Employee>{};
            _employees.AddRange(Caretakers);
            var shelter = new Shelter(){
                name = "shelter1",
                Animals = _animals,
                Employees = _employees
            };
            _context.Shelters.Add(shelter);
            _context.SaveChanges();
        }
    }
}