using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Shelter.Shared
{
  public class ShelterContext : DbContext
  {
    public ShelterContext(DbContextOptions<ShelterContext> options) : base(options)
    {

    }

    public DbSet<Animal> Animals { get; set; }
    public DbSet<Cat> Cats { get; set; }
    public DbSet<Caretaker> Caretakers { get; set; }
    public DbSet<Dog> Dogs { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Manager> Managers { get; set; }
    public DbSet<Shelter> Shelters { get; set; }
  }
}