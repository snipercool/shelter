using System;

namespace Shelter
{
    public class Dog : Animal
    {
        public Dog(int Id, string Name, string DateOfBirth, bool IsChecked, bool KidFriendly, string DateOfArrival)
        : base(Id, Name, DateOfBirth, IsChecked, KidFriendly, DateOfArrival){}
    }
}