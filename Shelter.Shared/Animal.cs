using System;

namespace Shelter.Shared
{
    public abstract class Animal
    {
        public abstract int Id { get; set; }
        public abstract string Name { get; set; }
        public abstract string DateOfBirth { get; set; }
        public abstract bool IsChecked { get; set; }
        public abstract bool KidFriendly { get; set; }
        public abstract string DateOfArrival{ get; set; }
    }
}