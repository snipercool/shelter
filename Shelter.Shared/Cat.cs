using System;

namespace Shelter.Shared
{
    public class Cat : Animal
    {
        public override string Name {get; set;}
        public override string DateOfBirth {get; set;}
        public override bool IsChecked {get; set;}
        public override bool KidFriendly {get; set;}
        public override string DateOfArrival {get; set;}
    }
}