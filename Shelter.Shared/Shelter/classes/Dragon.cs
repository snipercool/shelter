using System;

namespace Shelter
{
    public class Dragon : Animal
    {
        public Dragon(string Name, string DateOfBirth, bool IsChecked, bool KidFriendly, string DateOfArrival)
        : base(Name, DateOfBirth, IsChecked, KidFriendly, DateOfArrival){}
    }
}