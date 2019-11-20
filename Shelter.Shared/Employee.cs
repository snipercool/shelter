using System;

namespace Shelter.Shared
{
    public abstract class Employee : BaseDbClass
    { 
        public abstract string Name { get; set; }
        public abstract string DateOfBirth { get; set; }
        public abstract string Gender { get; set;}
        public abstract string Mail { get; set;}
    }
}