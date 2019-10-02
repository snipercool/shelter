using System;

namespace Shelter
{
    public abstract class Animal
    {
        public Animal(string Name, string DateOfBirth, bool IsChecked, bool KidFriendly, string DateOfArrival){
            this.Name = Name;
            this.DateOfBirth = DateOfBirth;
            this.IsChecked = IsChecked;
            this.KidFriendly = KidFriendly;
            this.DateOfArrival = DateOfArrival;
        }
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public bool IsChecked { get; set; }
        public bool KidFriendly { get; set; }
        public string DateOfArrival{ get; set; }
    }
}