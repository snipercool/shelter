using System;

namespace Shelter.Shared
{
    public class Admin : Employee
    {
        public Admin(string Name, string DateOfBirth, string Gender, string Mail)
        : base(Name, DateOfBirth, Gender, Mail){}
    }
}