using System;

namespace Shelter.Shared
{
    public abstract class Animal
    {
        public Animal(int Id, string Name, string DateOfBirth, bool IsChecked, bool KidFriendly, string DateOfArrival){
            this.Id = Id;
            this.Name = Name;
            this.DateOfBirth = DateOfBirth;
            this.IsChecked = IsChecked;
            this.KidFriendly = KidFriendly;
            this.DateOfArrival = DateOfArrival;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public bool IsChecked { get; set; }
        public bool KidFriendly { get; set; }
        public string DateOfArrival{ get; set; }
    }
}