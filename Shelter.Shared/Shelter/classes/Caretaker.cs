using System;

namespace Shelter
{
    public class Caretaker : Employee
    {
        public Caretaker(string Name, string DateOfBirth, string Gender, string Mail)
        : base(Name, DateOfBirth, Gender, Mail){}
    }
}