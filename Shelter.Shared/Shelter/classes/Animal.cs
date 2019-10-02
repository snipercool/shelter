using System;

namespace Shelter
{
    public abstract class Animal
    {
        public String Name;
        public String DateOfBirth;
        public boolean IsChecked;
        public boolean KidFriendly;
        public String DateOfArrival;

        public Animal(String Name, String DateOfBirth, boolean IsChecked, boolean KidFriendly, String DateOfArrival){
            this.Name = Name;
            this.DateOfBirth = DateOfBirth;
            this.IsChecked = IsChecked;
            this.KidFriendly = KidFriendly;
            this.Since = DateOfArrival;
        }

    }
}