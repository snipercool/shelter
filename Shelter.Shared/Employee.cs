using System;

namespace Shelter.Shared
{
    public abstract class Employee : BaseDbClass
    { 
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set;}
        public string Mail { get; set;}
    }
}