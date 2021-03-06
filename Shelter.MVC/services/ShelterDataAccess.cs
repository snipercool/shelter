using System.Collections.Generic;
using System.Linq;
using Shelter.Shared;
using Microsoft.EntityFrameworkCore;

namespace Shelter.MVC
{
    public interface IShelterDataAccess
    {
        IEnumerable<Shared.Shelter> GetAllShelters();
        IEnumerable<Shared.Shelter> GetAllSheltersFull();
        Shared.Shelter GetShelterById(int id);
        IEnumerable<Animal> GetAnimals(int shelterId);
        Animal GetAnimalByShelterAndId(int shelterId, int animalId);
        Animal DeleteAnimal(int shelterId, int animalId);
        Animal UpdateAnimal(int shelterId, int animalId, string new_name, string dateOfBirth, bool isChecked, bool kidFriendly, string dateOfArrival, int new_shelterId);
        Animal CreateCat(Shelter.Shared.Cat cat);
        Animal CreateDog(Shelter.Shared.Dog dog);
        Animal CreateOther(Shelter.Shared.Other other);
    }

     public class ShelterDataAccess : IShelterDataAccess
     {
        private ShelterContext _context;

        public ShelterDataAccess(ShelterContext context)
        {
            _context = context;
        }

        public IEnumerable<Shared.Shelter> GetAllShelters()
        {
            return _context.Shelters;
        }

        public IEnumerable<Shared.Shelter> GetAllSheltersFull()
        {
            return _context.Shelters
                .Include(shelter => shelter.Animals)
                .Include(shelter => shelter.Employees);
        }

        public Animal GetAnimalByShelterAndId(int shelterId, int animalId)
        {
            return _context.Animals
                .FirstOrDefault(x => x.ShelterId == shelterId && x.Id == animalId);
        }

        public IEnumerable<Animal> GetAnimals(int shelterId)
        {
            return _context.Shelters
                .Include(shelter => shelter.Animals)
                .FirstOrDefault(x => x.Id == shelterId)?.Animals;
        }

        public Shared.Shelter GetShelterById(int id)
        {
            return _context.Shelters
                .FirstOrDefault(x => x.Id == id);
        }

        public Shared.Animal DeleteAnimal(int shelterId, int animalId)
        {
            var pickedAnimal = _context.Animals
                .FirstOrDefault(x => x.Id == animalId && x.ShelterId == shelterId);

            _context.Remove(pickedAnimal);
            _context.SaveChanges();

            return pickedAnimal;
    
        }

        public Shared.Animal UpdateAnimal(int shelterId, int animalId, string new_name, string dateOfBirth, bool isChecked, bool kidFriendly, string dateOfArrival, int new_shelterId)
        {
             var pickedAnimal = _context.Animals
                .FirstOrDefault(x => x.Id == animalId && x.ShelterId == shelterId);

            pickedAnimal.name = new_name;
            pickedAnimal.DateOfBirth = dateOfBirth;
            pickedAnimal.IsChecked = isChecked;
            pickedAnimal.KidFriendly = kidFriendly;
            pickedAnimal.DateOfArrival = dateOfArrival;
            pickedAnimal.ShelterId = new_shelterId;

            _context.Update(pickedAnimal);
            _context.SaveChanges();

            return pickedAnimal;
        
        }

        public Animal CreateCat(Shelter.Shared.Cat cat )
        {
            var newCat = new Cat {
                name = cat.name,
                DateOfBirth = cat.DateOfBirth,
                IsChecked = cat.IsChecked,
                KidFriendly = cat.KidFriendly,
                DateOfArrival = cat.DateOfArrival,
                ShelterId = cat.ShelterId,
                Declawed = cat.Declawed, 
                Race = cat.Race};
            _context.Add(newCat);
            _context.SaveChanges();

            return newCat;
        }

        public Animal CreateDog(Shelter.Shared.Dog dog )
        {
            var newDog = new Dog {
                name = dog.name,
                DateOfBirth = dog.DateOfBirth,
                IsChecked = dog.IsChecked,
                KidFriendly = dog.KidFriendly,
                DateOfArrival = dog.DateOfArrival,
                ShelterId = dog.ShelterId,
                Barker = dog.Barker, 
                Race = dog.Race};
            _context.Add(newDog);
            _context.SaveChanges();

            return newDog;
        }

        public Animal CreateOther(Shelter.Shared.Other other )
        {
            var newOther = new Other {
                name = other.name,
                DateOfBirth = other.DateOfBirth,
                IsChecked = other.IsChecked,
                KidFriendly = other.KidFriendly,
                DateOfArrival = other.DateOfArrival,
                ShelterId = other.ShelterId,
                Description = other.Description, 
                Kind = other.Kind};
            _context.Add(newOther);
            _context.SaveChanges();

            return newOther;
        }
     }
}