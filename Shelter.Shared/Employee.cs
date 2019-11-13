using System;

namespace Shelter.Shared
{
    public abstract class Employee : BaseDbClass
    {
       public Employee(string name, string DateOfBirth, string Gender, string Mail){
            this.Name = Name;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.Mail = Mail;
    } 
    public string Name { get; set; }
    public string DateOfBirth { get; set; }
    public string Gender { get; set;}
    public string Mail { get; set;}


    }
}