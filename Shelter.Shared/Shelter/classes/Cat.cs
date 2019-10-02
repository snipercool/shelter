using System;

namespace Shelter
{
    public class Cat : Animal
    {
        public Cat(string Name, string DateOfBirth, bool IsChecked, bool KidFriendly, string DateOfArrival)
        : base(Name, DateOfBirth, IsChecked, KidFriendly, DateOfArrival){}
    }
}