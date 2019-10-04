using System;

namespace Shelter
{
    public class Manager : Employee
    {
        public Manager(string Name, string DateOfBirth, string Gender, string Mail)
        : base(Name, DateOfBirth, Gender, Mail){}
    }
}