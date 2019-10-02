using System;

namespace Shelter
{
    public class Dog : Animal
    {
        public Dog(string Name, string DateOfBirth, bool IsChecked, bool KidFriendly, string DateOfArrival)
        : base(Name, DateOfBirth, IsChecked, KidFriendly, DateOfArrival){}
    }
}