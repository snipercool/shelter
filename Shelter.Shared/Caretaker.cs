using System;

namespace Shelter.Shared
{
    public class Caretaker : Employee
    {
        public Caretaker(string Name, string DateOfBirth, string Gender, string Mail)
        : base(Name, DateOfBirth, Gender, Mail){}
    }
}