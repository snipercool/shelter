using System;

namespace Shelter.Shared
{
    public class Cat : Animal
    {
        public Cat(int Id, string Name, string DateOfBirth, bool IsChecked, bool KidFriendly, string DateOfArrival)
        : base(Id, Name, DateOfBirth, IsChecked, KidFriendly, DateOfArrival){}
    }
}