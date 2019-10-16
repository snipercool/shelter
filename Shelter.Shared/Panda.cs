using System;

namespace Shelter.Shared
{
    public class Panda : Animal
    {
        public Panda(int Id, string Name, string DateOfBirth, bool IsChecked, bool KidFriendly, string DateOfArrival)
        : base(Id, Name, DateOfBirth, IsChecked, KidFriendly, DateOfArrival){}
    }
}