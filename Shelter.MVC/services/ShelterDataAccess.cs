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
        void UpdateAnimal(int shelterId, int animalId, Shelter.Shared.Animal animal);
        void CreateCat(int shelterId, Shelter.Shared.Cat cat);
        void CreateDog(int shelterId, Shelter.Shared.Dog dog);
        void CreateOther(int shelterId, Shelter.Shared.Other other);
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

        public void UpdateAnimal(int shelterId, int animalId, Shelter.Shared.Animal animal )
        {
             var pickedAnimal = _context.Animals
                .FirstOrDefault(x => x.Id == animalId && x.ShelterId == shelterId);

            pickedAnimal.name = animal.name;
            pickedAnimal.DateOfBirth = animal.DateOfBirth;
            pickedAnimal.IsChecked = animal.IsChecked;
            pickedAnimal.KidFriendly = animal.KidFriendly;
            pickedAnimal.DateOfArrival = animal.DateOfArrival;
            pickedAnimal.ShelterId = animal.ShelterId;
            pickedAnimal.Id = animal.Id;

            _context.Update(pickedAnimal);
            _context.SaveChanges();
        
        }

        public void CreateCat(int shelterId, Shelter.Shared.Cat cat )
        {
            var newCat = new Cat {
                name = cat.name,
                DateOfBirth = cat.DateOfBirth,
                IsChecked = cat.IsChecked,
                KidFriendly = cat.KidFriendly,
                DateOfArrival = cat.DateOfArrival,
                ShelterId = shelterId,
                Declawed = cat.Declawed, 
                Race = cat.Race};
            _context.Add(newCat);
            _context.SaveChanges();
        }

        public void CreateDog(int shelterId, Shelter.Shared.Dog dog )
        {
            var newDog = new Dog {
                name = dog.name,
                DateOfBirth = dog.DateOfBirth,
                IsChecked = dog.IsChecked,
                KidFriendly = dog.KidFriendly,
                DateOfArrival = dog.DateOfArrival,
                ShelterId = shelterId,
                Barker = dog.Barker, 
                Race = dog.Race};
            _context.Add(newDog);
            _context.SaveChanges();
        }

        public void CreateOther(int shelterId, Shelter.Shared.Other other )
        {
            var newOther = new Other {
                name = other.name,
                DateOfBirth = other.DateOfBirth,
                IsChecked = other.IsChecked,
                KidFriendly = other.KidFriendly,
                DateOfArrival = other.DateOfArrival,
                ShelterId = shelterId,
                Description = other.Description, 
                Kind = other.Kind};
            _context.Add(newOther);
            _context.SaveChanges();
        }
     }
}