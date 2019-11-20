using System;

namespace Shelter.Shared
{
    public class Manager : Employee
    {
        public override string Name { get; set; }
        public override string DateOfBirth { get; set; }
        public override string Gender { get; set;}
        public override string Mail { get; set;}
    }
}