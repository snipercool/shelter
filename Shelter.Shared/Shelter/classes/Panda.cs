using System;

namespace Shelter
{
    public class Panda : Animal
    {
        public Panda(string Name, string DateOfBirth, bool IsChecked, bool KidFriendly, string DateOfArrival)
        : base(Name, DateOfBirth, IsChecked, KidFriendly, DateOfArrival){}
    }
}