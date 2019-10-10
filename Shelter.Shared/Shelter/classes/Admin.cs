using System;

namespace Shelter
{
    public class Admin : Employee
    {
        public Admin(string Name, string DateOfBirth, string Gender, string Mail)
        : base(Name, DateOfBirth, Gender, Mail){}
    }
}