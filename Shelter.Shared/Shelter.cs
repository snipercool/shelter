using System;
using System.Collections.Generic;

namespace Shelter.Shared
{
  public class Shelter : BaseDbClass
  {
    public string name { get; set; }
    public List<Animal> Animals { get; set; }
    public List<Employee> Employees { get; set; }
  }
}